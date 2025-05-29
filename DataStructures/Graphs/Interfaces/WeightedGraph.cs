using DataStructures.Graphs.Nodes;
using DataStructures.Graphs.Nodes.Interfaces;

namespace DataStructures.Graphs.Interfaces
{
    /// <summary>
    /// Supports undirected verticies with weights
    /// </summary>
    /// <typeparam name="NodeType">Type of node</typeparam>
    public class WeightedGraph<NodeType, ValueType> : BaseGraph<NodeType, ValueType>, IWeightedGraph<NodeType, ValueType> where NodeType : INode<ValueType>
    {
        public WeightedGraph() : base()
        {
            Vertices = new();
        }

        public VertexCollection Vertices { get; }

        public IVertex GetVertex(NodeType currentNode, NodeType nextNode)
        {
            return Vertices.FindVertex(currentNode, nextNode);
        }

        /// <summary>
        /// Links given two nodes with default weight of 0
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public override void LinkNode(NodeType source, NodeType destination)
            => LinkNode(source, destination, 0);

        /// <summary>
        /// Links given two nodes with given <paramref name="weight"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public virtual void LinkNode(NodeType source, NodeType destination, int weight)
        {
            if (!Nodes.Contains(destination.Value))
                Nodes.Add(destination);

            Nodes[source.Value].Children.Add(destination.Value);
            Nodes[destination.Value].Children.Add(source.Value);

            IVertex newVertex = new Vertex(weight, source, destination);
            IVertex newVertex2 = new Vertex(weight, destination, source);
            Vertices.Add(newVertex);
            Vertices.Add(newVertex2);
        }

        public override string ToString()
        {
            return $"Nodes = {Nodes.Count}";
        }
    }
}
