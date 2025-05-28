using DataStructures.Trees.Interfaces;
using DataStructures.Trees.Nodes.Interfaces;

namespace DataStructures.Trees
{
    public class Tree<T> : BaseTree<T>
    {
        public Tree(ITreeNode<T> root) : base(root) { }

        public override void AddComponent(T item)
        {
            throw new System.NotImplementedException();
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
