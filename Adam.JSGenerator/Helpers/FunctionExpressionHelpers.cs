using System;
using System.Collections.Generic;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="FunctionExpression" />.
    /// </summary>
    public static class FunctionExpressionHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="FunctionExpression" /> based on an existing one, and adds parameters to it.
        /// </summary>
        /// <param name="expression">The instance of <see cref="FunctionExpression" /> to copy the <see cref="FunctionExpression.Name" /> and <see cref="FunctionExpression.Body" /> from.</param>
        /// <param name="parameters">An array of parameters to add to the new instance.</param>
        /// <returns>a new instance of <see cref="FunctionExpression" />.</returns>
        public static FunctionExpression Parameters(this FunctionExpression expression, params IdentifierExpression[] parameters)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new FunctionExpression(expression.Name, parameters, expression.Body);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FunctionExpression" /> based on an existing one, and adds parameters to it.
        /// </summary>
        /// <param name="expression">The instance of <see cref="FunctionExpression" /> to copy the <see cref="FunctionExpression.Name" /> and <see cref="FunctionExpression.Body" /> from.</param>
        /// <param name="parameters">A sequence of parameters to add to the new instance.</param>
        /// <returns>a new instance of <see cref="FunctionExpression" />.</returns>
        public static FunctionExpression Parameters(this FunctionExpression expression, IEnumerable<IdentifierExpression> parameters)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new FunctionExpression(expression.Name, parameters, expression.Body);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FunctionExpression" /> based on an existing one, and adds statements to it.
        /// </summary>
        /// <param name="expression">The instance of <see cref="FunctionExpression" /> to copy the <see cref="FunctionExpression.Name" /> and <see cref="FunctionExpression.Parameters" /> from.</param>
        /// <param name="statements">An array of statements to add to the body of the function.</param>
        /// <returns>a new instance of <see cref="FunctionExpression" />.</returns>
        public static FunctionExpression Do(this FunctionExpression expression, params Statement[] statements)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new FunctionExpression(expression.Name, expression.Parameters, new CompoundStatement(statements));
        }

        /// <summary>
        /// Creates a new instance of <see cref="FunctionExpression" /> based on an existing one, and adds statements to it.
        /// </summary>
        /// <param name="expression">The instance of <see cref="FunctionExpression" /> to copy the <see cref="FunctionExpression.Name" /> and <see cref="FunctionExpression.Parameters" /> from.</param>
        /// <param name="statements">A sequence of statements to add to the body of the function.</param>
        /// <returns>a new instance of <see cref="FunctionExpression" />.</returns>
        public static FunctionExpression Do(this FunctionExpression expression, IEnumerable<Statement> statements)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new FunctionExpression(expression.Name, expression.Parameters, new CompoundStatement(statements));
        }
    }
}
