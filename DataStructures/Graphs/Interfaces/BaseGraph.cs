using DataStructures.Graphs.Nodes.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    /// <summary>
    /// Represents the base of a graph
    /// </summary>
    /// <typeparam name="T">Node's type</typeparam>
    /// <typeparam name="V">Node's value type</typeparam>
    public abstract class BaseGraph<T, V> : IGraph<T, V> where T : INode<V>
    {
        protected IEnumerable<T> _source;
        protected int _components;
        /// <summary>
        /// Contains all nodes within current graph
        /// </summary>
        public NodeCollection<T, V> Nodes { get; }
        /// <summary>
        /// Keeps track of count of individual graph components
        /// </summary>
        public int Components { get => _components; }

        protected BaseGraph()
        {
            Nodes = new();
            _components = 0;
        }

        /// <summary>
        /// Creates new node and adds it as an individual component
        /// </summary>
        /// <param name="node"></param>
        public virtual void CreateNode(T node)
        {
            _components++;
            Nodes.Add(node);
        }
        /// <summary>
        /// Adds predefined node to the graph as an individual component
        /// </summary>
        /// <param name="node"></param>
        public virtual void CreateNode(V node)
        {
            _components++;
            Nodes.Add(CreateInstance(node));
        }
        /// <summary>
        /// Creates an edge between <paramref name="source"/> and <paramref name="destination"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
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
        /// <summary>
        /// Calls the default constructor of node <see cref="V"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private protected static T CreateInstance(V value)
        {
            return (T)Activator.CreateInstance(typeof(T), [value]);
        }
    }
}
