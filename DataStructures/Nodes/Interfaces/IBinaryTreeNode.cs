namespace DataStructures.Nodes.Interfaces
{
    /// <summary>
    /// Implementation of a tree node where each node has a left and a right child
    /// </summary>
    /// <typeparam name="T">Node's value</typeparam>
    public interface IBinaryTreeNode<T> : ITreeNode<T>
    {
        public IBinaryTreeNode<T> LeftNode { get; set; }
        public IBinaryTreeNode<T> RightNode { get; set; }
    }
}
