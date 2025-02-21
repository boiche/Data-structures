using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Miscellaneous.RSA
{
    internal class RSA
    {
        public static void Main()
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("message = ");
            string message = Console.ReadLine().ToUpper();
            Dictionary<char, int> keyValues = new Dictionary<char, int>()
            {
                { ' ', 2 },
                { 'А', 30 },
                { 'Б', 29 },
                { 'В', 28 },
                { 'Г', 27 },
                { 'Д', 26 },
                { 'Е', 25 },
                { 'Ж', 24 },
                { 'З', 23 },
                { 'И', 22 },
                { 'Й', 21 },
                { 'К', 20 },
                { 'Л', 19 },
                { 'М', 18 },
                { 'Н', 17 },
                { 'О', 16 },
                { 'П', 15 },
                { 'Р', 14 },
                { 'С', 13 },
                { 'Т', 12 },
                { 'У', 33 },
                { 'Ф', 34 },
                { 'Х', 35 },
                { 'Ц', 11 },
                { 'Ч', 36 },
                { 'Ш', 37 },
                { 'Щ', 38 },
                { 'Ъ', 1 },
                { 'Ь', 47 },
                { 'Ю', 39 },
                { 'Я', 40 },
            };
            Console.Write("p = ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("q = ");
            int q = int.Parse(Console.ReadLine());
            int n = p * q;
            int Fn = (p - 1) * (q - 1);
            int publicKey = GetPublicKey(Fn);
            int secretKey = (int)(BigInteger.Pow(publicKey, Phi(Fn) - 1) % Fn);
            Tuple<int, int> keys = new Tuple<int, int>(publicKey, secretKey);
            Queue<int> cipher = new Queue<int>();

            foreach (char letter in message)
            {
                try
                {
                    int code = (int)(BigInteger.Pow(keyValues[letter], publicKey) % n);
                    cipher.Enqueue(code);
                }
                catch (KeyNotFoundException)
                {
                    continue;
                }
            }
            Console.WriteLine("Cypher is " + string.Join("", cipher));

            string decipher = string.Empty;
            while (cipher.Count > 0)
            {
                int code = cipher.Dequeue();
                decipher += keyValues.FirstOrDefault(x => x.Value == (int)(BigInteger.Pow(code, secretKey) % n)).Key;
            }
            Console.WriteLine($"Message is {decipher}");
        }

        private static int GetPublicKey(int fn)
        {
            for (int i = fn - 1; i > 0; i--)
            {
                if (GCD(i, fn) == 1) return i;
            }
            return int.MinValue;
        }

        private static int GCD(int i, int fn)
        {
            int tmp;
            if (i < fn)
            {
                tmp = i;
                i = fn;
                fn = tmp;
            }
            while (fn != 0)
            {
                tmp = i % fn;
                i = fn;
                fn = tmp;
            }
            return i;
        }

        static int Phi(int n)
        {
            int result = n;
            for (int p = 2; p * p <= n; ++p)
            {
                if (n % p == 0)
                {
                    while (n % p == 0)
                        n /= p;
                    result -= result / p;
                }
            }

            if (n > 1)
                result -= result / n;
            return result;
        }
    }
}
