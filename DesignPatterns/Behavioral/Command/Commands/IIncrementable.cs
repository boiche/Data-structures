namespace DesignPatterns.Behavioral.Command.Commands
{
    public interface IIncrementable<T>
    {
        void Increment(T n);
        void Decrement(T n);

    }
}
