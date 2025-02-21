using DataStructures.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Recursive.Graphs.Interfaces
{
    public abstract class BaseGraph<T> : IGraph<T>
    {
        protected IEnumerable<T> _source;
        public int Count { get; }
    }
}
