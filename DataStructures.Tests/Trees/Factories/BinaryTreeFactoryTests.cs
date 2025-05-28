using DataStructures.Trees.BinaryTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests.Trees.Factories
{
    [TestClass]
    public class BinaryTreeFactoryTests
    {
        [TestMethod]
        public void FromLevelOrder_WorksCorrectly()
        {
            int?[] values = [3, 5, 1, 6, 2, 0, 8, null, null, 7, 4];

            var result = BinaryTreeFactory<int?>.FromLevelOrder(values);

            Assert.AreEqual(9, result.Count);
            Assert.AreEqual(3, result.Root.Value);
        }
    }
}
