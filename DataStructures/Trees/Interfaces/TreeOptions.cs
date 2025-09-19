namespace DataStructures.Trees.Interfaces
{
    public class TreeOptions
    {
        public Traverse Traverse { get; set; }
    }

    public enum Traverse
    {
        /// <summary>
        /// Root-Left-Right
        /// </summary>
        Preorder,
        /// <summary>
        /// Left-Right-Root
        /// </summary>
        Postorder,
        /// <summary>
        /// Left-Root-Right
        /// </summary>
        Inorder,
        /// <summary>
        /// BFS
        /// </summary>
        LevelOrder,
        /// <summary>
        /// Left-Root-Right without recursion or stack
        /// </summary>
        Morris
    }
}
