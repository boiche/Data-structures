using System.Collections.Generic;

namespace DataStructures.Graphs.Nodes.Interfaces
{
    /// <summary>
    /// Implementation of a node that has unlimited amount of children. 
    /// Applicable for graphs. Not suggested for use of trees. Use instead <see cref="Trees.Nodes.Interfaces.ITreeNode{T}"/>
    /// </summary>
    /// <typeparam name="T">Type of node's value</typeparam>
    public interface INode<T> : INode
    {
        public new T Value { get; set; }
        public List<T> Children { get; set; }
    }

    public interface INode
    {
        public object Value { get; }
    }
}
