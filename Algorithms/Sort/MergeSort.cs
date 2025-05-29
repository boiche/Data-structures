using System;
using System.Collections.Generic;

namespace Algorithms.Sort
{
    public class MergeSort<T> : ISorting<T> where T : IComparable<T>
    {
        public void Sort(IList<T> source)
        {
            SortMain(source, 0, source.Count - 1);
        }

        private void SortMain(IList<T> source, int left, int right)
        {
            if (left < right)
            {
                int middleIndex = (left + right) / 2;

                SortMain(source, left, middleIndex);
                SortMain(source, middleIndex + 1, right);

                Merge(source, left, middleIndex, right);
            }
        }

        /// <summary>
        /// Merges the subarrays [left..middle] and [middle+1..right]
        /// </summary>
        private void Merge(IList<T> source, int left, int middleIndex, int right)
        {
            int leftCount = middleIndex - left + 1;
            int rightCount = right - middleIndex;

            T[] leftArray = new T[leftCount];
            T[] rightArray = new T[rightCount];

            for (int i = 0; i < leftCount; i++)
            {
                leftArray[i] = source[left + i];
            }
            for (int i = 0; i < rightCount; i++)
            {
                rightArray[i] = source[middleIndex + 1 + i];
            }

            int indexLeftArray = 0, indexRightArray = 0;
            int startIndex = left;

            while (indexLeftArray < leftCount && indexRightArray < rightCount)
            {
                if (leftArray[indexLeftArray].CompareTo(rightArray[indexRightArray]) <= 0)
                {
                    source[startIndex] = leftArray[indexLeftArray];
                    indexLeftArray++;
                }
                else
                {
                    source[startIndex] = rightArray[indexRightArray];
                    indexRightArray++;
                }
                startIndex++;
            }

            while (indexLeftArray < leftCount)
            {
                source[startIndex] = leftArray[indexLeftArray];
                startIndex++;
                indexLeftArray++;
            }

            while (indexRightArray < rightCount)
            {
                source[startIndex] = rightArray[indexRightArray];
                startIndex++;
                indexRightArray++;
            }
        }
    }
}
