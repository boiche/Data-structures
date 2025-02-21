using System;
using System.Collections.Generic;

namespace Algorithms.Sort
{
    /// <summary>
    /// Marks a class as a provider of a sorting algorithm
    /// </summary>    
    public interface ISorting<T> where T : IComparable<T>
    { 
        public void Sort(IList<T> source);
    }
}
