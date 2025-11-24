namespace DesignPatterns.Behavioral.Iterator.Interfaces
{
    public interface IEnumerator<T>
    {
        T Current { get; }
        bool MoveNext();
        void Reset();
    }
}
