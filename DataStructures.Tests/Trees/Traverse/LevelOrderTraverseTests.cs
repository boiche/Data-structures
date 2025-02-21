using DataStructures.Recursive.Trees.BinaryTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace DataStructures.Tests.Trees.Traverse
{
    [TestClass]
    public class LevelOrderTraverseTests
    {
        [TestMethod]
        public void LevelOrderTraverse_WorksCorrectly()
        {
            BinaryTree<int> tree = new BinaryTree<int>([1, 2, 3, 4, 5, 6, 7, 8, 9], new() { Traverse = Recursive.Trees.Interfaces.Traverse.LevelOrder });
            BinarySearchTree<int> searchTree = new BinarySearchTree<int>([6, 3, 9, 2, 1, 8, 5, 4, 7], new() { Traverse = Recursive.Trees.Interfaces.Traverse.LevelOrder });
            StringBuilder sb = new StringBuilder();

            string treeResult;
            string searchTreeResult;

            foreach (int n in tree)
            {
                sb.Append(n);
            }
            treeResult = sb.ToString();
            sb.Clear();

            foreach (int n in searchTree)
            {
                sb.Append(n);
            }
            searchTreeResult = sb.ToString();

            Assert.AreEqual("123456789", treeResult);
            Assert.AreEqual("123456789", searchTreeResult);
        }
    }
}
