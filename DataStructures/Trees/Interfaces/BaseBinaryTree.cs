using DataStructures.Recursive.Enumerators.BinaryTree;
using DataStructures.Trees.Enumerators.BinaryTree;
using DataStructures.Trees.Nodes;
using DataStructures.Trees.Nodes.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Trees.Interfaces
{
    public abstract class BaseBinaryTree<T> : BaseTree<T>, ISingleRootTree<IBinaryTreeNode<T>>
    {
        protected BaseBinaryTree(IEnumerable<T> source, TreeOptions options) : base(source) 
        {
            this.options = options;
        }

        protected TreeOptions options;
        protected IBinaryTreeNode<T> current;
        protected IBinaryTreeNode<T> previous;
        protected IBinaryTreeNode<T> root;
        public IBinaryTreeNode<T> Root { get => root; }
        public abstract IBinaryTreeNode<T> Find(T item);
        public abstract void Add(T item);
        public abstract bool Remove(T item);

        protected override void BuildTree()
        {
            BinaryTreeNode<T> treeNode;
            IEnumerator<T> enumerator = _source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                treeNode = new BinaryTreeNode<T>(default);
                root = treeNode;
                return;
            }

            Queue<BinaryTreeNode<T>> queue = new();
            queue.Enqueue(new BinaryTreeNode<T>(enumerator.Current));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (root == null)
                    root = current;

                BinaryTreeNode<T> left = null, right = null;
                if (enumerator.MoveNext())
                {
                    left = new BinaryTreeNode<T>(enumerator.Current);
                    queue.Enqueue(left);
                }
                if (enumerator.MoveNext())
                {
                    right = new BinaryTreeNode<T>(enumerator.Current);
                    queue.Enqueue(right);
                }

                current.LeftNode = left;
                current.RightNode = right;
            }
        }

        /// <summary>
        /// Finds the smallest item from given node as a root of subtree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>The smallest node found</returns>
        protected virtual IBinaryTreeNode<T> GetMin(IBinaryTreeNode<T> root)
        {
            if (root.LeftNode == null) return null;
            IBinaryTreeNode<T> min = root.LeftNode;
            while (min.LeftNode != null)
                min = min.LeftNode;
            return min;
        }
        /// <summary>
        /// Finds the greatest item from given node as a root of subtree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>The greatest node found</returns>
        protected virtual IBinaryTreeNode<T> GetMax(IBinaryTreeNode<T> root)
        {
            if (root.RightNode == null) return null;
            IBinaryTreeNode<T> max = root.RightNode;
            while (max.RightNode != null)
                max = max.RightNode;
            return max;
        }
        /// <summary>
        /// Finds the smallest item from given node as a root of subtree. Searches only in the right subtree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>The smallest node found</returns>
        protected virtual IBinaryTreeNode<T> GetMinFromRight(IBinaryTreeNode<T> root)
        {
            if (root.RightNode == null) return null;
            IBinaryTreeNode<T> min = root.RightNode;
            while (min.LeftNode != null)
                min = min.LeftNode;
            return min;
        }
        /// <summary>
        /// Finds the greatest item from given node as a root of subtree. Searches only in left subtree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>The greatest node found</returns>
        /// <exception cref="InvalidOperationException"></exception>
        protected virtual IBinaryTreeNode<T> GetMaxFromLeft(IBinaryTreeNode<T> root)
        {
            if (root.LeftNode == null) return null;
            IBinaryTreeNode<T> max = root.LeftNode;
            while (max.RightNode != null)
                max = max.RightNode;
            return max;
        }
        /// <summary>
        /// Finds the height of the provided <see cref="IBinaryTreeNode{T}"/>
        /// </summary>
        /// <param name="node"></param>
        /// <returns>The height of the subtree</returns>
        protected int GetHeight(IBinaryTreeNode<T> node)
        {
            if (node is null)
            {
                return 0;
            }

            return 1 + Math.Max(GetHeight(node.LeftNode), GetHeight(node.RightNode));
        }
        protected void SetTraversor()
        {
            switch (options.Traverse)
            {
                case Traverse.Preorder:
                    _traversor = new PreorderTraversor<T>(root);
                    break;
                case Traverse.Postorder:
                    _traversor = new PostorderTraversor<T>(root);
                    break;
                case Traverse.Inorder:
                    _traversor = new InorderTraversor<T>(root);
                    break;
                case Traverse.LevelOrder:
                    _traversor = new LevelOrderTraversor<T>(root);
                    break;
                case Traverse.Morris:
                    _traversor = new MorrisTraversor<T>(root);
                    break;
            }
        }
    }
}
