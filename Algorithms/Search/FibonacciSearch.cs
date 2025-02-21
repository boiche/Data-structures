using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Search
{
    public class FibonacciSearch
    {
        public static int Search<T>(IList<T> source, T item) where T : IComparable<T>
        {
            source = source.OrderBy(x => x).ToList();
            int fib_2 = 0, fib_1 = 1; //first and second Fibonacci numbers
            int currentFib = fib_2 + fib_1;
            int offset = -1;
            while (currentFib < source.Count)
            {
                fib_2 = fib_1;
                fib_1 = currentFib;
                currentFib = fib_2 + fib_1;
            }

            while (currentFib > 1)
            {
                int index = System.Math.Min(offset + fib_2, source.Count - 1);
                if (source[index].CompareTo(item) < 0)
                {
                    currentFib = fib_1;
                    fib_1 = fib_2;
                    fib_2 = currentFib - fib_1;
                    offset = index;
                }
                else if (source[index].CompareTo(item) > 0)
                {
                    currentFib = fib_2;
                    fib_1 -= fib_2;
                    fib_2 = currentFib - fib_1;
                }
                else
                {
                    return index;
                }
            }

            if (fib_2 == 1 && source.Last().CompareTo(item) == 0)
            {
                return source.Count - 1;
            }

            return -1;
        }
    }
}
