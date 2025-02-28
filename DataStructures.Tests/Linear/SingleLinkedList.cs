using DataStructures.Linear.LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DataStructures.Tests.Linear
{
    [TestClass]
    public class SingleLinkedList : IDynamicStructuresTest
    {
        public SingleLinkedList<int> list = new SingleLinkedList<int>();
        public Random Random = new Random();

        [TestMethod]
        public void AddRootWorksCorrectly()
        {
            list.AddNode(8);
            Assert.AreEqual(8, list.FindAt(0).Value);
        }

        [TestMethod]
        public void AddNodeWorksCorrectly()
        {
            int count = Random.Next(1, 30);
            int[] expected = new int[count];

            for (int i = 0; i < count; i++)
            {
                expected[i] = i;
                list.AddNode(i);
            }

            Assert.AreEqual(expected.Length, list.Count);
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], list.GetValueAt(i));            
        }

        [TestMethod]
        public void InsertNodeWorksCorrectly()
        {
            list.InsertNode(2, 0);
            Assert.AreEqual(2, list.GetValueAt(0));
        }

        [TestMethod]
        public void InsertNodeThrowsException()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => { list.InsertNode(9, -1); });
            Assert.ThrowsException<IndexOutOfRangeException>(() => { list.InsertNode(10, 3); }); //Count = 0
        }

        [TestMethod]
        public void InsertMultipleNodesWorksCorrectly()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7 };
            list = SingleLinkedListFactory<int>.GetListFromArray(new int[]{ 1, 2, 3, 5, 7 }); // insert 4 and 6
            list.InsertNode(4, 3);
            list.InsertNode(6, 5);
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], list.GetValueAt(i));
        }

        [TestMethod]
        public void InsertTailWorksCorrectly()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7 };
            list = SingleLinkedListFactory<int>.GetListFromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            list.InsertNode(7, 6);
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], list.GetValueAt(i));
        }

        [TestMethod]
        public void FindAtWorksCorrectly()
        {
            list = SingleLinkedListFactory<int>.GetListFromArray(new int[] { 1, 2, 3, 4, 5 });
            int result = list.GetValueAt(3);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void FindAtThrowsException()
        {
            list = SingleLinkedListFactory<int>.GetListFromArray(new int[] { 1, 2, 3, 4, 5 });
            Assert.ThrowsException<IndexOutOfRangeException>(() => { list.FindAt(-1); });
            Assert.ThrowsException<IndexOutOfRangeException>(() => { list.FindAt(10); });
        }

        [TestMethod]
        public void IndexOfWorksCorrectly()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6 };
            list = SingleLinkedListFactory<int>.GetListFromArray(expected);
            Assert.AreEqual(1, list.IndexOf(2));
            Assert.AreEqual(4, list.IndexOf(5));
            Assert.AreEqual(-1, list.IndexOf(7));
        }

        [TestMethod]
        public void RemoveNodeWorksCorrectly()
        {
            list = SingleLinkedListFactory<int>.GetListFromArray(new int[] { 1, 2, 3, 4, 5 });
            list.Remove();
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(4, list.Last());
        }

        [TestMethod]
        public void RemoveNodeThrowsException() => Assert.ThrowsException<InvalidOperationException>(() => list.Remove()); // empty list      

        [TestMethod]
        public void RemoveAtThrowsException()
        {
            list = SingleLinkedListFactory<int>.GetListFromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            Assert.ThrowsException<IndexOutOfRangeException>(() => { list.RemoveAt(-1); });
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(10));
            list.Clear();
            Assert.ThrowsException<InvalidOperationException>(() => { list.RemoveAt(0); });
        }

        [TestMethod]
        public void RemoveAtWorksCorrectly()
        {
            int[] expected = new int[] { 1, 2, 4, 5, 6 };
            list = SingleLinkedListFactory<int>.GetListFromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            list.RemoveAt(2);
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], list.GetValueAt(i));
        }
    }
}
