using DesignPatterns.Behavioral.Visitor;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Composite.Interfaces
{
    public abstract class HtmlTagBase : IHtmlTag
    {
        protected string _header;

        protected HtmlTagBase(string header)
        {
            _header = header;
            Children = [];
        }

        public virtual ICollection<IHtmlTag> Children { get; }
        public abstract string Content { get; set; }
        public string CloseTag { get => $"</{_header}>"; }
        public string OpenTag { get => $"<{_header}>"; }

        public virtual void Accept(IHtmlTagVisitor visitor)
        {
            visitor.Visit(this);
        }
        public virtual void Add(IHtmlTag tag)
        {
            Children.Add(tag);
        }
        public virtual void Remove(IHtmlTag tag)
        {
            Children.Remove(tag);
        }
    }
}
