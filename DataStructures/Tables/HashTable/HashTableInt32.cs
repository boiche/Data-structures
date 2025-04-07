using Algorithms.Hashes;
using System;

namespace DataStructures.Tables.HashTable
{
    /// <summary>
    /// Hash table structure with predefined type for hash keys: Int32. Aims to simplify hashing
    /// </summary>
    /// <typeparam name="TValue">The type of stored values</typeparam>
    public class HashTable<TKey, TValue> : BaseHashTable<TKey, TValue>
    {
        public override TValue Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public override void Put(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public override void Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        protected override int HashFunction(TKey key)
        {
            return HashFunctions.OneByOneHash(key.ToString());
        }
    }
}
