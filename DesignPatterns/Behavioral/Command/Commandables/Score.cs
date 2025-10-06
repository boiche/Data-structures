namespace DesignPatterns.Behavioral.Command.Incrementables
{
    public class Score
    {
        private IntIncrementable _score = new();
        public IntIncrementable Value { get => _score; }
    }
}
