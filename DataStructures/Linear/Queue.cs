using System;

namespace DataStructures.Linear
{
    public class Queue<T>
    {
        private T[] elements;
        private int index = 0;
        private int growthFactor = 2;
        public Type GenericType { get => typeof(T); }

        public int Count { get => index; }
        public int Capacity { get => elements.Length; }

        public Queue()
        {
            elements = Array.Empty<T>();
        }
        public Queue(Array arr)
        {
            elements = new T[arr.Length];
            index = arr.Length;
            Array.Copy(arr, elements, arr.Length);
        }
        public Queue(int capacity)
        {
            elements = new T[capacity];
        }
        public Queue(int capacity,int newGFactor)
        {
            elements = new T[capacity];
            growthFactor = newGFactor;
        }
        private void ResizeQueue()
        {
            T[] newElements;
            if (Capacity == 0)
            {
                newElements = new T[1];
            }
            else
            {
                newElements = new T[Capacity * growthFactor];
                Array.Copy(elements, newElements, elements.Length);
            }
            elements = newElements;
        }
        private void ShrinkQueue(int index)
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

        public void Enqueue(T item)
        {
            if (index == Capacity)
                ResizeQueue();
            elements[index] = item;
            index++;
        }

        public bool TryDequeue(out T value)
        {
            value = default;

            if (Count <= 0)
                return false;

            value = Dequeue();
            return true;
        }

        public T Dequeue()
        {
            T item = elements[0];
            elements[0] = default;
            ShrinkQueue(0);
            this.index--;
            return item;
        }
        
        public T Peek()
        {
            return elements[0];
        }

        public void Clear()
        {
            elements = Array.Empty<T>();
            index = 0;
        }

        public override string ToString()
        {
            return $"{nameof(Count)} = {Count}";
        }
    }
}
