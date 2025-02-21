namespace DataStructures.Linear.LinkedLists.DoubleLinkedList
{
    public static class DoubleLinkedListFactory<T>
    {
        public static DoubleLinkedList<T> CreateFromArray(T[] array)
        {
            DoubleLinkedList<T> list = new DoubleLinkedList<T>();
            for (int i = 0; i < array.Length; i++) list.AddNode(array[i]);
            return list;
        }
    }
}
