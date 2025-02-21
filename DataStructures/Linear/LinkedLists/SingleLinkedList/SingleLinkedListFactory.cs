using System;

namespace DataStructures.Linear.LinkedLists
{
    public static class SingleLinkedListFactory<T>
    {
        /// <summary>
        /// Creates new instance of <typeparamref name="SingleLinkedListFactory"/> based on given array of elements
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SingleLinkedList<T> GetListFromArray(T[] array)
        {
            ArgumentNullException.ThrowIfNull(array);
            SingleLinkedList<T> result = new SingleLinkedList<T>();
            foreach (T item in array) result.AddNode(item);
            return result;
        }
    }
}
