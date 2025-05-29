using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests.Trees.Factories
{
    [TestClass]
    public class TreeFactoryTests
    {
        [TestMethod]
        public void FromAdjacencyArray_WorksCorrectly()
        {
            int[][] values = [[8, 3], [3, 1], [3, 6], [6, 4], [6, 7]];

            var result = TreeFactory<int>.FromAdjacencyArray(values);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(8, result.Root.Value);
        }

        [TestMethod]
        public void FromAdjacencyArray_Complex_WorksCorrectly()
        {
            int[][] values = [[22, 4], [4, 30], [30, 20], [20, 10], [10, 27], [27, 1], [1, 21], [21, 7], [7, 25], [25, 28], [28, 8], [8, 13], [13, 2], [2, 16], [16, 9], [9, 11], [11, 12], [12, 17], [17, 23], [23, 5], [5, 19], [19, 18], [18, 24], [24, 26], [26, 3], [3, 14], [14, 29], [29, 6], [6, 15]];

            var result = TreeFactory<int>.FromAdjacencyArray(values);

            Assert.AreEqual(30, result.Count);
            Assert.AreEqual(22, result.Root.Value);
        }
    }
}
