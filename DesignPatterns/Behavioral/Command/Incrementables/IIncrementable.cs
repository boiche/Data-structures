namespace DesignPatterns.Behavioral.Command.Incrementables
{
    public interface IIncrementable<T>
    {
        void Increment(T n);
        void Decrement(T n);

    }
}
