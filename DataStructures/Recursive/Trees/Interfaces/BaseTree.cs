using DataStructures.Nodes.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Recursive.Trees.Interfaces
{
    public abstract class BaseTree<T> : IEnumerable<T> where T : IEquatable<T>, IComparable<T>
    {
        protected IEnumerator<T> traversor;
        protected IEnumerable<T> source;
        /// <summary>
        /// Contains elements that don't match <see cref="T"/>
        /// </summary>
        protected IEnumerable<object> temp_source;
        
        public abstract ITreeNode<T> Root { get; }
        public int Count { get; set; }

        public BaseTree(IEnumerable<T> source)
        {
            this.source = source;
        }
        public BaseTree(IEnumerable<object> source)
        {
            temp_source = source;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return traversor;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return traversor;
        }
        /// <summary>
        /// Creates tree's nodes and links them
        /// </summary>
        protected abstract void BuildTree();
    }
}
