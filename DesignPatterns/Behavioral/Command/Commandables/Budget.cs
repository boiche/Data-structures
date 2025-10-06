using DesignPatterns.Behavioral.Command.Incrementables;

namespace DesignPatterns.Behavioral.Command.Commandables
{
    public class Budget
    {
        private DecimalIncrementable _reserve = new();
        private DecimalIncrementable _netIncome = new();
        public DecimalIncrementable Reserve { get => _reserve; }
        public DecimalIncrementable NetIncome { get => _netIncome; }
    }
}
