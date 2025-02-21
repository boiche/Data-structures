using System.Collections.Generic;

namespace DataStructures.Nodes.Interfaces
{
    /// <summary>
    /// Implementation of a node that has unlimited amount of children. 
    /// Applicable for graphs. Not suggested for use of trees. Use instead 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INode<T>
    {
        public T Value { get; set; }
        public abstract List<T> Children { get; set; }
    }
}
