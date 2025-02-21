using System.Linq;
using System.Text;

namespace Itel.Framework.DAL.GraphQL.SA.Builders
{
    /// <summary>
    /// Builds an argument expression for GraphQL queries
    /// </summary>
    public class GraphQlArgumentStatementBuilder
    {
        protected StringBuilder _clauseBuilder;
        private WhereStatementBuilder _whereClause;
        private OrderStatementBuilder _orderClause;

        public GraphQlArgumentStatementBuilder()
        {
            _clauseBuilder = new StringBuilder();
        }

        /// <summary>
        /// Provides builder for creating 'where' argument clause
        /// </summary>
        /// <returns></returns>
        public WhereStatementBuilder Where()
        {
            Init();

            if (_whereClause == null) 
                _whereClause = new WhereStatementBuilder(ref _clauseBuilder);

            if (_clauseBuilder.Length > 1)
            {
                var openings = _clauseBuilder.ToString().Count(x => x == '{');
                var closings = _clauseBuilder.ToString().Count(x => x == '}');

                _clauseBuilder.Append($"{new string('}', openings - closings)}, ");
            }

            _clauseBuilder.Append("where: ");
            return _whereClause;
        }

        /// <summary>
        /// Provides builder for creating 'order' argument clause
        /// </summary>
        /// <returns></returns>
        public OrderStatementBuilder Order()
        {
            Init();

            if (_clauseBuilder.Length > 1)
            {
                var openings = _clauseBuilder.ToString().Count(x => x == '{');
                var closings = _clauseBuilder.ToString().Count(x => x == '}');

                _clauseBuilder.Append($"{new string('}', openings - closings)}, ");
            }

            _clauseBuilder.Append("order: ");
            return _orderClause;
        }

        private void Init()
        {
            _orderClause = new OrderStatementBuilder(ref _clauseBuilder);

            if (_clauseBuilder.Length == 0)
                _clauseBuilder.Append('(');
        }
    }
}
