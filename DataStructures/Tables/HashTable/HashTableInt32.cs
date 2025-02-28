//using Algorithms.Hashes;
using DataStructures.Linear.LinkedLists.SingleLinkedList.Nodes;
using DataStructures.Tables;
using System;
using System.Collections.Generic;

namespace DataStructures.Tables.HashTable
{
    /// <summary>
    /// Hash table structure with predefined type for hash keys: Int32. Aims to simplify hashing
    /// </summary>
    /// <typeparam name="TValue">The type of stored values</typeparam>
    public class HashTableInt32<TValue> : BaseHashTable<int, TValue>
    {
        public HashTableInt32(int size)
        {
            _source = new SingleLinkedHashNode<int, TValue>[size];
            tableSize = size;
        }
        /// <summary>
        /// Gets item's value by given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public override TValue GetValue(int key)
        {
            int hashIndex = HashFunction(key);
            SingleLinkedHashNode<int, TValue> node = _source[hashIndex];

            while (node != null)
            {
                if (node.Key == key)
                    return node.Value;
                node = node.NextNode;
            }

            throw new KeyNotFoundException("The given key was does not exist in the current hash table.");
        }

        /// <summary>
        /// Adds new item to the table
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Put(int key, TValue value)
        {
            int index = HashFunction(key);
            SingleLinkedHashNode<int, TValue> node;
            try
            {
                node = _source[index];
            }
            catch (IndexOutOfRangeException)
            {
                node = default;
            }                

            if (node is null)
            {
                _source[index] = new SingleLinkedHashNode<int, TValue>(key, value);
                return;
            }

            if (node.Key == key)
                throw new ArgumentException("An element with the same key already exists.");

            while (node.NextNode != null)
            {
                node = node.NextNode;
                if (node.Key == key)
                    throw new ArgumentException("An element with the same key already exists.");
            }

            SingleLinkedHashNode<int, TValue> nodeToAdd = new(key, value);
            node = new SingleLinkedHashNode<int, TValue>(node.Key, node.Value, nodeToAdd);
            tableSize++;
        }

        /// <summary>
        /// Removes the item with given key
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public override void Remove(int key)
        {
            tableSize--;
            throw new KeyNotFoundException("The given key was does not exist in the current hash table.");
        }

        protected override int HashFunction(int key)
        {
            return 6;
            //return HashFunctions.BasicHashFunction(key.ToString(), tableSize);
        }
    }
}
