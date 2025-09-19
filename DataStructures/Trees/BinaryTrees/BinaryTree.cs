using DataStructures.Linear;
using DataStructures.Recursive.Enumerators.BinaryTree;
using DataStructures.Trees.Interfaces;
using DataStructures.Trees.Nodes;
using DataStructures.Trees.Nodes.Interfaces;

namespace DataStructures.Trees.BinaryTrees
{
    public class BinaryTree<T> : BaseBinaryTree<T>
    {
        public BinaryTree() : this(null, new TreeOptions()) { }
        public BinaryTree(List<T> source) : this(source, new TreeOptions()) { }
        public BinaryTree(List<T> source, TreeOptions options) : base(source, options) { }

        /// <summary>
        /// Searches for specific item in the binary tree.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The node if the value is present in the tree. Null vice versa.</returns>
        public override IBinaryTreeNode<T> Find(T item)
        {
            var enumerator = GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Equals(item))
                    return enumerator.CurrentNode;
            }

            return null;
        }
        public override void Add(T item)
        {
            // TODO: store the last element to avoid iterating the tree on every Add()
            var enumerator = new PreorderTraversor<T>(root);
            IBinaryTreeNode<T> lastNode = enumerator.CurrentNode;
            while (enumerator.MoveNext())
            {
                lastNode = enumerator.CurrentNode;
            }

            if (lastNode is not null)
            {
                if (lastNode.LeftNode is null)
                    lastNode.LeftNode = new BinaryTreeNode<T>(item);
                else
                    lastNode.RightNode = new BinaryTreeNode<T>(item);
            }
            else
            {
                root = new BinaryTreeNode<T>(item);
            }

            BuildTraversor();

            Count++;
        }
        public override void Remove(T value)
        {
            if (value == null || Count == 0)
                return;
            if (Count == 1)
            {
                if (value.Equals(Root.Value))
                {
                    root = default;
                    Count = 0;
                    return;
                }
            }

            Queue<IBinaryTreeNode<T>> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Value.Equals(value))
                {
                    Count -= BinaryTreeNode<T>.GetChildren(current) + 1;
                    current = null;
                }
                else
                {
                    if (current.LeftNode != null)
                        queue.Enqueue(current.LeftNode);
                    if (current.RightNode != null)
                        queue.Enqueue(current.RightNode);
                }
            }
        }
    }
}
