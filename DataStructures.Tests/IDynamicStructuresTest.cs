using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    public interface IDynamicStructuresTest
    {
        [TestMethod]
        public void RemoveNodeWorksCorrectly() { }
        [TestMethod]
        public void InsertNodeWorksCorrectly() { }
        [TestMethod]
        public void InsertNodeThrowsException() { }
        [TestMethod]
        public void RemoveNodeThrowsException() { }
    }
}
