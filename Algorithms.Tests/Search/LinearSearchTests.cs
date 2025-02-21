using Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithms.Tests.Search
{
    [TestClass]
    public class LinearSearchTests
    {
        private readonly string[] _stringSource = new string[5]
        {
            "abcdefg",
            "random string",
            "this solution helps a lot",
            "azis - haide pochvai me",
            "idk"
        };
        private readonly int[] _intSource = new int[5]
        {
            5, 5471, 1000, int.MaxValue, int.MinValue
        };
        private readonly DateTime[] _dateTimeSource = new DateTime[5]
        {
            DateTime.Now, DateTime.Today, DateTime.MinValue, DateTime.MaxValue, DateTime.UnixEpoch
        };

        [TestMethod]
        public void LinearSearch_FindsFirst()
        {
            var result = LinearSearch.Search(_stringSource, _stringSource[0]);
            Assert.AreEqual(0, result);

            result = LinearSearch.Search(_intSource, _intSource[0]);
            Assert.AreEqual(0, result);

            result = LinearSearch.Search(_dateTimeSource, _dateTimeSource[0]);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void LinearSearch_FindsRandom()
        {
            Random random = new();

            int next = random.Next(0, 4);
            var result = LinearSearch.Search(_stringSource, _stringSource[next]);
            Assert.AreEqual(next, result);

            next = random.Next(0, 4);
            result = LinearSearch.Search(_intSource, _intSource[next]);
            Assert.AreEqual(next, result);

            next = random.Next(0, 4);
            result = LinearSearch.Search(_dateTimeSource, _dateTimeSource[next]);
            Assert.AreEqual(next, result);
        }

        [TestMethod]
        public void LinearSearch_DoesntFind()
        {
            var result = LinearSearch.Search(_stringSource, "falsy");
            Assert.AreEqual(-1, result);

            result = LinearSearch.Search(_intSource, -123);
            Assert.AreEqual(-1, result);

            result = LinearSearch.Search(_dateTimeSource, DateTime.Parse("04.02.2001"));
            Assert.AreEqual(-1, result);
        }
    }
}