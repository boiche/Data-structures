using DataStructures.Trees.Interfaces;
using System.Collections.Generic;

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
            /// Applies neither path compression nor union by rank
            /// </summary>
            None,
            /// <summary>
            /// Applies path compression for <see cref="Find(T)"/>
            /// </summary>
            PathCompression,
            /// <summary>
            /// Applies union by rank for <see cref="Union(T, T)"/>
            /// </summary>
            UnionByRank
        }

        private Dictionary<T, T> _sets;
        private Dictionary<T, int> _ranks;
        private DSUOptions _options;
        private int _setCount;

        public int Sets { get => _setCount; }

        public DSU(ISet<T> values, DSUOptions options) : base(values)
        {
            _sets = [];
            _ranks = [];
            _options = options;
            _setCount = values.Count;
            Count = values.Count;

            BuildTree();
        }

        /// <summary>
        /// Searches for the parent of the current set
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public T Find(T key)
        {
            if (!_sets.TryGetValue(key, out T parent))
                throw new KeyNotFoundException($"Given element not found in the initial data. Mind call {nameof(Assign)}");

            if (_options == DSUOptions.PathCompression)
            {
                if (!parent.Equals(key))
                {
                    parent = Find(parent);
                    _sets[key] = parent;
                }
            }
            else
            {
                if (_sets[key].Equals(key))
                    parent = key;
                else
                    parent = Find(_sets[key]);
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
            _sets[item] = key;
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
                    _sets[rightRoot] = leftRoot;
                else if (comparison == -1)
                    _sets[leftRoot] = rightRoot;
                else
                {
                    _sets[leftRoot] = rightRoot;
                    _ranks[rightRoot]++;
                }

                _setCount--;
            }
            else
            {
                var left = Find(item1);
                var right = Find(item2);
                _sets[left] = right;

                if (!left.Equals(right))
                    _setCount--;
            }
        }

        protected void BuildTree()
        {
            foreach (var item in _source)
            {
                _sets.Add(item, item);
                _ranks.Add(item, 0);
            }
        }

        public override void AddComponent(T item)
        {
            Assign(item, item);
        }

        public override void Remove(T item)
        {
            _sets.Remove(item);
            _ranks.Remove(item);
        }
    }
}
