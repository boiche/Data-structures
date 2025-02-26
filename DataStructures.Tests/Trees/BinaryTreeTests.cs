using DataStructures.Trees.BinaryTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataStructures.Tests.Trees
{
    [TestClass]
    public class BinaryTreeTests : IDynamicStructuresTest
    {
        private List<int> source = [1, 2, 4, 5, 6, 7, 8, 9];

        [TestMethod]
        public void BuildTree_WorksCorrectly()
        {
            BinaryTree<int> tree = new(source);
            Assert.AreEqual(source[0], tree.Root.Value);
        }

        [TestMethod]
        public void AddNodeWorksCorrectly()
        {
            BinaryTree<int> emptyTree = new();

            emptyTree.Add(1);

            Assert.AreEqual(1, emptyTree.Root.Value);
            Assert.AreEqual(1, emptyTree.Count);
        }

        [TestMethod]
        public void RemoveNodeWorksCorrectly()
        {
            BinaryTree<int> emptyTree = new();

            emptyTree.Add(1);
            
            Assert.IsFalse(emptyTree.Remove(2));
            Assert.IsTrue(emptyTree.Remove(1));
            Assert.IsFalse(emptyTree.Remove(1));
        }
    }
}
