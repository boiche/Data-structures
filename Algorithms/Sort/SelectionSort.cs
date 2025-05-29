using System;
using System.Collections.Generic;

namespace Algorithms.Sort
{
    public class SelectionSort<T> : ISorting<T> where T : IComparable<T>
    {
        public void Sort(IList<T> source)
        {
            for (int i = 0; i < source.Count; i++)
            {
                T smallest = source[i];
                int smallestIndex = i;
                for (int j = i + 1; j < source.Count; j++)
                {
                    if (smallest.CompareTo(source[j]) > 0)
                    {
                        smallest = source[j];
                        smallestIndex = j;
                    }
                }

                T temp = source[smallestIndex];
                source[smallestIndex] = source[i];
                source[i] = temp;
            }
        }
    }
}
