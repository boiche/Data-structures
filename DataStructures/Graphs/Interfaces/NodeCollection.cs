using DataStructures.Graphs.Nodes.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Graphs.Interfaces
{
    /// <summary>
    /// Represents the collection of nodes in <see cref="IGraph{NodeType, ValueType}"/>
    /// </summary>
    public class NodeCollection<NodeType, ValueType> : IEnumerable<NodeType> where NodeType : INode<ValueType>
    {
        private Dictionary<ValueType, NodeType> source;

        public int Count { get => source.Count; }

        public NodeCollection()
        {
            source = [];
        }

        public NodeType this[ValueType nodeValue]
        {
            get { return source[nodeValue]; }
            set { source[nodeValue] = value; }
        }

        public bool Contains(ValueType value)
        {
            return source.ContainsKey(value);
        }

        internal void Add(NodeType node)
        {
            source.Add(node.Value, node);
        }

        internal void Remove(NodeType node)
        {
            source.Remove(node.Value);
        }

        public IEnumerator<NodeType> GetEnumerator()
        {
            return source.Select(x => x.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
