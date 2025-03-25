using DataStructures.Graphs.Nodes.Interfaces;
using System;

namespace DataStructures.Graphs.Nodes
{
    public class Vertex : IVertex
    {
        public int Weight { get; }

        public Tuple<INode, INode> LinkedNodes { get; }

        public Vertex(int weight, INode first, INode second)
        {
            Weight = weight;
            LinkedNodes = new(first, second);
        }

        public override int GetHashCode()
        {
            return LinkedNodes.Item1.Value.GetHashCode() + LinkedNodes.Item2.Value.GetHashCode();
        }

        public override string ToString()
            => $"{LinkedNodes.Item1.Value}_{LinkedNodes.Item2.Value} Weight = {Weight}";
    }
}
