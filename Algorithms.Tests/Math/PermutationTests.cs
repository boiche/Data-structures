using Algorithms.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Algorithms.Tests.Math
{
    [TestClass]
    public class PermutationTests
    {
        [TestMethod]
        public void Permutations_Count_WorksCorrectly()
        {
            int from = 1, to = 9;
            int totalCount = 362880; // 9!

            var result = Permutations.Generate(from, to);

            Assert.AreEqual(totalCount, result.Count);
        }

        [TestMethod]
        public void Permutations_Order_WorksCorrectly()
        {
            int from = 1, to = 9;

            var result = Permutations.Generate(from, to);
            var toAssert = result[^1];

            Assert.IsTrue(toAssert.SequenceEqual([9, 1, 2, 3, 4, 5, 6, 7, 8]));
        }
    }
}
