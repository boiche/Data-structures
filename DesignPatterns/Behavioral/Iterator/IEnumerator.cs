namespace DesignPatterns.Behavioral.Iterator
{
    public interface IEnumerator
    {
        object Current { get; }
        bool MoveNext();
        void Reset();
    }
}
