using System.Collections.Generic;
using System.Numerics;

namespace Algorithms.Other.CollectionExtensions
{
    public static partial class CollectionExtensions
    {
        public enum Operation
        {
            Addition,
            Substraction
        }
        /// <summary>
        /// Updates range of values by either adding or substracting <paramref name="value"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="start">Inclusive</param>
        /// <param name="end">Inclusive</param>
        /// <param name="value"></param>
        public static void UpdateRange<T>(this IList<T> source, int start, int end, T value, Operation operation) where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>
        {
            T[] differenceArray = new T[source.Count + 1];
            differenceArray[0] = source[0];
            differenceArray[^1] = default;
            for (int i = 1; i < source.Count; i++)
            {
                differenceArray[i] = source[i] - source[i - 1];
            }

            if (operation == Operation.Addition)
            {
                differenceArray[start] += value;
                differenceArray[end + 1] -= value;
            }
            else
            {
                differenceArray[start] -= value;
                differenceArray[end + 1] += value;
            }

            for (int i = 0; i < source.Count; i++)
            {
                if (i == 0)
                    source[i] = differenceArray[i];
                else
                    source[i] = differenceArray[i] + source[i - 1];
            }
        }
    }
}
