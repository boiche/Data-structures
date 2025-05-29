using System;
using System.Collections.Generic;

namespace Algorithms.Sort
{
    public class InsertionSort<T> : ISorting<T> where T : IComparable<T>
    {
        public void Sort(IList<T> source)
        {
            for (int i = 1; i < source.Count; i++)
            {
                T currentElement = source[i];
                int tempIndex = i - 1;

                // moves all greater elements than 'currentElement' 1 position to the right
                while (tempIndex >= 0 && source[tempIndex].CompareTo(currentElement) > 0)
                {
                    source[tempIndex + 1] = source[tempIndex];
                    tempIndex -= 1;
                }
                source[tempIndex + 1] = currentElement;
            }
        }
    }
}
