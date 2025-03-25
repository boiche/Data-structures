using DataStructures.Graphs.Nodes.Interfaces;

namespace DataStructures.Graphs.Interfaces
{
    public interface IWeightedGraph<NodeType, ValueType> : IGraph<NodeType, ValueType> where NodeType : INode<ValueType>
    {
        public VertexCollection Vertices { get; }

        public IVertex GetVertex(NodeType currentNode, NodeType nextNode);
    }
}
