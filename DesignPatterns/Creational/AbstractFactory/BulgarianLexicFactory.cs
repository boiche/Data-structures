using DesignPatterns.Creational.AbstractFactory.Misc;

namespace DesignPatterns.Creational.AbstractFactory
{
    internal class BulgarianLexicFactory : BaseLexicFactory
    {
        public override BulgarianDictionary CreateDictionary()
        {
            //read words from stream
            //save them in some kind of DB
            //cache some of them in _dictionary
            return new BulgarianDictionary();
        }

        public override BulgarianPunctuation CreatePunctuation()
        {
            //set up the props for bulgarian punctuation (i.e. get prefixes, connection words, exceptions)
            return new BulgarianPunctuation();
        }

        public override BulgarianTranslator CreateTranslator(Languages to)
        {
            //set up the source of 'to' language words. Make up mapping of words.
            return new BulgarianTranslator(to);
        }
    }
}
