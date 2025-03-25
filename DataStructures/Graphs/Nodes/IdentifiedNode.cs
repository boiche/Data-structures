using DataStructures.Graphs.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Graphs.Nodes
{
    public class IdentifiedNode<T> : IIdentifiedNode<T>
    {
        public IdentifiedNode(T value, int id)
        {
            Value = value;
            ID = id;
            Children = [];
        }

        public T Value { get; set; }
        public List<T> Children { get; set; }
        public int ID { get; }
        object INode.Value { get => Value; }
    }
}
