using Algorithms.Other.CollectionExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static Algorithms.Other.CollectionExtensions.CollectionExtensions;

namespace Algorithms.Tests.Other
{
    [TestClass]
    public class CollectionExtensionsTests
    {
        [TestMethod]
        public void UpdateRange_Addition_WorksCorrectly()
        {
            int[] source = [1, 2, 3, 4, 5, 6, 7, 8, 9];
            int[] expected = [6, 7, 8, 9, 10, 11, 12, 8, 9];

            source.UpdateRange(0, 6, 5, Operation.Addition);

            Assert.IsTrue(source.SequenceEqual(expected));
        }

        [TestMethod]
        public void UpdateRange_Substraction_WorksCorrectly()
        {
            int[] source = [1, 2, 3, 4, 5, 6, 7, 8, 9];
            int[] expected = [1, 2, 3, 4, 5, 6, 2, 3, 4];

            source.UpdateRange(6, 8, 5, Operation.Substraction);

            Assert.IsTrue(source.SequenceEqual(expected));
        }
    }
}
