using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.Misc
{
    public class WordData
    {
        public string Meaning { get; set; }
        public string Plural { get; set; }
        public string Gender { get; set; }
        /// <summary>
        /// Suppose that words have IDs : int
        /// </summary>
        public IEnumerable<int> Synonyms { get; set; }
    }
}
