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
            DirectedAcyclicGraph<INode<int>, int> graph = new();
            Node<int>[] nodes = [new Node<int>(5), new Node<int>(6), new Node<int>(7), new Node<int>(8)];

            graph.CreateNode(nodes[0]);
            graph.LinkNode(nodes[0], nodes[1]);
            graph.LinkNode(nodes[1], nodes[2]);
            graph.LinkNode(nodes[2], nodes[3]);

            Assert.AreEqual(4, graph.Nodes.Count);
            Assert.AreEqual(1, graph[7].Children.Count);
            Assert.AreEqual(0, graph[8].Children.Count);
        }

        [TestMethod]
        public void Link_Cycle_ThrowsException()
        {
            DirectedAcyclicGraph<Node<int>, int> graph = new();
            Node<int>[] nodes = [new Node<int>(5), new Node<int>(6), new Node<int>(7), new Node<int>(8)];

            graph.CreateNode(5);

            graph.LinkNode(5, 6);
            graph.LinkNode(6, 7);
            graph.LinkNode(7, 8);

            Assert.ThrowsException<Exception>(() => graph.LinkNode(nodes[3], nodes[1]));
        }

        [TestMethod]
        public void TopologicalSort_WorksCorrectly()
        {
            DirectedAcyclicGraph<Node<int>, int> graph = new();

            graph.CreateNode(4);
            graph.CreateNode(5);
            graph.CreateNode(6);

            graph.LinkNode(4, 2);
            graph.LinkNode(5, 2);
            graph.LinkNode(6, 3);
            graph.LinkNode(2, 1);
            graph.LinkNode(3, 1);

            var topoSort = graph.TopologicalSort();
            Assert.IsTrue(topoSort.SequenceEqual([4, 5, 6, 2, 3, 1]));
        }
    }
}
