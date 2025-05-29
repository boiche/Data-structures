using System.Collections.Generic;

namespace DataStructures.Trees.Nodes
{
    public class TrieNode : TreeNode<int>
    {
        public new Dictionary<char, TrieNode> Children { get; }
        /// <summary>
        /// Stores the count of how many words terminate at current node
        /// </summary> 
        public TrieNode() : base(0)
        {
            Children = new();
        }
    }
}
