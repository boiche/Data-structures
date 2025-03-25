using DataStructures.Graphs;
using DataStructures.Graphs.Nodes;
using DataStructures.Graphs.Nodes.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DataStructures.Tests.Graphs
{
    [TestClass]
    public class DirectedAcyclicGraphTests
    {
        [TestMethod]
        public void Link_WorksCorrectly()
        {
            DirectedAcyclicGraph<INode<int>> graph = new();
            Node<int>[] nodes = [new Node<int>(5), new Node<int>(6), new Node<int>(7), new Node<int>(8)];

            graph.CreateNode(nodes[0]);
            graph.LinkNode(nodes[0], nodes[1]);
            graph.LinkNode(nodes[1], nodes[2]);
            graph.LinkNode(nodes[2], nodes[3]);

            Assert.AreEqual(4, graph.Nodes.Count);
            Assert.AreEqual(1, graph[nodes[2]].Children.Count);
            Assert.AreEqual(0, graph[nodes[3]].Children.Count);
        }

        [TestMethod]
        public void Link_Cycle_ThrowsException()
        {
            DirectedAcyclicGraph<INode<int>> graph = new();

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
