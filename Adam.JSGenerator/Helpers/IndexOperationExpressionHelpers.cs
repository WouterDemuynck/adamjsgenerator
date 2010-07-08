using System;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to work with instances of <see cref="IndexOperationExpression" />.
    /// </summary>
    public static class IndexOperationExpressionHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="IndexOperationExpression" /> that performs an index operation.
        /// </summary>
        /// <param name="expression">An expression to perform an index operation on.</param>
        /// <param name="operand">The index to retrieve.</param>
        /// <returns></returns>
        public static IndexOperationExpression Index(this Expression expression, Expression operand)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new IndexOperationExpression(expression, operand);
        }
    }
}
