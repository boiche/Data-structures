using DesignPatterns.Behavioral.Command.Commands;

namespace DesignPatterns.Behavioral.Command
{
    public static class CommandManager
    {
        public static void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}
