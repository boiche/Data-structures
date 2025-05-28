using DataStructures.Trees.Enumerators.BinaryTree.Interfaces;
using DataStructures.Trees.Enumerators.Tree;
using DataStructures.Trees.Nodes.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataStructures.Trees.Interfaces
{
    public abstract class BaseTree<T> : ITreeEnumerable<T>
    {
        /// <summary>
        /// Contains elements that don't match <see cref="T"/>
        /// </summary>
        protected IEnumerable<object> temp_source;
        protected IEnumerable<T> _source;
        protected ITreeEnumerator<T> _traversor;           
        protected ITreeNode<T> _root;

        /// <summary>
        /// Keeps the root of the tree
        /// </summary>
        public ITreeNode<T> Root 
        {
            get => _root;
            protected set
            {
                _root = value;
                SetTraversor();
            }
        }
        /// <summary>
        /// Keeps track of node count of the tree
        /// </summary>
        public int Count { get; internal set; }

        public BaseTree() { }
        public BaseTree(IEnumerable<T> source) : this()
        {
            this._source = source;
        }
        public BaseTree(IEnumerable<object> source) : this()
        {
            temp_source = source;
        }
        public BaseTree(ITreeNode<T> root) : this()
        {
            Root = root;
            var enumerator = GetEnumerator();

            while (enumerator.MoveNext())            
                Count++;           
        }

        /// <summary>
        /// Creates new component (separate tree) with root <paramref name="item"/> to the structure
        /// </summary>
        /// <param name="item"></param>
        public abstract void AddComponent(T item);
        /// <summary>
        /// Removes all occurances of nodes with <paramref name="value"/>
        /// </summary>
        /// <param name="value">Nodes' value to be removed</param>
        public abstract void Remove(T item);

        public ITreeEnumerator<T> GetEnumerator()
        {
            return _traversor;
        }
        protected virtual void SetTraversor()
        {
            _traversor = new PreorderTraversor<T>(Root);
        }
    }
}
