using DataStructures.Trees.Interfaces;
using DataStructures.Trees.Nodes;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    /// <summary>
    /// Stores collection of <see cref="string"/> in common-prefix tree-like structure
    /// </summary>
    public class Trie : BaseTree<int>
    {
        private TrieNode _root = new TrieNode();
        /// <summary>
        /// The default root node. This node doesn't store data for the values of the tree
        /// </summary>
        public override TrieNode Root => _root;

        public Trie() : base(new List<int>()) { }        
        public Trie(List<string> source) : base(source) 
        {
            BuildTree();
        }

        protected override void BuildTree()
        {
            foreach (var item in temp_source)
            {
                Insert(item.ToString());
            }
        }

        public void Insert(string value)
        {
            TrieNode node = Root;
            for (var i = 0; i < value.Length; i++)
            {
                if (!node.Children.TryGetValue(value[i], out _))
                {
                    node.Children.Add(value[i], new TrieNode());             
                }
                
                node = node.Children[value[i]];
            }

            node.Value++;
        }

        public bool Find(string value)
        {
            TrieNode node = Root;

            for (int i = 0; i < value.Length; i++)
            {
                if (!node.Children.TryGetValue(value[i], out TrieNode child))
                    return false;

                node = child;
            }

            return node.Value > 0;
        }

        public bool Remove(string value) 
        {
            TrieNode current = Root;
            TrieNode last_branch_node = null;
            char last_branch_char = 'a';

            // loop through each character in the word
            foreach (char c in value)
            {
                // if the current node doesn't have a child with the current character,
                // return False as the word is not present in Trie
                if (current.Children[c] == null)
                {
                    return false;
                }
                else
                {
                    int count = current.Children.Count;

                    // if the count of children is more than 1,
                    // store the node and the current character
                    if (count > 1)
                    {
                        last_branch_node = current;
                        last_branch_char = c;
                    }

                    current = current.Children[c];
                }
            }

            int wordCount = 0;
            // count the number of children nodes of the current node
            foreach (var child in current.Children)
            {
                wordCount += child.Value.Value;
            }

            // Case 1: The deleted word is a prefix of other words in Trie
            if (wordCount > 0)
            {
                current.Value--;
                return true;
            }

            // Case 2: The deleted word shares a common prefix with other words in Trie
            if (last_branch_node != null)
            {
                last_branch_node.Children[last_branch_char] = null;
                return true;
            }

            // Case 3: The deleted word does not share any common prefix with other words in Trie
            else
            {
                Root.Children[value[0]] = null;
                return true;
            }
        }
    }
}
