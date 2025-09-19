using DesignPatterns.Behavioral.Visitor;
using DesignPatterns.Structural.Composite.Interfaces;

namespace DesignPatterns.Structural.Composite.Tags
{
    public class BodyTag : HtmlTagBase, IHtmlTagVisitable
    {
        public BodyTag() : base("body") { }

        public override string Content { get => default; set { } }
    }
}
