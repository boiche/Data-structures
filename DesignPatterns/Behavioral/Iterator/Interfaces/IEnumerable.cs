namespace DesignPatterns.Behavioral.Iterator.Interfaces
{
    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}
