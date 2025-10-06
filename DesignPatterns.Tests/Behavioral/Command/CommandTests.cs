using DesignPatterns.Behavioral.Command;
using DesignPatterns.Behavioral.Command.Commandables;
using DesignPatterns.Behavioral.Command.Commands;
using DesignPatterns.Behavioral.Command.Incrementables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests.Behavioral.Command
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void CommandTests_int_Execute_Undo_Increment_WorksCorrectly()
        {
            var score = new Score();

            var increment = new IncrementCommand<int>(score.Value, 5);

            CommandManager.ExecuteCommand(increment);
            Assert.AreEqual(5, score.Value.Value);

            CommandManager.UndoCommand();
            Assert.AreEqual(0, score.Value.Value);
        }

        [TestMethod]
        public void CommandTests_int_Execute_Undo_Decrement_WorksCorrectly()
        {
            var score = new Score();

            var decrement = new DecrementCommand<int>(score.Value, 3);

            CommandManager.ExecuteCommand(decrement);
            Assert.AreEqual(-3, score.Value.Value);

            CommandManager.UndoCommand();
            Assert.AreEqual(0, score.Value.Value);
        }

        [TestMethod]
        public void CommandTests_decimal_Execute_Undo_Increment_WorksCorrectly()
        {
            var budget = new Budget();

            var increment = new IncrementCommand<decimal>(budget.NetIncome, 5.5m);

            CommandManager.ExecuteCommand(increment);
            Assert.AreEqual(5.5m, budget.NetIncome.Value);

            CommandManager.UndoCommand();
            Assert.AreEqual(0, budget.NetIncome.Value);
        }

        [TestMethod]
        public void CommandTests_decimal_Execute_Undo_Decrement_WorksCorrectly()
        {
            var budget = new Budget();

            var decrement = new DecrementCommand<decimal>(budget.Reserve, 30.25m);

            CommandManager.ExecuteCommand(decrement);
            Assert.AreEqual(-30.25m, budget.Reserve.Value);

            CommandManager.UndoCommand();
            Assert.AreEqual(0, budget.Reserve.Value);
        }
    }
}
