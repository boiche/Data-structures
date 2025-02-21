using DataStructures.Nodes;
using DataStructures.Nodes.Interfaces;
using DataStructures.Recursive.Trees.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Recursive.Trees.BinaryTrees
{
    public class BinaryTree<T> : BaseBinaryTree<T> where T : IEquatable<T>, IComparable<T>
    {
        public BinaryTree(List<T> source) : this(source, new TreeOptions()) { }        
        public BinaryTree(List<T> source, TreeOptions options) : base(source)
        {
            this.source = source;
            BuildTree();
            SetTraversor(options);
            Count = source.Count;
        }        

        /// <summary>
        /// Searches for specific item in the binary tree.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The node if the value is present in the tree. Null vice versa.</returns>
        public override IBinaryTreeNode<T> Find(T item)
        {
            if (current == null) current = Root;
            int result = current.Value.CompareTo(item);
            if (result > 0)
            {
                if (current.LeftNode == null)
                {
                    current = null;
                    return default;
                }
                else
                {
                    current = current.LeftNode;
                    return Find(current.Value);
                }
            }
            else if (result < 0)
            {
                if (current.RightNode == null)
                {
                    current = null;
                    return default;
                }
                else
                {
                    current = current.RightNode;
                    return Find(current.Value);
                }
            }
            else
            {
                current = null;
                return current;
            }
        }

        /// <summary>
        /// Add new item to the tree.
        /// </summary>
        /// <param name="item"></param>
        public override void Add(T item)
        {
            if (Root == null)
            {
                root = new BinaryTreeNode<T>(item);
                Count++;
                return;
            }
            if (current == null) current = Root;
            int result = current.Value.CompareTo(item);
            if (result > 0) //move left
            {
                if (current.LeftNode == null)
                {
                    current.LeftNode = new BinaryTreeNode<T>(item);
                    Count++;
                    return;
                }
                else
                {
                    current = current.LeftNode;
                    Add(item);
                }
            }
            else if (result < 0) //move right
            {
                if (current.RightNode == null)
                {
                    current.RightNode = new BinaryTreeNode<T>(item);
                    Count++;
                    return;
                }
                else
                {
                    current = current.RightNode;
                    Add(item);
                }
            }
            else
            {
                throw new InvalidOperationException("Balanced binary tree doesn't allow duplicates.");
            }
        }

        /// <summary>
        /// Remove item from the tree.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Is an item removed from the tree</returns>
        public override bool Remove(T item)
        {
            if (current == null) current = Root;
            if (item == null) return false;

            if (current.Value.CompareTo(item) > 0) //move to the left
            {
                previous = current;
                current = current.LeftNode;
                return Remove(current.LeftNode.Value);
            }
            else if (current.Value.CompareTo(item) == 0) //item found
            {
                if (current.IsLeaf)
                {
                    if (previous.LeftNode == current) //it was left leaf
                        previous.LeftNode = null;
                    else //it was right leaf
                        previous.RightNode = null;
                }
                else
                {
                    if (current.LeftNode is null)
                        previous.RightNode = current.RightNode;
                    else if (current.RightNode is null)
                        previous.LeftNode = current.LeftNode;
                    else
                    {
                        IBinaryTreeNode<T> subTreeRoot = current;
                        do
                        {
                            var minRight = GetMinFromRight(subTreeRoot);
                            if (minRight.IsLeaf)
                            {
                                subTreeRoot.LeftNode = null; //removes minRight as left node when it's a leaf
                                break;
                            }
                            T temp = current.Value;
                            current.Value = minRight.Value;
                            minRight.Value = temp;
                            subTreeRoot = minRight;
                        } while (true);
                    }
                }
                return true;
            }
            else //move to the right
            {
                previous = current;
                current = current.RightNode;
                return Remove(current.RightNode.Value);
            }
        }
    }
}
