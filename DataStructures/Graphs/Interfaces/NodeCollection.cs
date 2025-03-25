using DataStructures.Graphs.Nodes.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    /// <summary>
    /// Represents the collection of nodes in <see cref="IGraph{T}"/>
    /// </summary>
    /// <typeparam name="T">Type of node</typeparam>
    /// <typeparam name="I">Type of node's identification</typeparam>
    public class NodeCollection<T> where T : INode
    {
        private Dictionary<object, List<T>> source;

        public int Count { get => source.Count; }

        public NodeCollection()
        {
            source = [];
        }

        public List<T> this[object index]
        {
            get { return source[index]; }
            set { source[index] = value; }
        }

        internal void Add(T node)
        {
            source.Add(node.Value, []);
        }

        internal void Remove(T node)
        {
            source.Remove(node);
        }
    }
}
