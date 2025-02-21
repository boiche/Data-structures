using DataStructures.Linear.LinkedLists.DoubleLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.Tests
{
    [TestClass]
    public class DoubleLinkedList : IDynamicStructuresTest
    {
        private static readonly int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        public DoubleLinkedList<int> populatedList = DoubleLinkedListFactory<int>.CreateFromArray(expected);
        public DoubleLinkedList<int> emptyList = new DoubleLinkedList<int>();

        [TestMethod]
        public void AddNodeWorksCorrectly()
        {
            emptyList.AddNode(3);
            Assert.AreEqual(3, emptyList.GetValueAt(0));

            populatedList.AddNode(8);
            Assert.AreEqual(8, populatedList.GetValueAt(7));
        }

        [TestMethod]
        public void InsertNodeWorksCorrectly()
        {
            int[] before = new int[] { 1, 2, 3, 5, 6, 7 };
            populatedList = DoubleLinkedListFactory<int>.CreateFromArray(before);
            populatedList.InsertNode(4, 3);
            Assert.AreEqual(expected.Length, populatedList.Count);
            Assert.AreEqual(expected[3], populatedList.GetValueAt(3));
            emptyList.InsertNode(1, 0);
            Assert.AreEqual(expected[0], emptyList.GetValueAt(0));
        }

        [TestMethod]
        public void InsertNodeThrowsException()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => emptyList.InsertNode(2, 1));
            Assert.ThrowsException<IndexOutOfRangeException>(() => populatedList.InsertNode(10, 7));            
        }

        [TestMethod]
        public void RemoveNodeWorksCorrectly()
        {
            populatedList.Remove();
            Assert.AreEqual(expected[^2], populatedList.GetValueAt(populatedList.Count - 1));
        }

        [TestMethod]
        public void RemoveAtWorksCorrectly()
        {
            populatedList.RemoveAt(0);
            Assert.AreEqual(expected[1], populatedList.GetValueAt(0));
            Assert.AreEqual(expected.Length - 1, populatedList.Count);
            populatedList.RemoveAt(populatedList.Count - 1);
            Assert.AreEqual(expected[5], populatedList.GetValueAt(populatedList.Count - 1));
            Assert.AreEqual(expected.Length - 2, populatedList.Count);
        }

        [TestMethod]
        public void RemoveNodeThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => emptyList.Remove());            
        }
    }
}
