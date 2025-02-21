namespace DesignPatterns.Creational.AbstractFactory.Misc
{
    public class BulgarianDictionary : BaseDictionary
    {
        public BulgarianDictionary() : base(Languages.Bulgarian)
        {
        }

        public override string GetGender(string word)
        {
            //some bulgarian stuff here
            return base.GetGender(word);
        }
    }
}
