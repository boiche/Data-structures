using System;

namespace DataStructures.Linear
{
    public class Deque<T>
    {
        private T[] elements;
        private int rearIndex = 0;
        private int frontIndex = -1;

        public int Count { get => rearIndex; }
        public int Capacity { get => elements.Length; }

        public Deque() { }
        public Deque(Array source)
        {
            elements = new T[source.Length];
            rearIndex = elements.Length;
            frontIndex = 0;
            Array.Copy(source, elements, source.Length);
        }
        public T PeekLast()
        {
            return elements[rearIndex];
        }
        public T PeekFirst()
        {
            return elements[frontIndex];
        }

        public void EnqueueLast(T item)
        {
            elements[rearIndex++] = item;
        }

        public void EnqueueFirst(T item)
        {
            elements[frontIndex++] = item;
        }

        public T DequeueLast()
        {
            if (Count == 0)
                throw new InvalidOperationException("Deque contains no elements");

            throw new NotImplementedException();
        }

        public T DequeueFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException("Deque contains no elements");

            throw new NotImplementedException();
        }
    }
}
