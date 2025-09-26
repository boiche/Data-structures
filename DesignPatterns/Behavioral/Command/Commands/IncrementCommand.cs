namespace DesignPatterns.Behavioral.Command.Commands
{
    public class IncrementCommand<T> : ICommand<T> where T : unmanaged
    {
        private readonly IIncrementable<T> receiver;

        public IncrementCommand(IIncrementable<T> receiver)
        {
            this.receiver = receiver;
        }
        public void Execute(T arg)
        {
            receiver.Increment(arg);            
        }
    }
}
