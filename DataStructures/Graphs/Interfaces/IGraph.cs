using DataStructures.Graphs.Nodes.Interfaces;

namespace DataStructures.Graphs.Interfaces
{
    public interface IGraph<T> where T : INode
    {
        public NodeCollection<T> Nodes { get; }
    }
}
