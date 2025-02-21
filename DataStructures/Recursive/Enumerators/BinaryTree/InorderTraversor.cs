using DataStructures.Linear;
using DataStructures.Nodes.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Recursive.Enumerators.BinaryTree
{
    /// <summary>
    /// Implementation of Inorder traversal <c>(Left-Root-Right)</c>. Applicable for <see cref="IBinaryTreeNode{T}"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class InorderTraversor<T> : IEnumerator<T> where T : IEquatable<T>, IComparable<T>
    {
        private readonly IBinaryTreeNode<T> _root;
        private IBinaryTreeNode<T> _current;
        private readonly Linear.Queue<IBinaryTreeNode<T>> _queue;

        public T Current => _current.Value;

        object IEnumerator.Current => _current;

        public InorderTraversor(IBinaryTreeNode<T> root)
        {
            ArgumentNullException.ThrowIfNull(root);
            _root = root;
            _queue = new();
            CreateQueue(root);
        }

        private void CreateQueue(IBinaryTreeNode<T> root)
        {
            if (root == null)
                return;

            CreateQueue(root.LeftNode);
            _queue.Enqueue(root);
            CreateQueue(root.RightNode);
        }

        public void Dispose()
        {
            GC.ReRegisterForFinalize(this);
        }

        public bool MoveNext()
        {
            if (_queue.Count > 0)
            {
                _current = _queue.Dequeue();
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _queue.Clear();
            CreateQueue(_root);
        }
    }
}
