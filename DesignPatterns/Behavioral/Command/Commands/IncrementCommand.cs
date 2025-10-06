namespace DesignPatterns.Behavioral.Command.Commands
{
    public class IncrementCommand<T> : BaseCommand<T>, ICommand
    {
        private readonly T _arg;

        public IncrementCommand(IIncrementable<T> receiver, T arg) : base(receiver)
        {
            this._arg = arg;
        }


        public void Execute()
        {
            _receiver.Increment(_arg);
        }

        public void Undo()
        {
            var undoCommand = new DecrementCommand<T>(_receiver, _arg);
            undoCommand.Execute();
        }
    }
}
