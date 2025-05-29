using System.Collections.Generic;

namespace DataStructures.Trees.Nodes.Interfaces
{
    /// <summary>
    /// Implementation of a tree node
    /// </summary>
    /// <typeparam name="T">Node's value</typeparam>
    public interface ITreeNode<T> : ITreeNode
    {
        /// <summary>
        /// Stored data of current node
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// Collection with all linked child nodes
        /// </summary>
        public IList<ITreeNode<T>> Children { get; }
        /// <summary>
        /// Indicates that current node has no children
        /// </summary>
        public bool IsLeaf { get; }
    }

    public interface ITreeNode
    {
    }
}