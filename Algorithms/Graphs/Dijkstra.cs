using DataStructures.Graphs.Interfaces;
using DataStructures.Graphs.Nodes.Interfaces;
using System.Collections.Generic;

namespace Algorithms.Graphs
{
    public static class Dijkstra
    {
        /// <summary>
        /// Computes the shortest path between <paramref name="from"/> and <paramref name="to"/>
        /// </summary>
        /// <typeparam name="NodeType"></typeparam>
        /// <typeparam name="ValueType"></typeparam>
        /// <param name="graph"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static int ShortestPath<NodeType, ValueType>(this IWeightedGraph<NodeType, ValueType> graph, NodeType from, NodeType to) where NodeType : INode<ValueType>
        {
            Dictionary<ValueType, bool> visited = [];
            Dictionary<ValueType, int> distances = [];

            int temp_distance = 0;

            foreach (var node in graph.Nodes)
            {
                visited.Add(node.Value, false);
                distances.Add(node.Value, int.MaxValue);
            }

            distances[from.Value] = 0;

            Queue<NodeType> queue = new();
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                visited[currentNode.Value] = true;

                foreach (var adjacent in currentNode.Children)
                {
                    NodeType nextNode = graph.Nodes[adjacent];
                    
                    if (!visited[adjacent])
                    {
                        IVertex currentVertex = graph.GetVertex(currentNode, nextNode);
                        if (currentVertex.Weight < 0)
                            throw new System.InvalidOperationException("Negative weight detected. Cannot compute shortest path.");
                        
                        temp_distance = distances[currentNode.Value] + currentVertex.Weight;

                        if (distances[adjacent] > temp_distance)
                        {
                            distances[adjacent] = temp_distance;
                            queue.Enqueue(nextNode);
                        }
                    }
                }
            }

            return distances[to.Value];
        }
    }
}
