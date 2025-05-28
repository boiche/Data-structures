using DataStructures.Trees.Interfaces;
using DataStructures.Trees.Nodes;
using DataStructures.Trees.Nodes.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataStructures.Trees
{
    /// <summary>
    /// Stores collection of <see cref="string"/> in common-prefix tree-like structure
    /// </summary>
    public class Trie : BaseTree<int>
    {
        /// <summary>
        /// The default root node. This node doesn't store data for the values of the tree
        /// </summary>
        private new TrieNode _root = new TrieNode();
        public new TrieNode Root { get => _root; } // Trie will have two Root properties in debug. DebuggerTypeProxy can handle it. Define model class, that will provide properties/field that are browsable for current type

        public Trie() : base(new List<int>()) { }
        public Trie(List<string> source) : base(source) 
        {
            BuildTree();
        }

        protected void BuildTree()
        {
            foreach (var item in temp_source)
            {
                Insert(item.ToString());
            }
        }

        /// <summary>
        /// Merges a new word into the tree
        /// </summary>
        /// <param name="value"></param>
        public void Insert(string value)
        {
            TrieNode node = _root;
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

        /// <summary>
        /// Looks for a word in the tree
        /// </summary>
        /// <param name="value">Search term</param>
        /// <returns>Whether the word is present in the tree</returns>
        public bool Find(string value)
        {
            TrieNode node = _root;

            for (int i = 0; i < value.Length; i++)
            {
                if (!node.Children.TryGetValue(value[i], out TrieNode child))
                    return false;

                node = child;
            }

            return node.Value > 0;
        }

        /// <summary>
        /// Removes a word from the tree
        /// </summary>
        /// <param name="value">Word to remove</param>
        /// <returns>Whether the word is removed</returns>
        public bool Remove(string value) 
        {
            TrieNode current = _root;
            TrieNode last_branch_node = null;
            char last_branch_char = 'a';

            foreach (char c in value)
            {
                if (current.Children[c] == null)
                {
                    return false;
                }
                else
                {
                    int count = current.Children.Count;

                    if (count > 1)
                    {
                        last_branch_node = current;
                        last_branch_char = c;
                    }

                    current = current.Children[c];
                }
            }

            int wordCount = 0;
            foreach (var child in current.Children)
            {
                wordCount += child.Value.Value;
            }

            if (wordCount > 0)
            {
                current.Value--;
                return true;
            }

            if (last_branch_node != null)
            {
                last_branch_node.Children[last_branch_char] = null;
                return true;
            }

            else
            {
                Root.Children[value[0]] = null;
                return true;
            }
        }

        // not fine instructing to pass explicitly casted char to int, but made as a workaround
        /// <summary>
        /// Appends single character to the root of the tree. <para>Character should be passed as int</para>
        /// </summary>
        /// <param name="item"></param>
        public override void AddComponent(int item)
        {
            if (!_root.Children.ContainsKey((char)item))
                _root.Children.Add((char)item, new() { Value = 1 });
        }

        public override void Remove(int item)
        {
            throw new NotImplementedException();
        }
    }
}
