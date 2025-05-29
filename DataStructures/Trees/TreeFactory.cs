using DataStructures.Trees.Interfaces;
using DataStructures.Trees.Nodes;
using DataStructures.Trees.Nodes.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    /// <summary>
    /// Provides methods for building <see cref="BaseTree{T}"/>
    /// </summary>
    /// <typeparam name="T">Node's value type</typeparam>
    public static class TreeFactory<T>
    {
        /// <summary>
        /// Creates <see cref="BaseTree{T}"/> in the format [X, Y] (edge definition between nodes X and Y)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>        
        public static BaseTree<T> FromAdjacencyArray(T[][] values)
        {
            Dictionary<T, ITreeNode<T>> nodes = [];
            Tree<T> result = null;
            foreach (T[] item in values)
            {
                if (item.Length != 2)
                    throw new InvalidOperationException("Edge definition must have exactly 2 values");

                TreeNode<T> first = new TreeNode<T>(item[0]);
                TreeNode<T> second = new TreeNode<T>(item[1]);

                result ??= new(first);

                if (nodes.TryGetValue(item[0], out ITreeNode<T> value))
                {
                    value.Children.Add(second);
                }
                else
                {
                    first.Children.Add(second);
                    nodes.Add(item[0], first);
                    result.Count++;
                }

                if (nodes.TryGetValue(item[1], out value))
                {
                    value.Children.Add(first);
                }
                else
                {
                    second.Children.Add(first);
                    nodes.Add(item[1], second);
                    result.Count++;
                }
            }

            // the root of the tree is counted twice
            result.Count--;

            return result;
        }
    }
}
