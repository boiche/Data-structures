using DataStructures.Linear.LinkedLists.DoubleLinkedList.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Linear.LinkedLists.DoubleLinkedList
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        private DoubleLinkedNode<T> _root;
        private DoubleLinkedNode<T> _tail;
        public int Count { get; private set; }
        public DoubleLinkedList(DoubleLinkedNode<T> root = null, DoubleLinkedNode<T> tail = null)
        {
            _root = root;
            if (root != tail) _tail = tail;
            else _tail = _root;
            Count = default;
        }

        public T GetValueAt(int index) => FindAt(index).Value;

        public void AddNode(T value)
        {
            DoubleLinkedNode<T> newNode = new DoubleLinkedNode<T>(value);
            if (_root is null)
            {
                _root = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.LinkNextNode(newNode);
                newNode.LinkPrevNode(_tail);
                _tail = newNode;
            }

            Count++;
        }

        public void InsertNode(T value, int index)
        {
            if (index == 0 || index + 1 == Count)
            {
                AddNode(value);
                return;
            }
            CheckIndex(index);
            DoubleLinkedNode<T> newNode = new DoubleLinkedNode<T>(value);
            DoubleLinkedNode<T> parent = FindAt(index - 1);
            DoubleLinkedNode<T> oldChild = parent.NextNode;
            parent.LinkNextNode(newNode);
            oldChild.LinkPrevNode(newNode);
            newNode.LinkNextNode(oldChild);
            newNode.LinkPrevNode(parent);
            Count++;
        }

        public void Remove()
        {
            _tail = _tail.PrevNode;
            _tail.UnlinkNextNode();
            Count--;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);
            DoubleLinkedNode<T> toDelete = FindAt(index);
            DoubleLinkedNode<T> parent = toDelete.PrevNode as DoubleLinkedNode<T>;
            if (index == 0) _root = toDelete.NextNode;
            if (index == Count - 1) _tail = parent;
            if (parent != null) parent.LinkNextNode(toDelete.NextNode);
            if (toDelete.PrevNode != null) toDelete.PrevNode.LinkPrevNode(parent);
            Count--;
        }

        public void Clear()
        {
            _root = null;
            _tail = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _root;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode as DoubleLinkedNode<T>;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CheckIndex(int index)
        {
            if (Count <= index) throw new IndexOutOfRangeException();
        }

        private DoubleLinkedNode<T> FindAt(int index)
        {
            DoubleLinkedNode<T> current = _root;
            CheckIndex(index);
            for (int i = 0; i < index; i++) current = current.NextNode as DoubleLinkedNode<T>;
            return current;
        }
    }
}
