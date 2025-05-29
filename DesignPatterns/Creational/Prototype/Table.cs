using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Creational.Prototype
{
    public class Table : Control
    {
        public int Columns { get; set; }
        public IEnumerable<object> DataSource { get; set; }

        public Table() : base() { }

        public override void Render()
        {
            _htmlBuilder.Append("<table>");
            AddRow(true);
            foreach (var item in DataSource)
            {
                AddRow(false, item);
            }
            _htmlBuilder.Append("</table>");
        }

        private void AddRow(bool isHeader, object source = null)
        {
            _htmlBuilder.Append("<tr>");
            if (isHeader)
            {
                foreach (var item in DataSource.GetType().GetGenericTypeDefinition().GetProperties().Select(x => x.Name))
                {
                    _htmlBuilder.Append($"<th>{item}</th>");
                }
            }
            else
            {
                foreach (var item in source.GetType().GetProperties())
                {
                    _htmlBuilder.Append($"<td>{item.GetValue(source)}</td>");
                }
            }
            _htmlBuilder.Append("</tr>");
        }
    }
}
