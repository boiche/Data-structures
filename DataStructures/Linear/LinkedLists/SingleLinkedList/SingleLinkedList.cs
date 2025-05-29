using DataStructures.Linear.LinkedLists.SingleLinkedList.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Linear.LinkedLists
{
    public class SingleLinkedList<T> : IEnumerable<T>
    {
        private SingleLinkedNode<T> _root;
        private SingleLinkedNode<T> _tail;
        public int Count { get; private set; }
        public SingleLinkedNode<T> Root { get => _root; }
        public SingleLinkedNode<T> Tail { get => _tail; }

        public SingleLinkedList()
        {
            Count = 0;
        }
        public SingleLinkedList(SingleLinkedNode<T> root, SingleLinkedNode<T> tail = null)
        {
            _root = root;
            Count++;
            if (tail is null) _tail = root;
            else
            {
                _root.LinkNode(tail);
                _tail = tail;
                Count++;
            }
        }

        /// <summary>
        /// Adds new node at the end of the list.
        /// </summary>
        /// <param name="value">Value of the new node</param>
        public void AddNode(T value)
        {
            SingleLinkedNode<T> newNode = new SingleLinkedNode<T>(value, this, null);

            if (Count == 0)
            {
                _root = newNode;
                _tail = _root;
            }
            else
            {
                _tail.LinkNode(newNode);
                _tail = newNode;
            }
            Count++;
        }

        /// <summary>
        /// Inserts new node at the given index of the list.
        /// </summary>
        /// <param name="value">Value of the new node</param>
        /// <param name="index">Index at which to insert node</param>
        public void InsertNode(T value, int index)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            else if (Count > 0)
            {
                SingleLinkedNode<T> parent = FindAt(index - 1);
                SingleLinkedNode<T> oldChild = parent.NextNode;
                SingleLinkedNode<T> newNode = new SingleLinkedNode<T>(value, this, parent);
                parent.LinkNode(newNode);
                newNode.LinkNode(oldChild);
            }
            else
            {
                SingleLinkedNode<T> newRoot = new SingleLinkedNode<T>(value, this, _root);
                _root = newRoot;
            }
            Count++;
        }

        /// <summary>
        /// Returns node at given index.
        /// </summary>
        /// <param name="index">Index of the node</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public SingleLinkedNode<T> FindAt(int index)
        {
            CheckIndex(index);
            SingleLinkedNode<T> result = _root;
            for (int i = 0; i < index; i++) result = result.NextNode;
            return result;
        }

        /// <summary>
        /// Returns node's value at given index.
        /// </summary>
        /// <param name="index">Index of the node</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T GetValueAt(int index) => FindAt(index).Value;

        /// <summary>
        /// Returns the index of the first element with matched value. If not found, returns -1.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(T value)
        {
            int index = 0;
            foreach (T item in this)
            {
                if (item.Equals(value)) return index;
                else index++;
            }
            return -1;
        }

        public void Reverse()
        {

        }

        /// <summary>
        /// Removes the last element of the list
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Remove()
        {
            EnsureNotEmpty();
            var current = _root;
            while (current.NextNode != _tail) current = current.NextNode;
            current.UnlinkNode();
            _tail = current;
            Count--;
        }

        public void RemoveAt(int index)
        {
            EnsureNotEmpty();
            CheckIndex(index);

            SingleLinkedNode<T> parent = FindAt(index - 1);
            SingleLinkedNode<T> toRemove = parent.NextNode;
            parent.LinkNode(toRemove.NextNode);
            toRemove.UnlinkNode();
        }

        public void Clear()
        {
            _root = null;
            _tail = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _root;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CheckIndex(int index)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
        }
        private void EnsureNotEmpty()
        {
            if (Count == 0) throw new InvalidOperationException();
        }
    }
}
