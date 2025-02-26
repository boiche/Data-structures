using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Recursive.Graphs.Interfaces;

namespace DataStructures.Recursive.Graphs
{
    /// <summary>
    /// Implementation of Disjoint Set Union (DSU)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DSU<T> : BaseGraph<T>
    {
        private new Dictionary<T, T> _source;
        /// <summary>
        /// Count of distinct elements in all sets
        /// </summary>
        public new int Count { get => _source.Count; }
        /// <summary>
        /// Count of distinct sets
        /// </summary>
        public int SetCount { get => _source.Count(x => x.Value.Equals(x.Key)); }

        public DSU(ISet<T> values) : base()
        {
            _source = new Dictionary<T, T>();
            foreach (var item in values)
            {
                _source.Add(item, item);
            }
        }

        /// <summary>
        /// Searches for the main parent of the current set. Applies path compression
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public T Find(T key)
        {
            T parent = _source.GetValueOrDefault(key, key);               

            if (!parent.Equals(key))
            {
                parent = Find(parent);
                _source[key] = parent;                
            }

            return parent;
        }

        /// <summary>
        /// Assigns given item to the set of given key
        /// </summary>
        /// <param name="item"></param>
        /// <param name="key"></param>
        public void Assign(T item, T key)
        {
            if (!_source.ContainsKey(item))
                throw new KeyNotFoundException();    
                
            _source[item] = key;
        }

        public void Union(T item1, T item2)
        {
            _source[Find(item1)] = Find(item2);
        }
    }
}
