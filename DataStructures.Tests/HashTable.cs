using DataStructures.Recursive.Tables.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace DataStructures.Tests
{
    [TestClass]
    public class HashTable : IDynamicStructuresTest
    {
        readonly HashTableInt32<Point> hashTable = new(10);
        [TestMethod]
        public void InsertNodeThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                hashTable.Put(1, new Point(1, 1));
                hashTable.Put(1, new Point(2, 2));
            });
        }

        [TestMethod]
        public void InsertNodeWorksCorrectly()
        {
            hashTable.Put(1, new Point(1, 1));
            Assert.AreEqual(1, hashTable.GetValue(1).X);
            Assert.AreEqual(1, hashTable.GetValue(1).Y);           
        }

        public void RemoveNodeThrowsException()
        {
            throw new NotImplementedException();
        }

        public void RemoveNodeWorksCorrectly()
        {
            throw new NotImplementedException();
        }
    }
}
