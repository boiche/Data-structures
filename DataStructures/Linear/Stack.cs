using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Linear
{
    public  class Stack<T>
    {
        private T[] elements;
        private int index = 0;
        public Type GenericType { get => typeof(T); }

        public int Count { get => index; }
        public int Capacity { get => elements.Length; }

        public Stack()
        {
            elements = Array.Empty<T>();
        }

        public Stack(Array arr)
        {
            elements = new T[arr.Length];
            index = arr.Length;
            Array.Copy(arr, elements, arr.Length);
        }

        public Stack(int capacity)
        {
            elements = new T[capacity];
        }
        public void Push(T item)
        {
            if (index == Capacity)
                ResizeStack();
            elements[index] = item;
            index++;
        }
        public T Pop()
        {
            T item = elements[index - 1];
            elements[index - 1] = default;
            ShrinkStack(index - 1);
            this.index--;
            return item;
        }

        public T Peek()
        {
            return elements[index - 1];
        }
        
        private void ResizeStack()
        {
            T[] newElements;
            if (Capacity == 0)
            {
                newElements = new T[1];
            }
            else
            {
                newElements = new T[Capacity * 2];
                Array.Copy(elements, newElements, elements.Length);
            }
            elements = newElements;
        }
        private void ShrinkStack(int index)
        {
            T[] newElements = new T[elements.Length];
            for (int i = 0, j = 0; i < elements.Length; i++, j++)
            {
                if (i == index)
                {
                    j--;
                    continue;
                }
                newElements[j] = elements[i];
            }
            elements = newElements;
        }

        internal void Clear()
        {
            this.elements = new T[elements.Length];
            index = 0;
        }
    }
}
