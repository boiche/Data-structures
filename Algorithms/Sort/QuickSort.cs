using System;
using System.Collections.Generic;

namespace Algorithms.Sort
{
    public class QuickSort<T> : ISorting<T> where T : IComparable<T>
    {
        public void Sort(IList<T> source)
        {
            SortMain(source, 0, source.Count - 1);
        }

        private void SortMain(IList<T> source, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(source, left, right);

                SortMain(source, left, pivotIndex - 1);
                SortMain(source, pivotIndex + 1, right);
            }
        }

        private int Partition(IList<T> source, int left, int right)
        {
            T pivotElement = source[right];
            int index = left - 1;

            for (int i = left; i < right; i++)
            {
                if (source[i].CompareTo(pivotElement) < 0)
                {
                    index++;

                    T temp = source[index];
                    source[index] = source[i];
                    source[i] = temp;
                }
            }

            T c = source[index + 1];
            source[index + 1] = source[right];
            source[right] = c;

            return index + 1;
        }
    }
}
