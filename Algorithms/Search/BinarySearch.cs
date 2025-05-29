using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Search
{
    public static class BinarySearch
    {
        private static int _left;
        private static int _right;
        private static int _middle;
        public static int Search<T>(IList<T> source, T find) where T : IComparable<T>
        {
            var ordered = source.OrderBy(x => x).ToList();
            _left = 0;
            _right = ordered.Count - 1;

            T temp;
            int comparison;

            while (_left <= _right)
            {
                _middle = (_left + _right) / 2;
                temp = ordered[_middle];
                comparison = temp.CompareTo(find);
                if (comparison > 0) //'find' is smaller                
                    _right = _middle - 1;
                else if (comparison < 0) //'find' is greater
                    _left = _middle + 1;
                else
                    return _middle;
            }
            return -1;
        }
    }
}
