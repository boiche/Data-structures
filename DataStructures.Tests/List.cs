using DataStructures.Linear;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DataStructures.Tests
{
    [TestClass]
    public class List
    {
        private static readonly int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public List<int> emptyList = new List<int>();
        public List<int> populatedList = new List<int>(data);        

        [TestMethod]
        public void AddItemWorksCorrectly()
        {
            emptyList.Add(5);
            Assert.AreEqual(1, emptyList.Count);
            Assert.AreEqual(5, emptyList[0]);
        }
        [TestMethod]
        public void AddManyItemsWorksCorrectly()
        {
            for (int i = 0; i < 15; i++)
            {
                emptyList.Add(i);                
            }

            Assert.AreEqual(15, emptyList.Count);
            Assert.AreEqual(5, emptyList[5]);
        }
        [TestMethod]
        public void RemoveItemWorksCorrectly()
        {
            populatedList.Remove(5);
            Assert.AreEqual(8, populatedList.Count);
            Assert.AreEqual(6, populatedList[4]);

            populatedList.Remove(1234);
            Assert.AreEqual(8, populatedList.Count);
        }
    }
}
