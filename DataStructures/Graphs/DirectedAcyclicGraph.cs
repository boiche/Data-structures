using DataStructures.Graphs.Interfaces;
using DataStructures.Graphs.Nodes;
using DataStructures.Graphs.Nodes.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Graph that supports single direction between nodes and no cycles
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DirectedAcyclicGraph<T> : BaseGraph<T>
    {
        private new Dictionary<T, INode<T>> _source;        
        public override int Count { get => _source.Count; }
        public INode<T> this[T node]
        {
            get { return _source[node]; }
        }

        public DirectedAcyclicGraph()
        {
            _source = new();
        }

        /// <summary>
        /// Creates new node with no <seealso cref="INode{T}.Children"/>
        /// </summary>
        /// <param name="node"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void CreateNode(T node)
        {
            ArgumentNullException.ThrowIfNull(node);

            if (_source.ContainsKey(node))
                throw new InvalidOperationException("Node with the same value exists");

            _source.Add(node, new Node<T>(node));
        }

        /// <summary>
        /// Links two nodes within the graph. If <paramref name="newNode"/> is missing, it will be created
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void Link(T node, T newNode)
        {
            ArgumentNullException.ThrowIfNull(node);
            ArgumentNullException.ThrowIfNull(newNode);

            if (!_source.TryGetValue(node, out INode<T> value))
                throw new KeyNotFoundException();

            try
            {
                value.Children.Add(newNode);
                _source.TryAdd(newNode, new Node<T>(newNode));
                TopologicalSort();
            }
            catch (Exception)
            {
                value.Children.Remove(newNode);
                _source.Remove(newNode);
                throw;
            }
        }

        /// <summary>
        /// Performs topological sort over the graph
        /// <para>Order of output depends on the order of creation. The least recent created nodes will appear first</para>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<T> TopologicalSort()
        {
            List<T> result = [];
            Queue<T> queue = [];

            Dictionary<T, int> inDegree = FindInDegree();

            foreach (var item in inDegree)
            {
                if (item.Value == 0)
                {
                    queue.Enqueue(item.Key);
                }
            }

            while (queue.Count > 0)
            {
                T node = queue.Dequeue();
                result.Add(node);

                foreach (var neighbour in _source[node].Children)
                {
                    inDegree[neighbour]--;
                    if (inDegree[neighbour] == 0)
                        queue.Enqueue(neighbour);
                }
            }

            if (result.Count != Count)
                throw new Exception("Cycle detected");

            return result;
        }

        /// <summary>
        /// Generates data for in-degree (nodes pointing) count of each node
        /// </summary>
        /// <returns></returns>
        private Dictionary<T, int> FindInDegree()
        {
            Dictionary<T, int> result = [];
            foreach (var node in _source.Keys)
            {
                result.Add(node, 0);
            }

            foreach (var neighbours in _source)
            {
                foreach (var neighbour in neighbours.Value.Children)
                {
                    result[neighbour]++;
                }
            }

            return result;
        }
    }
}
