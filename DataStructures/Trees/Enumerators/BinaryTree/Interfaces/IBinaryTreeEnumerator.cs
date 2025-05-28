using DataStructures.Trees.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Trees.Enumerators.BinaryTree.Interfaces
{
    public interface IBinaryTreeEnumerator<T> : IEnumerator<T>
    {
        public IBinaryTreeNode<T> CurrentNode { get; }
    }
}
