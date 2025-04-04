using Algorithms.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.Math
{
    [TestClass]
    public class CombinationsTests
    {
        [TestMethod]
        public void Combinations_Count_WorksCorrectly()
        {
            int[] nums = [1, 2, 3, 4, 5, 6, 7, 8, 9];

            var k2 = Combinations.Generate(nums, 2);
            var k3 = Combinations.Generate(nums, 3);
            var k4 = Combinations.Generate(nums, 4);

            Assert.AreEqual((9 * 8) / (1 * 2), k2.Count);
            Assert.AreEqual((9 * 8 * 7) / (1 * 2 * 3), k3.Count);
            Assert.AreEqual((9 * 8 * 7 * 6) / (1 * 2 * 3 * 4), k4.Count);
        }

        [TestMethod]
        public void Combinations_Order_WorksCorrectly()
        {
            string[] strings = ["first", "second", "third", "fourth"];

            var k2 = Combinations.Generate(strings, 2);
            var toAssert = k2[4]; // (1,2), (1,3), (1,4), (2,3), (2, 4)

            Assert.AreEqual("second", toAssert[0]);
            Assert.AreEqual("fourth", toAssert[1]);
        }
    }
}
