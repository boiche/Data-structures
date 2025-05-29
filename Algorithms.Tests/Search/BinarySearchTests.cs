using Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Algorithms.Tests.Search
{
    [TestClass]
    public class BinarySearchTests
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
        public void BinarySearch_Finds()
        {
            int result = BinarySearch.Search(_stringSource, _stringSource[3]);
            Assert.AreEqual(3, result);

            result = BinarySearch.Search(_intSource, _intSource[2]);
            Assert.AreEqual(2, result);

            result = BinarySearch.Search(_dateTimeSource, _dateTimeSource[1]);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void BinarySearch_DoesntFind()
        {
            int result = BinarySearch.Search(_stringSource, "falsy");
            Assert.AreEqual(-1, result);

            result = BinarySearch.Search(_intSource, -123);
            Assert.AreEqual(-1, result);

            result = BinarySearch.Search(_dateTimeSource, DateTime.Parse("04.02.2001"));
            Assert.AreEqual(-1, result);
        }
    }
}
