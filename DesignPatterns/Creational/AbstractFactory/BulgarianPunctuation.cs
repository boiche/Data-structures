using DesignPatterns.Creational.AbstractFactory.Misc;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class BulgarianPunctuation : BasePunctuation
    {
        public BulgarianPunctuation() : base(Languages.Bulgarian)
        {
        }

        public override bool IsValid(string sentence)
        {
            var result = base.IsValid(sentence);
            return result && SomeBulgarianPunctuation();
        }

        private bool SomeBulgarianPunctuation()
        {
            return false;
        }
    }
}