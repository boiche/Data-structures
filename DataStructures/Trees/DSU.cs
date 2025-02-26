using System.Collections.Generic;

namespace DataStructures.Trees
{
    /// <summary>
    /// Implementation of Disjoint Set Union (DSU)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DSU<T>
    {
        private Dictionary<T, T> _source;
        public int Count { get => _source.Count; }

        public DSU(ISet<T> values)
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
            if (!_source.TryGetValue(key, out T parent))
                throw new KeyNotFoundException($"Given element not found in the initial data.Mind call {nameof(Assign)}");

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
            _source[item] = key;
        }

        public void Union(T item1, T item2)
        {
            _source[Find(item1)] = Find(item2);
        }
    }
}
