using Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Algorithms.Tests.Search
{
    [TestClass]
    public class FibonacciSearchTests
    {
        private readonly string[] _stringSource = new string[5]
{
            "abcdefg",
            "random string",
            "this solution helps a lot",
            "azis - haide pochvai me",
            "idk"
}.OrderBy(x => x).ToArray();
        private readonly int[] _intSource = new int[5]
        {
            5, 5471, 1000, int.MaxValue, int.MinValue
        }.OrderBy(x => x).ToArray();
        private readonly DateTime[] _dateTimeSource = new DateTime[5]
        {
            DateTime.Now, DateTime.Today, DateTime.MinValue, DateTime.MaxValue, DateTime.UnixEpoch
        }.OrderBy(x => x).ToArray();

        [TestMethod]
        public void FibonacciSearch_FindsFirst()
        {
            Assert.AreEqual(0, FibonacciSearch.Search(_stringSource, _stringSource[0]));
            Assert.AreEqual(0, FibonacciSearch.Search(_intSource, _intSource[0]));
            Assert.AreEqual(0, FibonacciSearch.Search(_dateTimeSource, _dateTimeSource[0]));
        }

        [TestMethod]
        public void FibonacciSearch_FindsRandom()
        {
            Random random = new();

            int next = random.Next(0, 4);
            var result = FibonacciSearch.Search(_stringSource, _stringSource[next]);
            Assert.AreEqual(next, result);

            next = random.Next(0, 4);
            result = FibonacciSearch.Search(_intSource, _intSource[next]);
            Assert.AreEqual(next, result);

            next = random.Next(0, 4);
            result = FibonacciSearch.Search(_dateTimeSource, _dateTimeSource[next]);
            Assert.AreEqual(next, result);
        }

        [TestMethod]
        public void FibonacciSearch_DoesntFind()
        {
            int result = FibonacciSearch.Search(_stringSource, "falsy");
            Assert.AreEqual(-1, result);

            result = FibonacciSearch.Search(_intSource, -123);
            Assert.AreEqual(-1, result);

            result = FibonacciSearch.Search(_dateTimeSource, DateTime.Parse("04.02.2001"));
            Assert.AreEqual(-1, result);
        }
    }
}
