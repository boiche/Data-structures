using DataStructures.Graphs.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Graphs.Nodes
{
    public class WeightedNode<T, W> : IWeightedNode<T, W>
    {
        public WeightedNode(T value, W weight)
        {
            Weight = weight;
            Value = value;
            Children = [];
        }

        public W Weight { get; set; }
        public T Value { get; set; }
        public List<T> Children { get; set; }
        object IWeightedNode.Weight { get => Weight; }
        object INode.Value { get => Value; }
    }
}
