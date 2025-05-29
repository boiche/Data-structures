using DataStructures.Trees.Nodes.Interfaces;

namespace DataStructures.Trees.Nodes
{
    public class BinaryTreeNode<T> : TreeNode<T>, IBinaryTreeNode<T>
    {
        public IBinaryTreeNode<T> LeftNode { get; set; }
        public IBinaryTreeNode<T> RightNode { get; set; }
        public override bool IsLeaf { get => LeftNode is null && RightNode is null; }

        public BinaryTreeNode(T value) : base(value)
        {
            LeftNode = null;
            RightNode = null;
        }

        internal static int GetChildren(IBinaryTreeNode<T> current)
        {
            if (current == null)
                return 0;

            int result = 0;
            if (current.LeftNode != null)
                result++;
            if (current.RightNode != null)
                result++;

            return GetChildren(current.LeftNode) + GetChildren(current.RightNode) + result;
        }
    }
}
