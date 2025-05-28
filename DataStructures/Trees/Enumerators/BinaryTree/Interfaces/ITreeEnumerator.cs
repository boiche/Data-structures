using DataStructures.Trees.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Trees.Enumerators.BinaryTree.Interfaces
{
    public interface ITreeEnumerator<T> : IEnumerator<T>
    {
        public ITreeNode<T> CurrentNode { get; }
    }
}
