using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Structural
{
    internal class Queue<T> : System.Collections.Generic.Queue<T>, ICollection<T>
    {
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this.Enqueue(item);
        }

        public bool Remove(T item)
        {
            try
            {
                this.Dequeue();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }

        }
    }
}
