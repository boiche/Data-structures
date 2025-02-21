using DesignPatterns.Creational.AbstractFactory.Misc;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class BulgarianTranslator : BaseTranslator
    {
        public BulgarianTranslator(Languages to) : base(Languages.Bulgarian, to)
        {
        }

        public override string Translate(string word)
        {
            //obtain source for 'to' language and perform mapping
            return base.Translate(word);
        }
    }
}