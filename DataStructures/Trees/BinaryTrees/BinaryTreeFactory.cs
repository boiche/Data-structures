using DataStructures.Trees.Interfaces;
using DataStructures.Trees.Nodes;
using System;
using System.Collections.Generic;

namespace DataStructures.Trees.BinaryTrees
{
    /// <summary>
    /// Provides methods for building <see cref="DataStructures.Trees.Interfaces.BaseBinaryTree{T}"/>
    /// </summary>
    /// <typeparam name="T">Node's value type</typeparam>
    public static class BinaryTreeFactory<T>
    {
        /// <summary>
        /// Creates a <see cref="BaseBinaryTree{T}"/> in the format [X, Y, Z] (X: root, Y: leftChild, Z: rightChild)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>        
#nullable enable
        public static BaseBinaryTree<T> FromLevelOrder(T?[] values)
        {
            ArgumentNullException.ThrowIfNull(values);
            BinaryTree<T> result = new();
            throw new NotImplementedException();

            //BinaryTreeNode<T> treeNode;
            //IEnumerator<T> enumerator = _source.GetEnumerator();
            //if (!enumerator.MoveNext())
            //{
            //    treeNode = new BinaryTreeNode<T>(default);
            //    root = treeNode;
            //    return;
            //}

            //Queue<BinaryTreeNode<T>> queue = new();
            //queue.Enqueue(new BinaryTreeNode<T>(enumerator.Current));

            //while (queue.Count > 0)
            //{
            //    var current = queue.Dequeue();

            //    if (root == null)
            //        root = current;

            //    BinaryTreeNode<T> left = null, right = null;
            //    if (enumerator.MoveNext())
            //    {
            //        left = new BinaryTreeNode<T>(enumerator.Current);
            //        queue.Enqueue(left);
            //    }
            //    if (enumerator.MoveNext())
            //    {
            //        right = new BinaryTreeNode<T>(enumerator.Current);
            //        queue.Enqueue(right);
            //    }

            //    current.LeftNode = left;
            //    current.RightNode = right;
            //}
        }
#nullable disable
    }
}
