using DataStructures.Graphs.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    public abstract class BaseGraph<T> : IGraph<T> where T : INode
    {
        protected IEnumerable<T> _source;
        public NodeCollection<T> Nodes { get; }

        protected BaseGraph()
        {
            Nodes = new();
        }

        public abstract void CreateNode(T node);        
        public abstract void LinkNode(T source, T destination);

        public override string ToString()
        {
            return $"Nodes = {Nodes.Count}";
        }
    }
}
