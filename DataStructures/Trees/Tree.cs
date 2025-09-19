using DataStructures.Trees.Enumerators.BinaryTree.Interfaces;
using DataStructures.Trees.Interfaces;
using DataStructures.Trees.Nodes;
using DataStructures.Trees.Nodes.Interfaces;

namespace DataStructures.Trees
{
    public class Tree<T> : BaseTree<T>
    {
        public Tree(ITreeNode<T> root) : base(root) { }

        /// <summary>
        /// Adds new item to the back of the tree
        /// </summary>
        /// <param name="item"></param>
        public override void Add(T item)
        {
            ITreeEnumerator<T> enumerator = GetEnumerator();
            ITreeNode<T> lastNode = enumerator.CurrentNode;

            while (enumerator.MoveNext())
            {
                lastNode = enumerator.CurrentNode;
            }

            lastNode.Children.Add(new TreeNode<T>(item));
            Count++;
        }

        /// <summary>
        /// Removes all occurances of nodes with <paramref name="value"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Remove(T value)
        {
            throw new System.NotImplementedException();
        }
    }
}
