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
    /// <typeparam name="T">Type of node</typeparam>
    /// <typeparam name="V">Type of node's value</typeparam>
    public class DirectedAcyclicGraph<T, V> : BaseGraph<T, V> where T : INode<V>
    {
        private new Dictionary<V, INode<V>> _source;        
        public INode<V> this[V node]
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
        public new void CreateNode(V nodeValue)
        {
            ArgumentNullException.ThrowIfNull(nodeValue);

            if (_source.ContainsKey(nodeValue))
                throw new InvalidOperationException("Node with the same value exists");

            T newNode = (T)Activator.CreateInstance(typeof(T), [nodeValue]);

            _source.Add(nodeValue, newNode);
            Nodes.Add(newNode);
        }

        public override void CreateNode(T node)
        {
            ArgumentNullException.ThrowIfNull(node);

            if (_source.ContainsKey(node.Value))
                throw new InvalidOperationException("Node with the same value exists");

            _source.Add(node.Value, new Node<V>(node.Value));
            Nodes.Add(node);
        }

        /// <summary>
        /// Links two nodes within the graph. If <paramref name="newNode"/> is missing, it will be created
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public override void LinkNode(T node, T newNode)
        {
            ArgumentNullException.ThrowIfNull(node);
            ArgumentNullException.ThrowIfNull(newNode);

            if (!_source.TryGetValue(node.Value, out INode<V> value))
                throw new KeyNotFoundException();

            try
            {
                value.Children.Add(newNode.Value);
                if (!_source.TryAdd(newNode.Value, new Node<V>(newNode.Value)))
                    CreateNode(newNode);
                else
                    Nodes.Add(newNode); //TODO: either make CreateNode bool or make TryAdd create the new node into the Nodes collection (new node is not inserted in the Nodes collection)

                TopologicalSort();
            }
            catch (Exception)
            {
                value.Children.Remove(newNode.Value);
                _source.Remove(newNode.Value);
                Nodes.Remove(newNode);
                throw;
            }
        }

        /// <summary>
        /// Links two nodes within the graph. If <paramref name="newNodeValue"/> is missing, it will be created
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void LinkNode(V nodeValue, V newNodeValue)
        {
            ArgumentNullException.ThrowIfNull(nodeValue);
            ArgumentNullException.ThrowIfNull(newNodeValue);

            if (!_source.TryGetValue(nodeValue, out INode<V> value))
                throw new KeyNotFoundException();

            T newNode = (T)Activator.CreateInstance(typeof(T), [newNodeValue]);

            try
            {
                value.Children.Add(newNodeValue);                
                if (_source.TryAdd(newNodeValue, newNode))
                    Nodes.Add(newNode);

                TopologicalSort();
            }
            catch (Exception)
            {
                value.Children.Remove(newNode.Value);
                _source.Remove(newNode.Value);
                Nodes.Remove(newNode);
                throw;
            }
        }

        /// <summary>
        /// Performs topological sort over the graph
        /// <para>Order of output depends on the order of creation. The least recent created nodes will appear first</para>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<V> TopologicalSort()
        {
            List<V> result = [];
            Queue<V> queue = [];

            Dictionary<V, int> inDegree = FindInDegree();

            foreach (var item in inDegree)
            {
                if (item.Value == 0)
                {
                    queue.Enqueue(item.Key);
                }
            }

            while (queue.Count > 0)
            {
                V nodeValue = queue.Dequeue();
                result.Add(nodeValue);

                foreach (var neighbourValue in _source[nodeValue].Children)
                {
                    inDegree[neighbourValue]--;
                    if (inDegree[neighbourValue] == 0)
                        queue.Enqueue(neighbourValue);
                }
            }

            if (result.Count != Nodes.Count)
                throw new InvalidOperationException("Cycle detected");

            return result;
        }

        /// <summary>
        /// Generates data for in-degree (nodes pointing) count of each node
        /// </summary>
        /// <returns></returns>
        private Dictionary<V, int> FindInDegree()
        {
            Dictionary<V, int> result = [];
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
