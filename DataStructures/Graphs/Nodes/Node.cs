using DataStructures.Graphs.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Graphs.Nodes
{
    /// <summary>
    /// Basic graph node
    /// </summary>
    /// <typeparam name="T">Type of node's value</typeparam>
    public class Node<T> : INode<T>
    {
        public T Value { get; set; }
        public List<T> Children { get; set; }

        object INode.Value { get => Value; }

        public Node(T value)
        {
            Value = value;
            Children = [];
        }

        public override string ToString()
            => $"Value = {Value}";
    }
}
