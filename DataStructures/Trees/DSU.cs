using System.Collections.Generic;
using System.ComponentModel.Design;
using DataStructures.Graphs.Interfaces;
using DataStructures.Trees.Interfaces;
using DataStructures.Trees.Nodes.Interfaces;

namespace DataStructures.Trees
{
    /// <summary>
    /// Implementation of Disjoint Set Union (DSU)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DSU<T> : BaseTree<T>
    {
        public enum DSUOptions
        {
            /// <summary>
            /// Applies path compression for <see cref="Find(T)"/>
            /// </summary>
            PathCompression,
            /// <summary>
            /// Applies union by rank for <see cref="Union(T, T)"/>
            /// </summary>
            UnionByRank
        }

        private new Dictionary<T, T> _source;
        private Dictionary<T, int> _ranks;
        private DSUOptions _options;

        public DSU(ISet<T> values, DSUOptions options) : base(values)
        {
            _source = [];
            _ranks = [];
            _options = options;
            Count = values.Count;

            foreach (var item in values)
            {
                _source.Add(item, item);
                _ranks.Add(item, 0);
            }
        }

        /// <summary>
        /// Searches for the parent of the current set
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public T Find(T key)
        {
            if (!_source.TryGetValue(key, out T parent))
                throw new KeyNotFoundException($"Given element not found in the initial data. Mind call {nameof(Assign)}");

            if (_options == DSUOptions.PathCompression)
            {
                if (!parent.Equals(key))
                {
                    parent = Find(parent);
                    _source[key] = parent;
                }
            }
            else
            {
                if (_source[key].Equals(key))
                    parent = key;
                else
                    parent = Find(_source[key]);
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
            Count++;
            _source[item] = key;
        }

        /// <summary>
        /// Joins both items into one set. If no <see cref="DSUOptions.UnionByRank"/> assigns <paramref name="item1"/> to the set of <paramref name="item2"/>
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public void Union(T item1, T item2)
        {
            if (_options == DSUOptions.UnionByRank)
            {
                T leftRoot = Find(item1);
                T rightRoot = Find(item2);

                if (leftRoot.Equals(rightRoot))
                    return;

                int comparison = _ranks[leftRoot].CompareTo(_ranks[rightRoot]);

                if (comparison == 1)
                    _source[leftRoot] = rightRoot;
                else if (comparison == -1)
                    _source[rightRoot] = leftRoot;
                else
                {
                    _source[leftRoot] = rightRoot;
                    _ranks[leftRoot] = _ranks[rightRoot] + 1;
                }
            }
            else
            {
                _source[Find(item1)] = Find(item2);
            }
        }

        protected override void BuildTree()
        {
            throw new System.NotImplementedException();
        }
    }
}
