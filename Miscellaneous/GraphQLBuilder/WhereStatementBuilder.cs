using System.Text;

namespace Itel.Framework.DAL.GraphQL.SA.Builders
{
    /// <summary>
    /// Builds a 'where' argument clause for GraphQL queries
    /// </summary>
    public sealed class WhereStatementBuilder
    {
        private readonly StringBuilder _clauseBuilder;
        private readonly LogicalStatementBuilder _logicalClause;

        internal WhereStatementBuilder(ref StringBuilder clauseBuilder)
        {
            _clauseBuilder = clauseBuilder;
            _logicalClause = new LogicalStatementBuilder(this);
        }

        /// <summary>
        /// Constructs a single where statement
        /// </summary>
        /// <param name="fieldName">Field to be filtered</param>
        /// <param name="operatorType">Kind of filter operation</param>
        /// <param name="value">Value to be filtered</param>
        /// <returns>Builder for creating boolean relation between where statements</returns>
        public LogicalStatementBuilder Field(string fieldName, ComparisonOperator operatorType, object value)
        {

            _clauseBuilder.Append($"{{ {fieldName}: {{ {operatorType}: {value} }}");

            return _logicalClause;
        }
    }
}
