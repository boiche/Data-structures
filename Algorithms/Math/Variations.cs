using System.Collections.Generic;

namespace Algorithms.Math
{
    public static class Variations
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
            bool[] added = new bool[source.Count];
            GenerateVariations(source, k, temp, result, added);
            return result;
        }

        private static void GenerateVariations<T>(IList<T> source, int k, List<T> temp, List<IList<T>> result, bool[] added)
        {
            if (k == 0)
            {
                result.Add(new List<T>(temp));
                return;
            }

            for (int i = 0; i < source.Count; i++)
            {
                if (added[i])
                    continue;

                temp.Add(source[i]);
                added[i] = true;

                GenerateVariations(source, k - 1, temp, result, added);

                temp.RemoveAt(temp.Count - 1);
                added[i] = false;
            }
        }
    }
}
