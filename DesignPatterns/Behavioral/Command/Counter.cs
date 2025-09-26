using DesignPatterns.Behavioral.Command.Commands;

namespace DesignPatterns.Behavioral.Command
{
    public sealed class Counter : IIncrementable
    {
        private int _score = 0;
    }
}
