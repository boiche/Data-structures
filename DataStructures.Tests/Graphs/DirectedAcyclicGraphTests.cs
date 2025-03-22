using DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests.Graphs
{
    [TestClass]
    public class DirectedAcyclicGraphTests
    {
        [TestMethod]
        public void Link_WorksCorrectly()
        {
            DirectedAcyclicGraph<int> graph = new();

            graph.CreateNode(5);
            graph.Link(5, 6);
            graph.Link(6, 7);
            graph.Link(7, 8);

            Assert.AreEqual(4, graph.Count);
            Assert.AreEqual(1, graph[7].Children.Count);
            Assert.AreEqual(0, graph[8].Children.Count);
        }

        [TestMethod]
        public void Link_Cycle_ThrowsException()
        {
            DirectedAcyclicGraph<int> graph = new();

            graph.CreateNode(5);
            graph.Link(5, 6);
            graph.Link(6, 7);
            graph.Link(7, 8);

            Assert.ThrowsException<Exception>(() => graph.Link(8, 5));
        }

        [TestMethod]
        public void TopologicalSort_WorksCorrectly()
        {
            DirectedAcyclicGraph<int> graph = new();
            graph.CreateNode(4);
            graph.CreateNode(5);
            graph.CreateNode(6);

            graph.Link(4, 2);
            graph.Link(5, 2);
            graph.Link(6, 3);
            graph.Link(2, 1);
            graph.Link(3, 1);

            var topoSort = graph.TopologicalSort();
            Assert.IsTrue(topoSort.SequenceEqual([4, 5, 6, 2, 3, 1]));
        }
    }
}
