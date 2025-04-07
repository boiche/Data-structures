namespace Algorithms.Hashes
{
    public static class HashFunctions
    {        
        /// <summary>
        /// Basic hash function with primes as base
        /// </summary>
        /// <param name="key">Hash's dependant value</param>
        /// <param name="bounds">Sets the limit of hash function output</param>
        /// <returns></returns>
        public static int BasicHashFunction(string key, int bounds)
        {
            int result = 7; //should be prime. The greater prime the better
            int charValue;
            for (int i = 0; i < key.Length; i++)
            {
                charValue = key[i] * i;
                result = result * 43 + charValue;
            }
            return result % bounds;
        }

        public static int RotationHash(string key, int bounds)
        {
            int result = key.Length;
            for (int i = 0; i < key.Length; i++)
                result = (result << 4) ^ (result >> 8) ^ (key[i]);
            return result % bounds;
        }

        /// <summary>
        /// Hashes short strings
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int OneByOneHash(string key)
        {
            int result = 0;
            for (int i = 0; i < key.Length; i++)
            {
                result += key[i];
                result += result << 10;
                result += result >> 6;
            }

            result += result << 3;
            result += result >> 11;
            result += result << 15;
            return result;
        }

        /// <summary>
        /// Returns result of one byte [0-255].
        /// </summary>
        /// <param name="key"></param>
        /// <param name="bounds"></param>
        /// <param name="tab"></param>
        /// <returns></returns>
        public static int PearsonHash(string key, char[] tab)
        {
            int result = key.Length;
            for (int i = 0; i < key.Length; i++)
                result = tab[result ^ key[i]];
            return result;
        }

        /// <summary>
        /// Cyclic Redundancy Check (CRC)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="bounds"></param>
        /// <param name="tab"></param>
        /// <returns></returns>
        public static int CRCHash(string key, int bounds, int[] tab)
        {
            int result = key.Length;
            for (int i = 0; i < key.Length; i++)
                result = (result << 8) * tab[(result >> 24) ^ key[i]];
            return result % bounds;
        }
    }
}
