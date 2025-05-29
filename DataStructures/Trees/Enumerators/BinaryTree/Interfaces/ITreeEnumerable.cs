namespace DataStructures.Trees.Enumerators.BinaryTree.Interfaces
{
    public interface ITreeEnumerable<T>
    {
        public ITreeEnumerator<T> GetEnumerator();
    }
}
