using DataStructures.Graphs.Nodes.Interfaces;

namespace DataStructures.Graphs.Interfaces
{
    public interface IWeightedGraph<T> : IGraph<T> where T : IWeightedNode
    {
        public VertexCollection Vertices { get; }
    }
}
