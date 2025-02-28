using System;
using System.Text;

namespace Algorithms.Other
{
    public class LongestCommonSubsequence(string first, string second)
    {
        private StringBuilder resultBuilder;

        /// <summary>
        /// Time: O(m * n * Min(m,n)) <para></para> Space: O(1)
        /// </summary>
        /// <returns></returns>
        public string Iterative()
        {
            string result = string.Empty;

            int m = first.Length;
            int n = second.Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i >= m)
                        break;

                    if (first[i] == second[j])
                    {
                        StringBuilder current = new();
                        int counter = 0;
                        while (i + counter < m && j + counter < n && first[i + counter] == second[j + counter])
                        {
                            current.Append(second[j + counter]);
                            counter++;
                        }

                        if (current.Length > result.Length)
                            result = current.ToString();
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// Time: O(m * n) <para></para> Space: O(Min(m,n))
        /// </summary>
        /// <returns></returns>
        public string DynamicProgramming()
        {
            string max = string.Empty;
            string[,] locals = new string[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        locals[i, j] = $"{locals[i - 1, j - 1]}{second[j - 1]}";
                        if (locals[i, j].Length > max.Length)                        
                            max = locals[i, j];
                    }
                }
            }

            return max;
        }
        /// <summary>
        /// Time: O(m * n * Min(m,n)) <para></para>Space: O(Min(m,n))
        /// </summary>
        /// <returns></returns>
        public string Recursive()
        {
            string max = string.Empty;

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    string result = Recursive(i, j);
                    if (result.Length > max.Length)
                        max = result;
                }
            }

            return max;
        }        

        private string Recursive(int m, int n)
        {
            if (m == 0 || n == 0 || first[m - 1] != second[n - 1])
                return string.Empty;

            return $"{Recursive(m - 1, n - 1)}{first[m - 1]}";
        }        
    }
}
