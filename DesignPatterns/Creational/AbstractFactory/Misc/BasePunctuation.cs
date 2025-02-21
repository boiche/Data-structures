using System.Text.RegularExpressions;

namespace DesignPatterns.Creational.AbstractFactory.Misc
{
    /// <summary>
    /// Provides interface for checking text is correctly written. For given example encoding is neglected
    /// </summary>
    public abstract class BasePunctuation
    {
        protected Regex _dotPatterns = new("\\w+\\.");
        private readonly Languages _language;

        public BasePunctuation(Languages language)
        {
            _language = language;
        }

        /// <summary>
        /// Check if passed text is valid based
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public virtual bool IsValid(string sentence)
        {
            //some other general conditions for valid sentence
            //switch _language wether is left-right or right-left oriented (Bulgarian/Arabian)
            if ((int)_language > 99)
                return sentence[0] == '.' && char.IsUpper(sentence[^1]);
            else
                return _dotPatterns.IsMatch(sentence) && char.IsUpper(sentence[0]);
        }
    }
}
