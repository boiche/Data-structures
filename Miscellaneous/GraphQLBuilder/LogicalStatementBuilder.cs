using System.Linq;

namespace Itel.Framework.DAL.GraphQL.SA.Builders
{
    /// <summary>
    /// Builds boolean relation between where statements for GraphQL queries
    /// </summary>
    public class LogicalStatementBuilder : GraphQlArgumentStatementBuilder
    {
        internal WhereStatementBuilder _whereClauseBuilder;

        internal LogicalStatementBuilder(WhereStatementBuilder whereClauseBuilder)
        {
            _whereClauseBuilder = whereClauseBuilder;
        }

        /// <summary>
        /// Appends two where clauses with logical 'and'
        /// </summary>
        /// <returns></returns>
        public WhereStatementBuilder And()
        {
            _clauseBuilder.Append(" and: ");

            return _whereClauseBuilder;
        }

        /// <summary>
        /// Appends two where clauses with logical 'or'
        /// </summary>
        /// <returns></returns>
        public WhereStatementBuilder Or()
        {
            _clauseBuilder.Append(" or: ");

            return _whereClauseBuilder;
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
            return result;
        }
    }
}
