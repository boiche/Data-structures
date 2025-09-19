namespace DesignPatterns.Behavioral.Visitor
{
    public interface IHtmlTagVisitable
    {
        void Accept(IHtmlTagVisitor visitor);
    }
}
