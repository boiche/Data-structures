using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Structural
{
    internal class Stack<T> : System.Collections.Generic.Stack<T>, ICollection<T>
    {
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this.Push(item);
        }

        public bool Remove(T item)
        {
            try
            {
                this.Pop();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }            
        }
    }
}
