namespace DataStructures.Recursive.Trees.Interfaces
{
    public class TreeOptions
    {
        public Traverse Traverse { get; set; }
    }

    public enum Traverse
    {
        Preorder,
        Postorder,
        Inorder,
        LevelOrder
    }
}
