using Algorithms.Graphs;
using DataStructures.Graphs.Interfaces;
using DataStructures.Graphs.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class DijkstraTests
    {
        [TestMethod]
        public void Dijkstra_WorksCorrectly()
        {
            WeightedGraph<Node<int>, int> graph = new();

            for (int i = 0; i < 7; i++)
                graph.CreateNode(i);

            graph.LinkNode(graph.Nodes[0], graph.Nodes[2], 6);
            graph.LinkNode(graph.Nodes[0], graph.Nodes[1], 2);
            graph.LinkNode(graph.Nodes[2], graph.Nodes[3], 8);
            graph.LinkNode(graph.Nodes[1], graph.Nodes[3], 5);
            graph.LinkNode(graph.Nodes[3], graph.Nodes[4], 10);
            graph.LinkNode(graph.Nodes[3], graph.Nodes[5], 15);
            graph.LinkNode(graph.Nodes[4], graph.Nodes[6], 2);
            graph.LinkNode(graph.Nodes[5], graph.Nodes[6], 6);

            var result1 = graph.ShortestPath(graph.Nodes[0], graph.Nodes[6]);
            var result2 = graph.ShortestPath(graph.Nodes[3], graph.Nodes[0]);
            var result3 = graph.ShortestPath(graph.Nodes[4], graph.Nodes[5]);

            Assert.AreEqual(19, result1);
            Assert.AreEqual(7, result2);
            Assert.AreEqual(8, result3);
        }

        [TestMethod]
        public void Dijkstra_Complex_WorksCorrectly()
        {
            WeightedGraph<Node<string>, string> graph = new();
            string[] names = ["HNL", "LAX", "DFW", "SFO", "ORD", "PVD", "LGA", "MIA"];
            foreach (var name in names)
            {
                graph.CreateNode(name);
            }

            graph.LinkNode(graph.Nodes["HNL"], graph.Nodes["LAX"], 2555);
            graph.LinkNode(graph.Nodes["LAX"], graph.Nodes["SFO"], 337);
            graph.LinkNode(graph.Nodes["LAX"], graph.Nodes["ORD"], 1743);
            graph.LinkNode(graph.Nodes["LAX"], graph.Nodes["DFW"], 1233);
            graph.LinkNode(graph.Nodes["SFO"], graph.Nodes["ORD"], 1843);
            graph.LinkNode(graph.Nodes["DFW"], graph.Nodes["ORD"], 802);
            graph.LinkNode(graph.Nodes["DFW"], graph.Nodes["LGA"], 1387);
            graph.LinkNode(graph.Nodes["DFW"], graph.Nodes["MIA"], 1120);
            graph.LinkNode(graph.Nodes["ORD"], graph.Nodes["PVD"], 849);
            graph.LinkNode(graph.Nodes["LGA"], graph.Nodes["PVD"], 142);
            graph.LinkNode(graph.Nodes["LGA"], graph.Nodes["MIA"], 1099);
            graph.LinkNode(graph.Nodes["PVD"], graph.Nodes["MIA"], 1205);

            var result = graph.ShortestPath(graph.Nodes["HNL"], graph.Nodes["PVD"]);

            Assert.AreEqual(5147, result);
        }

        [TestMethod]
        public void Dijkstra_ThrowsException()
        {
            WeightedGraph<Node<int>, int> graph = new();

            for (int i = 0; i < 7; i++)
                graph.CreateNode(i);

            graph.LinkNode(graph.Nodes[0], graph.Nodes[2], 6);
            graph.LinkNode(graph.Nodes[0], graph.Nodes[1], 2);
            graph.LinkNode(graph.Nodes[2], graph.Nodes[3], 6);
            graph.LinkNode(graph.Nodes[1], graph.Nodes[3], 5);
            graph.LinkNode(graph.Nodes[3], graph.Nodes[4], 10);
            graph.LinkNode(graph.Nodes[3], graph.Nodes[5], 15);
            graph.LinkNode(graph.Nodes[4], graph.Nodes[6], 2);
            graph.LinkNode(graph.Nodes[5], graph.Nodes[6], -6);

            Assert.ThrowsException<InvalidOperationException>(() => graph.ShortestPath(graph.Nodes[0], graph.Nodes[6]));
        }
    }
}
