using DesignPatterns.Behavioral.Visitor;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Composite.Interfaces
{
    public interface IHtmlTag : IHtmlTagVisitable
    {
        ICollection<IHtmlTag> Children { get; }
        void Add(IHtmlTag tag);
        void Remove(IHtmlTag tag);
        string Content { get; set; }
    }
}
