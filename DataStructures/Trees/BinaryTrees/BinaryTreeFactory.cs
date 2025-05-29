using DataStructures.Trees.Interfaces;
using System;

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

            BinaryTree<T> result = new([.. values]);
            return result;
        }
#nullable disable
    }
}
