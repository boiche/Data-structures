using DataStructures.Graphs.Nodes.Interfaces;

namespace DataStructures.Graphs.Interfaces
{
    public interface IGraph<NodeType, ValueType> where NodeType : INode<ValueType>
    {
        public int Components { get; }
        public NodeCollection<NodeType, ValueType> Nodes { get; }
    }
}
