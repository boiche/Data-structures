using DesignPatterns.Behavioral.Visitor;
using DesignPatterns.Structural.Composite.Interfaces;

namespace DesignPatterns.Structural.Composite.Tags
{
    public class HtmlTag : HtmlTagBase, IHtmlTag, IHtmlTagVisitable
    {
        public HtmlTag() : base("html") { }
        public override string Content { get => default; set { } }
    }
}
