using System.Collections.Generic;

namespace DataStructures.Trees.Nodes.Interfaces
{
    /// <summary>
    /// Implementation of a tree node, that has value of type <see cref="T"/>
    /// </summary>
    /// <typeparam name="T">Node's value</typeparam>
    public interface ITreeNodeValue<T> : ITreeNode
    {
        /// <summary>
        /// Stored data of current node
        /// </summary>
        public T Value { get; set; }
    }
    /// <summary>
    /// Implementation of a tree node
    /// </summary>
    /// <typeparam name="T">Node's value</typeparam>
    public interface ITreeNode<T> : ITreeNodeValue<T>
    {
        /// <summary>
        /// Collection with all linked child nodes
        /// </summary>
        public IList<ITreeNode<T>> Children { get; }
    }
    /// <summary>
    /// Implementation of a tree node
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        /// Indicates that current node has no children
        /// </summary>     
        public bool IsLeaf { get; }
    }
}