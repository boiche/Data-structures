using Algorithms.Other.GraphExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.Other
{
    [TestClass]
    public class GraphExtensionsTests
    {
        [TestMethod]
        public void DFS_Recursive_WorksCorrectly()
        {
            int[][] square = [[0, 1, 2], [3, 4, 5], [6, 7, 8]];
            int[][] nonSquare = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [9, 10, 11]];

            var squareResult = square.DFS_Recursive();
            var nonSquareResult = nonSquare.DFS_Recursive();

            Assert.AreEqual("876345210", string.Join("", squareResult));
            Assert.AreEqual("91011876345210", string.Join("", nonSquareResult));
        }

        [TestMethod]
        public void DFS_Linear_WorksCorrectly()
        {
            int[][] square = [[0, 1, 2], [3, 4, 5], [6, 7, 8]];
            int[][] nonSquare = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [9, 10, 11]];

            var squareResult = square.DFS_Linear();
            var nonSquareResult = nonSquare.DFS_Linear();

            Assert.AreEqual("012543678", string.Join("", squareResult));
            Assert.AreEqual("01254367811109", string.Join("", nonSquareResult));
        }
    }
}
