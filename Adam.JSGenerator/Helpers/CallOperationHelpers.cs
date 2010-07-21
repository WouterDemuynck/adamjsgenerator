using System;
using System.Collections;
using System.Collections.Generic;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="CallOperationExpression" />
    /// </summary>
    public static class CallOperationExpressionHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="CallOperationExpression" /> that performs a call operation using the specified arguments.
        /// </summary>
        /// <param name="expression">The expression to perform the call operation on.</param>
        /// <param name="arguments">An arrary of arguments to pass in the call operation.</param>
        /// <returns>a new instance of <see cref="CallOperationExpression" /></returns>
        public static CallOperationExpression Call(this Expression expression, params Expression[] arguments)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new CallOperationExpression(expression, arguments);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CallOperationExpression" /> that performs a call operation using the specified arguments.
        /// </summary>
        /// <param name="expression">The expression to perform the call operation on.</param>
        /// <param name="arguments">A sequence of arguments to pass in the call operation.</param>
        /// <returns>a new instance of <see cref="CallOperationExpression" /></returns>
        public static CallOperationExpression Call(this Expression expression, IEnumerable<Expression> arguments)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new CallOperationExpression(expression, arguments);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CallOperationExpression" /> that performs a call operation using the specified arguments.
        /// </summary>
        /// <param name="expression">The expression to perform the call operation on.</param>
        /// <param name="arguments">An arrary of arguments to pass in the call operation.</param>
        /// <returns>a new instance of <see cref="CallOperationExpression" /></returns>
        public static CallOperationExpression Call(this object expression, params object[] arguments)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new CallOperationExpression(expression, arguments);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CallOperationExpression" /> that performs a call operation using the specified arguments.
        /// </summary>
        /// <param name="expression">The expression to perform the call operation on.</param>
        /// <param name="arguments">A sequence of arguments to pass in the call operation.</param>
        /// <returns>a new instance of <see cref="CallOperationExpression" /></returns>
        public static CallOperationExpression Call(this object expression, IEnumerable arguments)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new CallOperationExpression(expression, arguments);
        }

    }
}
