using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Math
{
    public static class Primes
    {
        /// <summary>
        /// Checks wether the argument is prime number
        /// </summary>
        /// <param name="number">The number to be checked</param>
        /// <returns>Is the number prime</returns>
        public static bool IsPrime(int number)
        {
            int i = 2;
            if (number == 2)
                return true;

            while (i <= System.Math.Sqrt(number))
            {
                if (number % i == 0)
                    return false;
                i++;
            }

            return true;
        }
    }
}
