using DataStructures.Linear;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests.Linear
{
    [TestClass]

    public class Stack
    {
        public Stack<int> emptyStack = new Stack<int>();
        public Stack<int> populatedStack = new Stack<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

        [TestMethod]
        public void PushToStack()
        {
            emptyStack.Push(2);
            Assert.AreEqual(1, emptyStack.Count);
            Assert.AreEqual(2, emptyStack.Peek());
        }

        [TestMethod]
        public void PushManyItemsToStack()
        {
            for (int i = 0; i < 20; i++)
            {
                emptyStack.Push(i);
            }

            int result = 0;
            for (int i = 0; i < 5; i++)
                result = emptyStack.Pop();

            Assert.AreEqual(15, emptyStack.Count);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void PopItemFromStack()
        {
            int item = populatedStack.Pop();
            Assert.AreEqual(9, item);
            Assert.AreEqual(8, populatedStack.Count);
        }

        [TestMethod]
        public void PeekItem()
        {
            int item = populatedStack.Peek();
            Assert.AreEqual(9, item);
            Assert.AreEqual(9, populatedStack.Count);
        }
    }
}
