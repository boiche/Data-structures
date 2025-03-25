using DataStructures.Graphs.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    /// <summary>
    /// Represents the collection of verticies in <see cref="IWeightedGraph{T, V}"/>
    /// </summary>
    public class VertexCollection
    {
        private Dictionary<string, IVertex> _verticies;

        public int Count { get => _verticies.Count; }

        public VertexCollection()
        {
            _verticies = [];
        }

        internal IVertex FindVertex(INode first, INode second)
        {
            return _verticies[GetKey(first, second)];
        }

        internal void Add(IVertex vertex)
        {
            _verticies.Add(GetKey(vertex), vertex);
        }

        internal void Remove(IVertex vertex)
        {
            _verticies.Remove(GetKey(vertex));
        }

        private string GetKey(IVertex vertex)
            => $"{vertex.LinkedNodes.Item1.Value}_{vertex.LinkedNodes.Item2.Value}";
        private string GetKey(INode first, INode second)
            => $"{first.Value}_{second.Value}";
    }
}
