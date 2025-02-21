using Algorithms.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.Math
{
    [TestClass]
    public class FibonacciNumbersTests
    {
        [TestMethod]
        public void Iterative_Correct()
        {
            Assert.AreEqual(0, FibonacciNumbers.GetNumberIterative(0));
            Assert.AreEqual(1, FibonacciNumbers.GetNumberIterative(1));
            Assert.AreEqual(55, FibonacciNumbers.GetNumberIterative(10));
            Assert.AreEqual(144, FibonacciNumbers.GetNumberIterative(12));
        }

        [TestMethod]
        public void Recursive_Correct()
        {
            Assert.AreEqual(0, FibonacciNumbers.GetNumberRecursive(0));
            Assert.AreEqual(1, FibonacciNumbers.GetNumberRecursive(1));
            Assert.AreEqual(55, FibonacciNumbers.GetNumberRecursive(10));
            Assert.AreEqual(144, FibonacciNumbers.GetNumberRecursive(12));
        }
    }
}
