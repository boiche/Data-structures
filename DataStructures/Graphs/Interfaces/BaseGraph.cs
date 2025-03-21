using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    public abstract class BaseGraph<T> : IGraph<T>
    {
        protected IEnumerable<T> _source;
        public virtual int Count { get; }
    }
}
