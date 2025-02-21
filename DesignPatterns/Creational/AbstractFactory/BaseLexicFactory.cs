using DesignPatterns.Creational.AbstractFactory.Misc;

namespace DesignPatterns.Creational.AbstractFactory
{
    public abstract class BaseLexicFactory
    {
        public abstract BaseDictionary CreateDictionary();
        public abstract BasePunctuation CreatePunctuation();
        public abstract BaseTranslator CreateTranslator(Languages to);
    }
}
