using DataStructures.Graphs.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Graphs.Nodes
{
    public class Node<T> : INode<T>
    {
        public T Value { get; set; }
        public List<T> Children { get; set; }

        public Node(T value)
        {
            Value = value;
            Children = [];
        }
    }
}
