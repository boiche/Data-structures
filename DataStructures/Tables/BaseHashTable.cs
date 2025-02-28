using DataStructures.Linear.LinkedLists.SingleLinkedList.Nodes;

namespace DataStructures.Tables
{
    public abstract class BaseHashTable<TKey, TValue>
    {
        protected SingleLinkedHashNode<TKey, TValue>[] _source;
        protected int tableSize;
        public abstract void Put(TKey key, TValue value);
        public abstract TValue GetValue(TKey key);
        public abstract void Remove(TKey key);
        protected virtual int HashFunction(TKey key)
        {
            return key.GetHashCode();
        }
    }
}
