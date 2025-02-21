using System;
using System.Linq;

namespace Algorithms.Math
{
    public class FibonacciNumbers
    {
        public static int GetNumberIterative(byte numberOrder)
        {
            if (numberOrder < 0)
                throw new ArgumentException("Number cannot be of negative order");
            if (numberOrder == 0)
                return 0;
            if (numberOrder <= 2)
                return 1;
            int result = 1;
            int[] previous = new int[2] { 1, 1 };
            for (int i = 3; i <= numberOrder; i++)
            {
                result = previous.Sum();
                previous[0] = previous[1];
                previous[1] = result;
            }
            return result;
        }

        public static int GetNumberRecursive(byte numberOrder)
        {
            if (numberOrder < 0)
                throw new ArgumentException("Number cannot be of negative order");
            if (numberOrder == 0)
                return 0;
            if (numberOrder <= 2)
                return 1;
            else
                return GetNumberRecursive((byte)(numberOrder - 1)) + GetNumberRecursive((byte)(numberOrder - 2));
        }
    }
}
