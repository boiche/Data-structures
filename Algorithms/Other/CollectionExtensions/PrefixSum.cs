using System.Collections.Generic;
using System.Numerics;

namespace Algorithms.Other.CollectionExtensions
{
    public static partial class CollectionExtensions
    {
        public static IList<T> ToPrefixSum<T>(this IList<T> source) where T : IAdditionOperators<T, T, T>
        {
            List<T> result = new List<T>();
            T sum = default;

            for (int i = 0; i < source.Count; i++)
            {
                sum += source[i];
                result.Add(sum);
            }

            return result;
        }
    }
}
