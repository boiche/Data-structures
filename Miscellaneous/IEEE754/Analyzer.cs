using System.Collections;
using System.Text;

namespace Miscellaneous.IEEE754
{
    /// <summary>
    /// Provides methods for analyzing IEEE 754 standard. Finds faulty rounding of numbers ref. JS
    /// </summary>
    internal static class IEEE754
    {
        private static int faults = 0;
        private static decimal? firstFault;
        public static void Manual()
        {
            while (true)
            {
                Console.Write("Enter decimal number: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal input))
                    break;
                Analyze(input);
            }
        }

        public static void Automatic()
        {
            decimal left = -9007199254740990.99m, right = 9007199254740990.99m, temp = (right - left) / 2;
            bool up = false;
            decimal result = decimal.MinValue;
            decimal minResult = decimal.MaxValue;

            while (left <= right)
            {
                temp = up ? left + (right - left) / 2 : (right - left) / 2;
                up = false;
                temp += 0.99m - temp % 1;

                if (temp == left || temp == right)
                    break;

                if (!Analyze(temp))
                {
                    left = temp;
                    up = true;
                    if (result <= temp)
                        result = temp;
                    if (minResult >= temp)
                        minResult = temp;
                }
                else
                    right = temp;
            }

            Console.WriteLine("/**** SUMMARY ****/");
            Console.WriteLine($"Total faults: {faults}");
            if (faults > 0)
                Console.WriteLine($"First fault: {firstFault ?? 0m}");
            Console.WriteLine($"Max no fault: {result}");
            Console.WriteLine($"Min no fault: {minResult}");
        }

        private static bool Analyze(decimal decimalInput)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Current decimal number: {decimalInput}");

            StringBuilder builder = new StringBuilder();
            string signPart = decimalInput > 0 ? "0" : "1";
            string wholePart = Convert.ToString((long)(decimalInput / 1), 2);
            string decimalPart = GetDecimalPartAsBinary(decimalInput % 1);

            builder.Append(signPart);
            builder.Append(wholePart);
            builder.Append(decimalPart);

            string binary = $"{wholePart}.{decimalPart}";
            int power = decimalInput >= 1 ? binary.IndexOf('.') - binary.IndexOf('1') - 1 : binary.IndexOf('.') - binary.IndexOf('1');
            binary = binary.Replace(".", "");
            string mantissa = binary.Substring(binary.IndexOf('1') + 1);


            string input = GetIEEE754(signPart, 1023 + power, mantissa);

            decimal sign = input[0] == '1' ? -1m : 1m;
            BitArray exponent = new(input.Substring(1, 11).Select(x => byte.Parse(x.ToString())).Select(x => x == 1).ToArray());
            BitArray mantiss = new(input.Substring(12).Select(x => byte.Parse(x.ToString())).Select(x => x == 1).ToArray());

            double exponentResult = 0d;
            for (int i = exponent.Length - 1, index = 0; i >= 0; i--, index++)
            {
                if (exponent[i])
                    exponentResult += Math.Pow(2, (index));
            }

            decimal mantissResult = 0m;
            for (int i = 0; i < mantiss.Length; i++)
            {
                if (mantiss[i])
                    mantissResult += (decimal)Math.Pow(2, -(i + 1));
            }

            decimal result = sign * (1 + mantissResult) * (decimal)Math.Pow(2, exponentResult - 1023);
            decimal absoluteDifference = Math.Abs(decimalInput - result);

            if (absoluteDifference >= 0.005m)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                faults++;
                if (!firstFault.HasValue)
                    firstFault = decimalInput;
            }
            Console.WriteLine($"The result is: {result}\tAbsolute difference: {absoluteDifference}\r\n");

            return absoluteDifference >= 0.005m;
        }

        private static string GetIEEE754(string sign, int power, string mantissa)
        {
            string exponent = Convert.ToString(power, 2);
            if (exponent.Length < 11)
                exponent = new string('0', 11 - exponent.Length) + exponent;

            if (mantissa.Length > 52)
            {
                mantissa = mantissa[..53];
                int leadingZeros = 0;
                if (mantissa.First() == '0')
                    leadingZeros = mantissa.IndexOf('1');
                if (mantissa.Last() == '1')
                {
                    mantissa = $"{new string('0', leadingZeros)}{Convert.ToString(Convert.ToInt64(mantissa, 2) + 1, 2)}";
                }
                if (mantissa.Length > 52)
                    mantissa = mantissa[..52];
            }

            Console.WriteLine($"IEEE754: {sign} {exponent} {mantissa}{new string('0', 52 - mantissa.Length)}");
            return $"{sign}{exponent}{mantissa}{new string('0', 52 - mantissa.Length)}";
        }

        private static string GetDecimalPartAsBinary(decimal decimalPart)
        {
            if (decimalPart <= 0)
                return "0";
            StringBuilder builder = new StringBuilder();
            HashSet<decimal> decimals = new HashSet<decimal>()
            {
                decimalPart
            };
            decimal temp = decimalPart;
            bool loopDetected = false;
            while (temp > 0)
            {
                temp *= 2;

                if (!loopDetected && !decimals.Add(temp))
                    loopDetected = true;

                if (temp >= 1.00m)
                {
                    builder.Append('1');
                    temp -= 1.00m;
                }
                else
                    builder.Append('0');

                if (loopDetected && builder.Length >= 52 * 2)
                {
                    break;
                }
            }
            return builder.ToString();
        }
    }
}
