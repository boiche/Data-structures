using DataStructures.Trees.Nodes.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees.Enumerators.BinaryTree
{
    /// <summary>
    /// Implementation of Morris traversal <c>(Left-Root-Right)</c> without recursion or stack. Applicable for <see cref="IBinaryTreeNode{T}"/> 
    /// </summary>
    /// <typeparam name="T">Type of node's value</typeparam>
    public class MorrisTraversor<T> : IEnumerator<T>
    {
        private readonly IBinaryTreeNode<T> _root;
        private IBinaryTreeNode<T> _current;
        private readonly Linear.Queue<IBinaryTreeNode<T>> _queue;

        public T Current => _current.Value;

        object IEnumerator.Current => _current;

        public MorrisTraversor(IBinaryTreeNode<T> root)
        {
            ArgumentNullException.ThrowIfNull(root);
            _root = root;
            _queue = new();
            CreateQueue(root);
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

        private void CreateQueue(IBinaryTreeNode<T> root)
        {
            IBinaryTreeNode<T> current = root;

            while (current != null)
            {
                if (current.LeftNode == null)
                {
                    _queue.Enqueue(current);
                    current = current.RightNode;
                }
                else
                {
                    IBinaryTreeNode<T> previous = current.LeftNode;
                    while (previous.RightNode != null && previous.RightNode != current)
                    {
                        previous = previous.RightNode;
                    }

                    if (previous.RightNode == null)
                    {
                        previous.RightNode = current;
                        current = current.LeftNode;
                    }
                    else
                    {
                        previous.RightNode = null;
                        _queue.Enqueue(current);
                        current = current.RightNode;
                    }
                }
            }
        }
    }
}
