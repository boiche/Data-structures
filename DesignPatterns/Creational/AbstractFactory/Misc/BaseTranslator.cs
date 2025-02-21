namespace DesignPatterns.Creational.AbstractFactory.Misc
{
    public abstract class BaseTranslator
    {
        protected Languages _from;
        protected Languages _to;
        public BaseTranslator(Languages from, Languages to)
        {
            _from = from;
            _to = to;
        }
        public virtual string Translate(string word)
        {
            //do some translating magic
            string translated = "djan djun";
            return translated;
        }
    }
}
