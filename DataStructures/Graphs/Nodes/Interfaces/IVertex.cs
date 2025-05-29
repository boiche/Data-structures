using System;

namespace DataStructures.Graphs.Nodes.Interfaces
{
    /// <summary>
    /// Represents weighted graph vertex
    /// </summary>
    public interface IVertex
    {
        public int Weight { get; }
        public Tuple<INode, INode> LinkedNodes { get; }
    }
}
