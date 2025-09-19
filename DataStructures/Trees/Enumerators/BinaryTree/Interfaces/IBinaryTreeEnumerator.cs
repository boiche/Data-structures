using DataStructures.Trees.Nodes.Interfaces;
using System.Collections.Generic;

namespace DataStructures.Trees.Enumerators.BinaryTree.Interfaces
{
    public interface IBinaryTreeEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// Gets the node in the collection at the current position of the enumerator.
        /// </summary>
        public IBinaryTreeNode<T> CurrentNode { get; }
        /// <summary>
        /// Has the enumerator reached the last node
        /// </summary>
        bool Ended { get; }
    }
}
