using System;
using System.Text;
using DataStructures.Linear;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class Queue
    {
        public Queue<int> emptyQueue = new Queue<int>();
        public Queue<int> populatedQueue = new Queue<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        public Queue<int> growthFactorQueue = new Queue<int>(5, 4);

        [TestMethod]
        public void EnqueueItemToQueue()
        {
            emptyQueue.Enqueue(5);
            Assert.AreEqual(1, emptyQueue.Count);
        }
        [TestMethod]
        public void EnqueueManyItems()
        {
            for (int i = 0; i < 15; i++)
            {
                emptyQueue.Enqueue(i);
            }

            Assert.AreEqual(15, emptyQueue.Count);
        }

        [TestMethod]
        public void DequeueItem()
        {
            int item=populatedQueue.Dequeue();
            Assert.AreEqual(1, item);
            Assert.AreEqual(8, populatedQueue.Count);
        }

        [TestMethod]
        public void PeekItem()
        {
            int item = populatedQueue.Peek();
            Assert.AreEqual(1, item);
            Assert.AreEqual(9, populatedQueue.Count);
        }

        [TestMethod]
        public void GrowthFactorQueueTest()
        {
            for (int i = 0; i < 6; i++)
            {
                growthFactorQueue.Enqueue(i);
            }
            
            Assert.AreEqual(20, growthFactorQueue.Capacity);
            Assert.AreEqual(6, growthFactorQueue.Count);
        }
    }
}
