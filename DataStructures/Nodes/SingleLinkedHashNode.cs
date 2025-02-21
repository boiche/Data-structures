namespace DataStructures.Nodes
{
    /// <summary>
    /// Singly linked node used as an unit of data container in hash table
    /// </summary>
    /// <typeparam name="K">Key's type</typeparam>
    /// <typeparam name="V">Value's type</typeparam>
    public class SingleLinkedHashNode<K, V> : SingleLinkedNode<V>, IBinaryNode<K, V>
    {
        public K Key { get; set; }
        public new SingleLinkedHashNode<K, V> NextNode { get; private set; }
        public SingleLinkedHashNode(K key, V value, SingleLinkedNode<V> nextNode = null) : base(value, nextNode)
        {
            Key = key;
        }
    }    
}
