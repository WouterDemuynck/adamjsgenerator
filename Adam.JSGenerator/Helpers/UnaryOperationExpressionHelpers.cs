using System;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="UnaryOperationExpression" />
    /// </summary>
    public static class UnaryOperationExpressionHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a bitwise not operation.
        /// </summary>
        /// <param name="expression">The expression on which to perform a bitwise not operation.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression BitwiseNot(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.BitwiseNot);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a delete operation.
        /// </summary>
        /// <param name="expression">The expression to delete.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression Delete(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.Delete);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that embeds the specified expression in parens.
        /// </summary>
        /// <param name="expression">The expression to embed in parens.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression Group(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.Group);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a logical not operation.
        /// </summary>
        /// <param name="expression">The expression on which to perform a logical not operation.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression LogicalNot(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.LogicalNot);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that negates the specified expression.
        /// </summary>
        /// <param name="expression">The expression to negate.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression Negative(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.Negative);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that creates a new object from the specified constructor.
        /// </summary>
        /// <param name="expression">An expression that returns a constructor.</param>
        /// <param name="parameters">The parameters to supply to the constructor.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        /// <remarks>
        /// This method creates a new instance of <see cref="UnaryOperationExpression" /> that creates a new object from the specified constructor. The result looks like this:
        /// <code>
        /// new constructor(parameters)
        /// </code>
        /// The constructor can be any expression as long as it returns a constructor, a function that initializes a new instance.
        /// </remarks>
        public static UnaryOperationExpression New(this Expression expression, params Expression[] parameters)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(new CallOperationExpression(expression, parameters), UnaryOperator.New);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that converts an expression to a number.
        /// </summary>
        /// <param name="expression">The expression to convert to a number.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        /// <remarks>
        /// Even though some sources state that the unary + operator is close to a no-op, the standard ECMA-262 clearly states its
        /// purpose on p.72: to convert an expression to a number. If the expression cannot be converted, NaN is returned.
        /// </remarks>
        public static UnaryOperationExpression Number(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.Number);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a post-decrement operation.
        /// </summary>
        /// <param name="expression">The expression to post-decremenet.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression PostDecrement(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.PostDecrement);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a post-increment operation.
        /// </summary>
        /// <param name="expression">The expression to post-incremenet.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression PostIncrement(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.PostIncrement);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a pre-decremenet operation.
        /// </summary>
        /// <param name="expression">The expression to pre-decrement.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression PreDecrement(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.PreDecrement);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a pre-increment operation.
        /// </summary>
        /// <param name="expression">The expression to pre-increment.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression PreIncrement(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.PreIncrement);
        }

        /// <summary>
        /// Creates an instance of <see cref="UnaryOperationExpression" /> that returns the type of the specified expression.
        /// </summary>
        public static UnaryOperationExpression TypeOf(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new UnaryOperationExpression(expression, UnaryOperator.TypeOf);
        }
    }
}
