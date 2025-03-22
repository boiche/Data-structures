using DataStructures.Trees.Nodes.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees.Interfaces
{
    public abstract class BaseTree<T> : IEnumerable<T>
    {
        protected IEnumerator<T> _traversor;
        protected IEnumerable<T> _source;
        /// <summary>
        /// Contains elements that don't match <see cref="T"/>
        /// </summary>
        protected IEnumerable<object> temp_source;
        
        
        public int Count { get; protected set; }

        public BaseTree(IEnumerable<T> source)
        {
            this._source = source;
        }
        public BaseTree(IEnumerable<object> source)
        {
            temp_source = source;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _traversor;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _traversor;
        }
        /// <summary>
        /// Creates tree's nodes and links them
        /// </summary>
        protected abstract void BuildTree();
    }
}
