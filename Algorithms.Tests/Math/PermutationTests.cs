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
        public void Permute_Correctly()
        {
            int from = 1, to = 9;
            int totalCount = 362880; // 9!

            var result = Permutations.Generate(from, to);

            Assert.AreEqual(result.Count(), totalCount);
        }
    }
}
