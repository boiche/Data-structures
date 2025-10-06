using DesignPatterns.Behavioral.Command.Commands;

namespace DesignPatterns.Behavioral.Command.Incrementables
{
    public class DecimalIncrementable : IIncrementable<decimal>
    {
        private decimal _value;
        public decimal Value { get => _value; }
        public void Decrement(decimal n)
        {
            _value -= n;
        }

        public void Increment(decimal n)
        {
            _value += n;
        }
    }
}
