namespace DesignPatterns.Behavioral.Command.Commands
{
    public interface IIncrementable<T> where T : unmanaged
    {
        void Increment(T n);
        void Decrement(T n);
    }
}
