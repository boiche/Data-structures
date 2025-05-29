using Algorithms.Sort;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Strategy
{
    /// <summary>
    /// A mechanism for applying a sorting strategy for any collection of IComparable items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortingContext<T> where T : IComparable<T>
    {
        /// <summary>
        /// Provides reference to sorting implementation
        /// </summary>
        private ISorting<T> _sorting;
        public SortingContext(ISorting<T> sorting) //refer to DI constructor injection
        {
            _sorting = sorting;
        }
        public void SetSorting(ISorting<T> newSorting) => _sorting = newSorting; //refer to DI method injection
        public void Sort(IList<T> source)
        {
            Console.WriteLine($"Before sorting with {_sorting.GetType().Name}: {string.Join(", ", source)}");
            _sorting.Sort(source);
            Console.WriteLine($"After sorting with {_sorting.GetType().Name}: {string.Join(", ", source)}");
        }
    }
}
