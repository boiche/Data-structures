using DataStructures.Graphs.Nodes.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    public class VertexCollection
    {
        private Dictionary<IVerticy, Tuple<INode, INode>> _verticies;

        public int Count { get => _verticies.Count; }

        public VertexCollection()
        {
            _verticies = [];
        }

        public Tuple<INode, INode> this[IVerticy index]
        {
            get { return _verticies[index]; }
            set { _verticies[index] = value; }
        }

        internal void Add(IVerticy node, INode first, INode second)
        {
            _verticies.Add(node, new Tuple<INode, INode>(first, second));
        }

        internal void Remove(IVerticy node)
        {
            _verticies.Remove(node);
        }
    }
}
