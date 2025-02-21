using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Math
{
    public static class Combinations
    {
        private static List<IEnumerable<int>> list;
        private static List<int> temp;
        public static IEnumerable<IEnumerable<int>> Generate(int n, int k)
        {
            list = new List<IEnumerable<int>>();
            temp = new List<int>();
            GenerateCombinations(n, 1, k);
            return list;
        }

        private static void GenerateCombinations(int n, int numbersLeft, int k)
        {
            if (k == 0)
            {
                list.Add(temp);
                return;
            }

            for (int i = numbersLeft; i <= n; i++)
            {
                temp.Add(i);
                GenerateCombinations(n, i + 1, k - 1);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
