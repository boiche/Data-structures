using DesignPatterns.Structural.Composite.Interfaces;
using System.Text;

namespace DesignPatterns.Behavioral.Visitor
{
    public class HtmlStringifyVisitor : IHtmlTagVisitor
    {
        private string _result;

        public string Result { get => _result; }
        public void Visit(HtmlTagBase tag)
        {
            StringBuilder builder = new();

            if (tag.Children != null && tag.Children?.Count > 0)
            {
                builder.Append(tag.OpenTag);
                foreach (var item in tag.Children)
                {
                    HtmlStringifyVisitor nextVisitor = new();
                    item.Accept(nextVisitor);
                    builder.Append(nextVisitor.Result);
                }
                builder.Append(tag.CloseTag);
            }
            else
            {
                builder.Append(tag.ToString());
            }

            _result = builder.ToString();
        }
    }
}
