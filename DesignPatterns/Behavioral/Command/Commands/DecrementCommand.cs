using DesignPatterns.Behavioral.Command.Incrementables;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class DecrementCommand<T> : BaseCommand<T>, ICommand
    {
        private readonly T _arg;

        public DecrementCommand(IIncrementable<T> receiver, T arg) : base(receiver)
        {
            this._arg = arg;
        }

        public void Execute()
        {
            _receiver.Decrement(_arg);
        }

        public void Undo()
        {
            var undoCommand = new IncrementCommand<T>(_receiver, _arg);
            undoCommand.Execute();
        }
    }
}
