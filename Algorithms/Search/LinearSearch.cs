using System;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public static class LinearSearch
    {
        public static int Search<T>(IEnumerable<T> source, T find) where T : IEquatable<T>
        {
            int index = 0;
            foreach (T item in source)
            {
                if (item.Equals(find))
                    return index;
                index++;
            }
            return -1;
        }
    }
}
