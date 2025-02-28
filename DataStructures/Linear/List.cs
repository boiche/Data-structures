using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Linear
{
    public class List<T> : IEnumerable<T>
    {
        private T[] content;
        private int index = 0;

        public int Count { get => index; }
        public int Capacity { get => content.Length; }
        public Type GenericType { get => typeof(T); }

        public T this[int index]
        {
            get => content[index];
            set => content[index] = value;
        }

        public List()
        {
            content = Array.Empty<T>();
        }
        public List(int size)
        {
            content = new T[size];
        }
        public List(Array data)
        {
            content = new T[data.Length];
            index = data.Length;
            Array.Copy(data, content, data.Length);
        }

        public void Add(T item)
        {
            if (index == Capacity)
                ResizeList();

            content[index] = item;
            index++;
        }
        public void Remove(T item)
        {
            int index = Array.IndexOf(content, item);
            if (index == -1) return;
            content[index] = default;
            ShrinkList(index);
            this.index--;
        }
        public void RemoveAt(int index)
        {
            content[index] = default;
            ShrinkList(index);
            this.index--;
        }

        private void ResizeList()
        {
            T[] newContent;
            if (Capacity == 0)
                newContent = new T[1];
            else
            {
                newContent = new T[Capacity * 2];
                Array.Copy(content, newContent, Capacity);
            }
            content = newContent;
        }
        private void ShrinkList(int index)
        {
            T[] newContent = new T[content.Length];
            for (int i = 0, j = 0; i < content.Length; i++, j++)
            {
                if (i == index)
                {
                    j--;
                    continue;
                }
                newContent[j] = content[i];
            }
            content = newContent;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"{nameof(Count)} = {Count}";
        }
    }
}
