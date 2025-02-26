using System.Collections.Generic;

namespace DataStructures.Graphs.Nodes.Interfaces
{
    /// <summary>
    /// Implementation of a node that has unlimited amount of children. 
    /// Applicable for graphs. Not suggested for use of trees. Use instead <see cref="Trees.Nodes.Interfaces.ITreeNode{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INode<T>
    {
        public T Value { get; set; }
        public abstract List<T> Children { get; set; }
    }
}
