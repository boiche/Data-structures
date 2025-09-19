using DesignPatterns.Behavioral.Visitor;
using DesignPatterns.Structural.Composite.Interfaces;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Composite.Tags
{
    public sealed class ParagraphTag : HtmlTagBase, IHtmlTagVisitable
    {
        public ParagraphTag() : base("p") { }
        public override ICollection<IHtmlTag> Children => null;
        public override string Content { get; set; }
        public void Accept(IHtmlTagVisitor visitor)
        {
            visitor.Visit(this);
        }
        public override string ToString()
        {
            return $"<{_header}>{Content}</{_header}>";
        }
    }
}
