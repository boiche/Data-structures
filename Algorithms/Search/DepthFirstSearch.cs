using DataStructures.Nodes.Interfaces;
using DataStructures.Recursive.Trees.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Search
{
    public static class DepthFirstSearch
    {
        public static IEnumerable<ITreeNode<T>> InorderTraversal<T>(this BaseTree<T> tree) where T : IEquatable<T>, IComparable<T>
        {
            var result = new List<ITreeNode<T>>();

            InorderTraversal(tree.Root, result);

            return result;
        }

        private static void InorderTraversal<T>(ITreeNode<T> node, List<ITreeNode<T>> result)
        {
            if (node == null)
                return;            

            int childrenCount = node.Children.Count;

            for (int i = 0; i < childrenCount / 2; i++)
            {
                InorderTraversal(node.Children[i], result);
            }

            result.Add(node);

            for (int i = childrenCount / 2; i < childrenCount; i++)
            {
                InorderTraversal(node.Children[i], result);
            }
        }

        public static IEnumerable<ITreeNode<T>> PreorderTraversal<T>(this BaseTree<T> tree) where T : IEquatable<T>, IComparable<T>
        {
            var result = new List<ITreeNode<T>>();

            PreorderTraversal(tree.Root, result);

            return result;
        }

        private static void PreorderTraversal<T>(ITreeNode<T> node, List<ITreeNode<T>> result)
        {
            if (node == null)
                return;

            result.Add(node);

            foreach (var item in node.Children)
            {
                PreorderTraversal(item, result);
            }
        }

        public static IEnumerable<ITreeNode<T>> PostorderTraversal<T>(this BaseTree<T> tree) where T : IEquatable<T>, IComparable<T>
        {
            var result = new List<ITreeNode<T>>();

            PostorderTraversal(tree.Root, result);
            result.Add(tree.Root);

            return result;
        }

        private static void PostorderTraversal<T>(ITreeNode<T> node, List<ITreeNode<T>> result)
        {
            if (node.IsLeaf)
            {
                return;
            }

            for (int i = 0; i < node.Children.Count; i++)
            {
                PostorderTraversal(node.Children[i], result);
                result.Add(node.Children[i]);
            }
        }
    }
}
