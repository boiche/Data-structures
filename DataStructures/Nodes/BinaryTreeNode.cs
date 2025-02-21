using DataStructures.Nodes.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Nodes
{
    public class BinaryTreeNode<T> : TreeNode<T>, IBinaryTreeNode<T>, IComparable<T> where T : IEquatable<T>, IComparable<T>
    {
        public IBinaryTreeNode<T> LeftNode { get; set; }
        public IBinaryTreeNode<T> RightNode { get; set; }
        public override bool IsLeaf { get => LeftNode is null && RightNode is null; }

        public BinaryTreeNode(T value) : base(value)
        {
            LeftNode = null;
            RightNode = null;
        }

        public int CompareTo(T other)
        {
            return Comparer<T>.Default.Compare(Value, other);
        }
    }
}
