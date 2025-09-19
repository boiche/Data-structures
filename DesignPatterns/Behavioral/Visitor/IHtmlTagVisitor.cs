using DesignPatterns.Structural.Composite.Interfaces;

namespace DesignPatterns.Behavioral.Visitor
{
    public interface IHtmlTagVisitor
    {
        void Visit(HtmlTagBase tag);
    }
}
