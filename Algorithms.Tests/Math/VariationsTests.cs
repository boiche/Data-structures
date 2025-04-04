using Algorithms.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.Math
{
    [TestClass]
    public class VariationsTests
    {
        [TestMethod]
        public void Variations_Count_WorksCorrectly()
        {
            int[] nums = [1, 2, 3, 4, 5, 6, 7, 8, 9];

            var k2 = Variations.Generate(nums, 2);
            var k3 = Variations.Generate(nums, 3);
            var k4 = Variations.Generate(nums, 4);

            Assert.AreEqual(9 * 8, k2.Count);
            Assert.AreEqual(9 * 8 * 7, k3.Count);
            Assert.AreEqual(9 * 8 * 7 * 6, k4.Count);
        }

        [TestMethod]
        public void Variations_Order_WorksCorrectly()
        {
            string[] strings = ["first", "second", "third", "fourth"];

            var k2 = Variations.Generate(strings, 2);
            var toAssert = k2[4]; // (1,2), (1,3), (1,4), (2,1), (2,3)

            Assert.AreEqual("second", toAssert[0]);
            Assert.AreEqual("third", toAssert[1]);
        }
    }
}
