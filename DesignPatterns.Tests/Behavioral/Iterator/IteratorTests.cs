using DesignPatterns.Behavioral.Iterator.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Tests.Behavioral.Iterator
{
    [TestClass]
    public class IteratorTests
    {
        [TestMethod]
        public void IteratorTests_LinearArray_WorksCorrectly()
        {
            int[] assert = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
            LinearArray<int> source = new LinearArray<int>(assert.Length);
            for (int i = 0; i < assert.Length; i++)
            {
                source[i] = i;
            }

            List<int> result = [];
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }

            Assert.IsTrue(assert.SequenceEqual(result));
        }

        [TestMethod]
        public void IteratorTests_CircularArray_WorksCorrectly()
        {
            int[] assert = [7, 8, 9, 0, 1, 2, 3, 4, 5, 6];
            CircularArray<int> source = new CircularArray<int>(assert.Length, 7);
            for (int i = 0; i < assert.Length; i++)
            {
                source[i] = i;
            }

            List<int> result = [];
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }

            Assert.IsTrue(assert.SequenceEqual(result));
        }
    }
}
