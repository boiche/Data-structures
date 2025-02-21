using DesignPatterns.Structural.Adapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Structural.Adapter
{
    [TestClass]
    public partial class AdapterTests
    {
        [TestMethod]
        public void FromList_GetQueue()
        {
            var result = this._list.GetQueue();
            var testCaseEnumerator = _list.GetEnumerator();
            testCaseEnumerator.MoveNext();

            Assert.IsInstanceOfType(result, typeof(System.Collections.Generic.Queue<string>));
            Assert.AreEqual(result.Peek(), testCaseEnumerator.Current);
        }

        [TestMethod]
        public void FromQueue_GetStack()
        {
            var result = this._queue.GetStack();
            var testCaseEnumerator = _queue.GetEnumerator();
            testCaseEnumerator.MoveNext();
            var last = testCaseEnumerator.Current;
            while (testCaseEnumerator.MoveNext())
            {
                last = testCaseEnumerator.Current;
            }

            Assert.IsInstanceOfType(result, typeof(System.Collections.Generic.Stack<string>));
            Assert.AreEqual(result.Peek(), last);
        }

        [TestMethod]
        public void FromDictionaryKeys_GetStack()
        {
            var result = this._dictionary.GetStack();
            var testCaseEnumerator = _dictionary.GetEnumerator();
            var last = testCaseEnumerator.Current;
            while (testCaseEnumerator.MoveNext())
            {
                last = testCaseEnumerator.Current;
            }
            testCaseEnumerator.MoveNext();

            Assert.IsInstanceOfType(result, typeof(System.Collections.Generic.Stack<KeyValuePair<Guid, string>>));
            Assert.AreEqual(result.Peek(), last);
        }

        [TestMethod]
        public void FromDictionaryValues_GetList()
        {
            var result = this._dictionary.GetList();
            var testCaseEnumerator = _dictionary.GetEnumerator();
            testCaseEnumerator.MoveNext();

            Assert.IsInstanceOfType(result, typeof(List<KeyValuePair<Guid, string>>));
            Assert.AreEqual(result[0], testCaseEnumerator.Current);
        }

        [TestMethod]
        public void FromQueue_GetDictionaryKeys()
        {
            var result = this._queue.GetDictionaryWithKeys<string, object>();
            var testCaseEnumerator = _queue.GetEnumerator();
            testCaseEnumerator.MoveNext();

            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
            Assert.AreEqual(result.Keys.GetList()[0], testCaseEnumerator.Current);
        }

        [TestMethod]
        public void FromQueue_GetDictionaryValues()
        {
            var result = this._queue.GetDictionaryWithValues<int, string>();
            var testCaseEnumerator = _queue.GetEnumerator();
            testCaseEnumerator.MoveNext();

            Assert.IsInstanceOfType(result, typeof(Dictionary<int, string>));
            Assert.AreEqual(result.Values.GetList()[0], testCaseEnumerator.Current);
        }

        [TestMethod]
        public void FromStack_GetQueue()
        {
            var result = this._stack.GetQueue();
            var testCaseEnumerator = _stack.GetEnumerator();
            testCaseEnumerator.MoveNext();

            Assert.IsInstanceOfType(result, typeof(System.Collections.Generic.Queue<string>));
            Assert.AreEqual(result.Peek(), testCaseEnumerator.Current);
        }

        [TestMethod]
        public void FromStack_GetList()
        {
            var result = this._stack.GetList();
            var testCaseEnumerator = _stack.GetEnumerator();
            testCaseEnumerator.MoveNext();

            Assert.IsInstanceOfType(result, typeof(System.Collections.Generic.List<string>));
            Assert.AreEqual(result[0], testCaseEnumerator.Current);
        }

        [TestMethod]
        public void FromStack_GetDictionaryValues()
        {
            var result = this._stack.GetDictionaryWithValues<int, string>();
            var testCaseEnumerator = _stack.GetEnumerator();
            testCaseEnumerator.MoveNext();

            Assert.IsInstanceOfType(result, typeof(Dictionary<int, string>));
            Assert.AreEqual(result.Values.GetList()[0], testCaseEnumerator.Current);
        }
    }
}
