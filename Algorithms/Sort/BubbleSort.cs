using System;
using System.Collections.Generic;

namespace Algorithms.Sort
{
    public class BubbleSort<T> : ISorting<T> where T : IComparable<T>
    {
        public void Sort(IList<T> source)
        {
            for (int i = 0; i < source.Count; i++)
            {
                for (int j = 0; j < source.Count - 1; j++)
                {
                    if (source[j].CompareTo(source[j + 1]) > 0)
                    {
                        T temp = source[j + 1];
                        source[j + 1] = source[j];
                        source[j] = temp;
                    }
                }
            }
        }
    }
}
