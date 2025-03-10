using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Other
{
    public static partial class GraphExtensions
    {
        private static readonly (int row, int col)[] directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];
        private static int index = 0;
        private static int[] result;
        private static int rows;
        private static int cols;

        public static int[] DFS_Recursive(this int[][] source)
        {
            Reset();

            rows = source.Length;
            cols = source[0].Length;

            result = new int[rows * cols];
           
            bool[,] visited = new bool[rows, cols];

            return DFS_Recursive(new(0, 0), source, visited);
        }
        public static int[] DFS_Linear(this int[][] source)
        {
            Reset();

            rows = source.Length;
            cols = source[0].Length;

            result = new int[rows * cols];
            bool[,] visited = new bool[rows, cols];
            Stack<MatrixIndex> stack = new();
            stack.Push(new(0, 0));

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                for (int i = 0; i < directions.Length; i++)
                {
                    MatrixIndex next = new(current.row + directions[i].row, current.col + directions[i].col);
                    if (IsInBounds(source, next) && !visited[next.row, next.col])
                        stack.Push(next);
                }

                if (!visited[current.row, current.col])
                {
                    result[index++] = source[current.row][current.col];
                    visited[current.row, current.col] = true;
                }
            }

            return result;
        }
        public static int[] BFS(this int[][] source)
        {
            Reset();

            rows = source.Length;
            cols = source[0].Length;

            result = new int[rows * cols];
            bool[,] visited = new bool[rows, cols];
            Queue<MatrixIndex> stack = new();
            stack.Enqueue(new(0, 0));

            while (stack.Count > 0)
            {
                var current = stack.Dequeue();

                for (int i = 0; i < directions.Length; i++)
                {
                    MatrixIndex next = new(current.row + directions[i].row, current.col + directions[i].col);
                    if (IsInBounds(source, next) && !visited[next.row, next.col])
                        stack.Enqueue(next);
                }

                if (!visited[current.row, current.col])
                {
                    result[index++] = source[current.row][current.col];
                    visited[current.row, current.col] = true;
                }
            }

            return result;
        }        
        
        private static int[] DFS_Recursive(MatrixIndex current, int[][] source, bool[,] visited)
        {
            if (!IsInBounds(source, current) || visited[current.row, current.col])
                return result;

            visited[current.row, current.col] = true;
            SortedList<int, MatrixIndex> neighbours = new();

            for (int i = 0; i < directions.Length; i++)
            {                
                MatrixIndex next = new(current.row + directions[i].row, current.col + directions[i].col);
                if (IsInBounds(source, next) && !visited[next.row, next.col])
                    neighbours.Add(source[next.row][next.col], next);
            }
            foreach (var neighbour in neighbours)
            {
                DFS_Recursive(neighbour.Value, source, visited);
            }

            if (!result.Contains(source[current.row][current.col]))
                result[index++] = source[current.row][current.col];

            return result;
        }

        private static bool IsInBounds(int[][] source, MatrixIndex current)
        {
            if (current.row < 0 || current.row >= rows)
                return false;
            if (current.col < 0 || current.col >= cols)
                return false;

            return true;
        }

        private static void Reset()
        {
            index = 0;
            result = Array.Empty<int>();
            cols = 0;
            rows = 0;
        }
    }

    internal struct MatrixIndex(int row, int col)
    {
        public readonly int row = row;
        public readonly int col = col;
    }
}
