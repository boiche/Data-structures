namespace DataStructures.Graphs.Nodes.Interfaces
{
    /// <summary>
    /// A node with identification. 
    /// Applicable for graphs. Not suggested for use of trees. Use instead <see cref="Trees.Nodes.Interfaces.ITreeNode{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIdentifiedNode<T> : INode<T>
    {
        public int ID { get; }
    }
}
