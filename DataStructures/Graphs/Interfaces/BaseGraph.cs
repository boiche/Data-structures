using DataStructures.Graphs.Nodes.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    public abstract class BaseGraph<T, V> : IGraph<T, V> where T : INode<V>
    {
        protected IEnumerable<T> _source;
        public NodeCollection<T, V> Nodes { get; }

        protected BaseGraph()
        {
            Nodes = new();
        }

        public virtual void CreateNode(T node)
        {
            Nodes.Add(node);
        }
        public virtual void CreateNode(V node)
        {
            Nodes.Add(CreateInstance(node));
        }
        public virtual void LinkNode(T source, T destination)
        {
            if (!Nodes.Contains(destination.Value))
                Nodes.Add(destination);

            Nodes[source.Value].Children.Add(destination.Value);            
        }

        public override string ToString()
        {
            return $"Nodes = {Nodes.Count}";
        }
        private protected static T CreateInstance(V value)
        {
            return (T)Activator.CreateInstance(typeof(T), [value]);
        }
    }
}
