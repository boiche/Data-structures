using DataStructures.Trees.Enumerators.BinaryTree.Interfaces;
using DataStructures.Trees.Nodes.Interfaces;
using System;
using System.Collections;

namespace DataStructures.Trees.Enumerators.Tree
{
    /// <summary>
    /// Implementation of Postorder traversal <c>(Children-Root)</c>. Applicable for <see cref="ITreeNode{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class PostorderTraversor<T> : ITreeEnumerator<T>
    {
        private ITreeNode<T> _current;
        private readonly ITreeNode<T> _root;
        private Linear.Queue<ITreeNode<T>> _queue;

        public T Current => _current.Value;
        public ITreeNode<T> CurrentNode => _current;
        object IEnumerator.Current => Current;

        public PostorderTraversor(ITreeNode<T> root)
        {
            ArgumentNullException.ThrowIfNull(root);
            _root = root;
            _queue = new();

            CreateQueue(root);
        }

        private void CreateQueue(ITreeNode<T> root)
        {
            if (root == null)
                return;

            foreach (ITreeNode<T> child in root.Children)
            {
                CreateQueue(child);
            }

            _queue.Enqueue(root);
        }

        public void Dispose()
        {
            GC.ReRegisterForFinalize(this);
        }

        public bool MoveNext()
        {
            if (_queue.TryDequeue(out ITreeNode<T> next))
            {
                _current = next;
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
