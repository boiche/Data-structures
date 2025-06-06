﻿using DataStructures.Graphs.Interfaces;
using DataStructures.Graphs.Nodes.Interfaces;
using DataStructures.Linear.LinkedLists;
using System;
using System.Collections.Generic;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Provides methods for building <see cref="IGraph{NodeType, ValueType}"/>
    /// </summary>
    /// <typeparam name="T">Node type</typeparam>
    /// <typeparam name="V">Node's value type</typeparam>
    public static class GraphFactory<T, V> where T : INode<V>
    {
        public static IGraph<T, V> FromAdjacencyArray(T[][] values)
        {
            throw new NotImplementedException();
        }

        public static IGraph<T, V> FromAdjacencyArray(T[,] values)
        {
            throw new NotImplementedException();
        }

        public static IGraph<T, V> FromAdjacencyList(SingleLinkedList<T> values)
        {
            throw new NotImplementedException();
        }
    }

    public static class WeightedGraphFactory<T, V> where T : INode<V>
    {
        public static IWeightedGraph<T, V> FromIndicesArray(T[][] values)
        {
            throw new NotImplementedException();
        }

        public static IWeightedGraph<T, V> FromIndicesArray(T[,] values)
        {
            throw new NotImplementedException();
        }

        public static IWeightedGraph<T, V> FromHashTable<W>(Dictionary<T, (T edge, W weight)> values)
        {
            throw new NotImplementedException();
        }
    }
}
