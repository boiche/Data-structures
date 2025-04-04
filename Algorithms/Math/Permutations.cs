using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Math
{
    public static class Permutations
    {
        private static List<IEnumerable<int>> list;

        /// <summary>
        /// Generates <see cref="IList{T}"/> with all permutations
        /// </summary>
        /// <param name="from">Start number</param>
        /// <param name="to">End number</param>
        /// <returns>All permutations with numbers <paramref name="from"/> <paramref name="to"/> inclusive</returns>
        /// <exception cref="ArgumentException"><paramref name="from"/> is greater or equals to <paramref name="to"/></exception>
        public static IList<IEnumerable<int>> Generate(int from, int to)
        {
            if (from >= to)
                throw new ArgumentException($"Argument {nameof(from)} must be smaller than {nameof(to)}");

            list = new List<IEnumerable<int>>();
            var source = Enumerable.Range(from, to - from + 1).ToArray();

            Permute(0, source);

            return list;
        }

        private static void Permute(int index, IList<int> source)
        {
            if (index == source.Count)
                list.Add(new List<int>(source));
            else
            {
                for (int i = index; i < source.Count; i++)
                {
                    Swap(source, index, i);
                    Permute(index + 1, source);
                    Swap(source, index, i);
                }
            }
        }

        private static void Swap(IList<int> source, int index1, int index2)
        {
            int temp = source[index1];
            source[index1] = source[index2];
            source[index2] = temp;
        }
    }
}
