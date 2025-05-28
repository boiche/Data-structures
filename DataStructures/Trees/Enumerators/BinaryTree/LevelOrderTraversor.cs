using DataStructures.Trees.Enumerators.BinaryTree.Interfaces;
using DataStructures.Trees.Nodes.Interfaces;
using System;
using System.Collections;

namespace DataStructures.Recursive.Enumerators.BinaryTree
{
    /// <summary>
    /// Implementation of Level Order traversal <c>(BFS)</c>. Applicable for <see cref="IBinaryTreeNode{T}"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LevelOrderTraversor<T> : IBinaryTreeEnumerator<T>
    {
        private readonly IBinaryTreeNode<T> _root;
        private IBinaryTreeNode<T> _current;
        private readonly Linear.Queue<IBinaryTreeNode<T>> _queue;

        public T Current => _current.Value;
        public IBinaryTreeNode<T> CurrentNode => _current;
        object IEnumerator.Current => Current;        

        public LevelOrderTraversor(IBinaryTreeNode<T> root)
        {
            ArgumentNullException.ThrowIfNull(root);
            _root = root;
            _queue = new();

            CreateQueue(root);
        }

        private void CreateQueue(IBinaryTreeNode<T> root)
        {
            Linear.Queue<IBinaryTreeNode<T>> temp = new();

            _queue.Enqueue(root);
            temp.Enqueue(root);

            while (temp.Count > 0)
            {
                var current = temp.Dequeue();

                if (current.LeftNode != null)
                {
                    temp.Enqueue(current.LeftNode);
                    _queue.Enqueue(current.LeftNode);
                }
                if (current.RightNode != null)
                {
                    temp.Enqueue(current.RightNode);
                    _queue.Enqueue(current.RightNode);
                }
            }
        }        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
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
