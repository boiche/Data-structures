using DataStructures.Recursive.Trees.BinaryTrees;
using DataStructures.Recursive.Trees.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DataStructures.Tests.Trees
{
    [TestClass]
    public class BinaryTreeTests : IDynamicStructuresTest
    {
        readonly BinaryTree<int> emptyTree = new(new List<int>());
        private List<int> source = [1, 2, 4, 5, 6, 7, 8, 9];

        [TestMethod]
        public void BuildTree_WorksCorrectly()
        {
            BinaryTree<int> tree = new(source, new TreeOptions() { Traverse = Recursive.Trees.Interfaces.Traverse.Postorder });
            var result = string.Join("", tree);
            Assert.AreEqual(source[0], tree.Root.Value);
        }

        [TestMethod]
        public void AddNodeWorksCorrectly()
        {
            emptyTree.Add(1);
            Assert.AreEqual(1, emptyTree.Root.Value);
            Assert.AreEqual(1, emptyTree.Count);
        }

        [TestMethod]
        public void InsertNodeThrowsException()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void InsertNodeWorksCorrectly()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void RemoveNodeThrowsException()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void RemoveNodeWorksCorrectly()
        {
            throw new NotImplementedException();
        }
    }
}
