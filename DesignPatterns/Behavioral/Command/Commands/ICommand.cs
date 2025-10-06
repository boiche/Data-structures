namespace DesignPatterns.Behavioral.Command.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
