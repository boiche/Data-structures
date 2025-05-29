namespace DataStructures.Trees.Enumerators.BinaryTree.Interfaces
{
    public interface IBinaryTreeEnumerable<T>
    {
        public IBinaryTreeEnumerator<T> GetEnumerator();
    }
}
