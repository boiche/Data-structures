using DataStructures.Trees.Enumerators.BinaryTree.Interfaces;
using DataStructures.Trees.Nodes.Interfaces;
using System;
using System.Collections;

namespace DataStructures.Recursive.Enumerators.BinaryTree
{
    /// <summary>
    /// Implementation of Preorder traversal <c>(Root-Left-Right)</c>. Applicable for <see cref="IBinaryTreeNode{T}"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class PreorderTraversor<T> : IBinaryTreeEnumerator<T>
    {
        private IBinaryTreeNode<T> _current;
        private readonly IBinaryTreeNode<T> _root;
        private Linear.Queue<IBinaryTreeNode<T>> _queue;

        public T Current => _current.Value;
        public IBinaryTreeNode<T> CurrentNode => _current;
        object IEnumerator.Current => Current;

        public PreorderTraversor(IBinaryTreeNode<T> root)
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

            _queue.Enqueue(root);
            CreateQueue(root.LeftNode);
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
            _current = default;
            _queue.Clear();
            CreateQueue(_root);
        }
    }
}
