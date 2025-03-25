using DataStructures.Graphs.Nodes;
using DataStructures.Graphs.Nodes.Interfaces;

namespace DataStructures.Graphs.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type of node</typeparam>
    public class BaseWeightedGraph<T> : IWeightedGraph<T> where T : IWeightedNode
    {
        public BaseWeightedGraph()
        {
            Nodes = new();
            Vertices = new();
        }

        public NodeCollection<T> Nodes { get; }

        public VertexCollection Vertices { get; }

        public virtual void CreateNode(T node)
        {
            Nodes.Add(node);
        }

        public virtual void LinkNode(T source, T destination)
        {
            Nodes[source.Value].Add(destination);
            Nodes.Add(destination);
        }

        public override string ToString()
        {
            return $"Nodes = {Nodes.Count}";
        }
    }
}
