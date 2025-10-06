using DataStructures.Linear;
using DesignPatterns.Behavioral.Command.Commands;

namespace DesignPatterns.Behavioral.Command
{
    public static class CommandManager
    {
        private static Stack<ICommand> _stack = new();
        public static void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _stack.Push(command);
        }

        public static void UndoCommand()
        {
            var command = _stack.Pop();
            command.Undo();
        }
    }
}
