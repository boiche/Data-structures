using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.Misc
{
    public abstract class BaseDictionary
    {
        protected Languages language;
        protected IDictionary<string, WordData> _dictionary;

        public BaseDictionary(Languages language)
        {
            this.language = language;
        }

        public virtual string GetMeaning(string word)
        {
            return GetWordData(word).Value.Meaning;
        }

        public virtual string GetPlural(string word)
        {
            return GetWordData(word).Value.Plural;
        }

        public virtual string GetGender(string word)
        {
            return GetWordData(word).Value.Gender;
        }

        public virtual IEnumerable<int> GetSynonyms(string word)
        {
            return GetWordData(word).Value.Synonyms;
        }

        protected virtual KeyValuePair<string, WordData> GetWordData(string word)
        {
            if (!_dictionary.TryGetValue(word, out WordData value))
                throw new KeyNotFoundException($"{word} is not defined in current dictionary");
            return new KeyValuePair<string, WordData>(word, value);
        }
    }
}
