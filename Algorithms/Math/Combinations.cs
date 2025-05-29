using System.Collections.Generic;

namespace Algorithms.Math
{
    public static class Combinations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">Elements to generate combinations</param>
        /// <param name="k">Number of positions</param>
        /// <returns></returns>
        public static IList<IList<T>> Generate<T>(IList<T> source, int k)
        {
            List<IList<T>> result = [];
            List<T> temp = [];
            GenerateCombinations(source, 0, k, temp, result);
            return result;
        }

        private static void GenerateCombinations<T>(IList<T> source, int numbersLeft, int k, List<T> temp, List<IList<T>> result)
        {
            if (k == 0)
            {
                result.Add(new List<T>(temp));
                return;
            }

            for (int i = numbersLeft; i < source.Count; i++)
            {
                temp.Add(source[i]);
                GenerateCombinations(source, i + 1, k - 1, temp, result);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
