using DataStructures.Graphs.Interfaces;
using DataStructures.Graphs.Nodes.Interfaces;
using DataStructures.Linear.LinkedLists;
using System;
using System.Collections.Generic;

namespace DataStructures.Graphs
{
    public static class GraphFactory<T> where T : INode
    {
        public static IGraph<T> FromAdjacencyArray(T[][] values)
        {
            throw new NotImplementedException();
        }

        public static IGraph<T> FromAdjacencyArray(T[,] values)
        {
            throw new NotImplementedException();
        }

        public static IGraph<T> FromAdjacencyList(SingleLinkedList<T> values)
        {
            throw new NotImplementedException();
        }        
    }

    public static class WeightedGraphFactory<T> where T : IWeightedNode
    {
        public static IWeightedGraph<T> FromIndicesArray(T[][] values)
        {
            throw new NotImplementedException();
        }

        public static IWeightedGraph<T> FromIndicesArray(T[,] values)
        {
            throw new NotImplementedException();
        }

        public static IWeightedGraph<T> FromHashTable<W>(Dictionary<T, (T edge, W weight)> values)
        {
            throw new NotImplementedException();
        }
    }
}
