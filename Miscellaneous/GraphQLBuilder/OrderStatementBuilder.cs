using System.Text;

namespace Itel.Framework.DAL.GraphQL.SA.Builders
{
    /// <summary>
    /// Builds an 'order' argument clause for GraphQL queries
    /// </summary>
    public sealed class OrderStatementBuilder
    {
        private readonly StringBuilder _clauseBuilder;
        private int _orderStatements;

        internal OrderStatementBuilder(ref StringBuilder clauseBuilder)
        {
            _clauseBuilder = clauseBuilder;
            _orderStatements = 0;
        }

        /// <summary>
        /// Orders given field in ascending order
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public OrderStatementBuilder Asc(string fieldName)
        {
            if (_orderStatements > 0)
                _clauseBuilder.Append(", ");
            else
                _clauseBuilder.Append('{');

            _clauseBuilder.Append($"{fieldName}: ASC");

            _orderStatements++;
            return this;
        }

        /// <summary>
        /// Orders given field in descending order
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public OrderStatementBuilder Desc(string fieldName)
        {
            if (_orderStatements > 0)
                _clauseBuilder.Append(", ");
            else
                _clauseBuilder.Append('{');

            _clauseBuilder.Append($"{fieldName}: DESC");

            _orderStatements++;
            return this;
        }

        /// <summary>
        /// Builds the argument statement as string
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            if (_clauseBuilder.Length > 1)
            {
                var openings = _clauseBuilder.ToString().Count(x => x == '{');
                var closings = _clauseBuilder.ToString().Count(x => x == '}');

                _clauseBuilder.Append($"{new string('}', openings - closings)})");
            }

            string result = _clauseBuilder.ToString();
            _clauseBuilder.Clear();
            _orderStatements = 0;
            return result;
        }
    }
}
