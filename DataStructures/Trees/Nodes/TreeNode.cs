using DataStructures.Trees.Nodes.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Trees.Nodes
{
    public abstract class TreeNode<T> : ITreeNode<T>
    {
        public T Value { get; set; }
        public IList<ITreeNode<T>> Children { get; internal set; }
        public virtual bool IsLeaf { get => Children.Any(); }

        public TreeNode(T value)
        {
            Value = value;
            Children = new List<ITreeNode<T>>();
        }
    }
}
