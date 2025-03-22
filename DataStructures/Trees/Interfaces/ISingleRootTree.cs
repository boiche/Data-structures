using DataStructures.Trees.Nodes.Interfaces;

namespace DataStructures.Trees.Interfaces
{
    /// <summary>
    /// Marks current tree structure to have only one root
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISingleRootTree<T> where T : ITreeNode
    {
        public T Root { get; }
    }
}
