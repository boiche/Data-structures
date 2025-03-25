using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
