using DesignPatterns.Behavioral.Command.Incrementables;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public abstract class BaseCommand<T>
    {
        protected readonly IIncrementable<T> _receiver;
        public BaseCommand(IIncrementable<T> receiver)
        {
            this._receiver = receiver;
        }
    }
}
