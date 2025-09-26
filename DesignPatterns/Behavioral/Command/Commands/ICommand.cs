namespace DesignPatterns.Behavioral.Command.Commands
{
    public interface ICommand<T>
    {
        void Execute(T a);
    }

    public interface ICommand<T1, T2>
    {
        void Execute(T1 a, T2 b);
    }
}
