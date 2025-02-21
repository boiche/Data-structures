namespace DataStructures.Nodes
{
    /// <summary>
    /// Implementation of a node that supports Key-Value pairing
    /// </summary>
    /// <typeparam name="T">Key's type</typeparam>
    /// <typeparam name="V">Value's type</typeparam>
    public interface IBinaryNode<T, V>
    {
        public T Key { get; set; }
        public V Value { get; set; }
    }
}
