using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests.Trees
{
    [TestClass]
    public class TrieTests
    {
        private Trie trie = new Trie();

        [TestMethod]
        public void Insert_WorksCorrectly()
        {
            trie.Insert("and");
            trie.Insert("ant");

            Assert.AreEqual(0, trie.Root.Value);
            Assert.AreEqual(0, trie.Root.Children['a'].Value);
            Assert.AreEqual(0, trie.Root.Children['a'].Children['n'].Value);
            Assert.AreEqual(1, trie.Root.Children['a'].Children['n'].Children['d'].Value);
            Assert.AreEqual(1, trie.Root.Children['a'].Children['n'].Children['t'].Value);
        }

        [TestMethod]
        public void Find_WorksCorrectly()
        {
            string shouldFind = "thisvalueissomewhatlong";
            string shouldNotFind = "somethingelse";
            string shouldNotFindClose = shouldFind + 'a';
            string shouldNotFindShrinked = "thisvalueis";

            trie.Insert(shouldFind);

            Assert.IsTrue(trie.Find(shouldFind));
            Assert.IsFalse(trie.Find(shouldNotFind));
            Assert.IsFalse(trie.Find(shouldNotFindClose));
            Assert.IsFalse(trie.Find(shouldNotFindShrinked));
        }

        [TestMethod]
        public void Find_CloseWords_WorksCorrectly()
        {
            string shouldFind =         "thisvalueissomewhatlong";
            string shouldFindShrinked = "thisvalueis";

            trie.Insert(shouldFind);
            trie.Insert(shouldFindShrinked);

            Assert.IsTrue(trie.Find(shouldFind));
            Assert.IsTrue(trie.Find(shouldFindShrinked));
        }

        [TestMethod]
        public void Remove_WorksCorrectly()
        {
            trie.Insert("and");
            trie.Insert("ant");

            Assert.IsTrue(trie.Remove("and"));
            Assert.IsTrue(trie.Remove("ant"));
        }
    }
}
