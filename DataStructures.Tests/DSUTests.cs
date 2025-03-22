using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataStructures.Tests
{
    [TestClass]
    public class DSUTests
    {
        [TestMethod]
        public void BasicUnion_WorksCorrectly()
        {
            HashSet<int> numbers = new();
            numbers.Add(0);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            DSU<int> data = new(numbers, DSU<int>.DSUOptions.PathCompression);

            data.Union(3, 1);
            data.Union(1, 0);
            data.Union(5, 4);
            data.Union(2, 0);

            Assert.AreEqual(6, data.Count);
        }

        [TestMethod]
        public void UnionByRank_WorksCorrectly()
        {
            HashSet<int> numbers = new();
            numbers.Add(0);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            DSU<int> data = new(numbers, DSU<int>.DSUOptions.UnionByRank);

            data.Union(3, 1);
            data.Union(1, 0);
            data.Union(5, 4);
            data.Union(2, 0);
            data.Union(0, 5);

            Assert.AreEqual(4, data.Find(0));
        }

        [TestMethod]
        public void Find_ThrowsException()
        {
            HashSet<int> numbers = new();
            numbers.Add(0);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            DSU<int> data = new(numbers, DSU<int>.DSUOptions.PathCompression);
            Assert.ThrowsException<KeyNotFoundException>(() => { data.Find(int.MaxValue); });
        }

        [TestMethod]
        public void LeetCode_1061_WorksCorrectly()
        {
            HashSet<char> chars = new();
            for (int i = 'a'; i <= 'z'; i++)
            {
                chars.Add((char)i);
            }
            DSU<char> data = new(chars, DSU<char>.DSUOptions.PathCompression);
            string s1 = "parker", s2 = "morris", baseStr = "parser";

            for (int i = 0; i < s1.Length; i++)
            {
                char first = s1[i];
                char second = s2[i];

                if (first < second)
                    data.Assign(second, first);
                else
                    data.Assign(first, second);
            }

            char[] result = new char[baseStr.Length];
            for (int i = 0; i < result.Length; i++)
            {
                char currentSmallest = data.Find(baseStr[i]);
                result[i] = currentSmallest;
            }

            Assert.AreEqual("makkek", new string(result));
        }
    }
}
