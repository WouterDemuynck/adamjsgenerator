using System;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="PropertyOperationExpression" />.
    /// </summary>
    public static class PropertyOperationExpressionHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="PropertyOperationExpression" /> that performs a property operation on the specified expression.
        /// </summary>
        /// <param name="expression">The expression on which to perform the property operation.</param>
        /// <param name="member">The property to access.</param>
        /// <returns>a new instance of <see cref="PropertyOperationExpression" />.</returns>
        public static PropertyOperationExpression Dot(this Expression expression, IdentifierExpression member)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new PropertyOperationExpression(expression, member);
        }
    }
}
