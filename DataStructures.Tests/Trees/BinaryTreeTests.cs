using DataStructures.Linear;
using DataStructures.Trees.BinaryTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            emptyTree.AddComponent(1);

            Assert.AreEqual(1, emptyTree.Root.Value);
            Assert.AreEqual(1, emptyTree.Count);
        }

        [TestMethod]
        public void RemoveNodeWorksCorrectly()
        {
            BinaryTree<int> tree = new();

            tree.AddComponent(1);

            tree.Remove(2);
            Assert.AreEqual(1, tree.Count);

            tree.Remove(1);
            Assert.AreEqual(0, tree.Count);

            tree.Remove(1);
            Assert.AreEqual(0, tree.Count);
        }
    }
}
