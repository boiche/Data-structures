namespace DesignPatterns.Behavioral.Command.Incrementables
{
    public class IntIncrementable : IIncrementable<int>
    {
        private int _value;
        public int Value { get => _value; }
        public void Decrement(int n)
        {
            _value -= n;
        }

        public void Increment(int n)
        {
            _value += n;
        }
    }
}
