using DesignPatterns.Behavioral.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DesignPatterns.Tests.Behavioral.Strategy
{
    [TestClass]
    public partial class StrategyTests
    {
        [TestMethod]
        public void SortIntegers()
        {
            SortingContext<int> sortingContext = new SortingContext<int>(_sortingIntegers[0]);
            foreach (var algorithm in _sortingIntegers)
            {
                var tempIntegers = _integers.Select(x => x).ToList();
                sortingContext.SetSorting(algorithm);
                sortingContext.Sort(tempIntegers);
                Assert.IsTrue(tempIntegers.SequenceEqual<int>(_sortedIntegers));
            }
        }

        [TestMethod]
        public void SortStrings()
        {
            SortingContext<string> sortingContext = new SortingContext<string>(_sortingStrings[0]);
            foreach (var algorithm in _sortingStrings)
            {
                var tempStrings = _strings.Select(x => x).ToList();
                sortingContext.SetSorting(algorithm);
                sortingContext.Sort(tempStrings);
                Assert.IsTrue(tempStrings.SequenceEqual<string>(_sortedStrings));
            }
        }

        [TestMethod]
        public void SortCustomObjects()
        {
            SortingContext<Product> sortingContext = new SortingContext<Product>(_sortingProducts[0]);
            foreach (var algorithm in _sortingProducts)
            {
                var tempProducts = _products.Select(x => x).ToList();
                sortingContext.SetSorting(algorithm);
                sortingContext.Sort(tempProducts);
                Assert.IsTrue(tempProducts.Select(x => x.Grade).SequenceEqual<decimal>(_sortedProducts.Select(x => x.Grade)));
            }
        }
    }
}
