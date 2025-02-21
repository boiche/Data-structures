using DataStructures.Linear.LinkedLists;
using DataStructures.Recursive.Graphs.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Recursive.Graphs
{
    public static class GraphFactory<T>
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

    public static class WeightedGraphFactory<T, W>
    {
        public static IWeightedGraph<T, W> FromIndicesArray(T[][] values)
        {
            throw new NotImplementedException();
        }

        public static IWeightedGraph<T, W> FromIndicesArray(T[,] values)
        {
            throw new NotImplementedException();
        }

        public static IWeightedGraph<T, W> FromHashTable(Dictionary<T, (T edge, W weight)> values)
        {
            throw new NotImplementedException();
        }
    }
}
