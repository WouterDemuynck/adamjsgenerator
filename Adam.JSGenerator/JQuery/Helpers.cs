using System.Collections.Generic;

namespace Adam.JSGenerator.JQuery
{
    ///<summary>
    /// Serves as an example for writing extension methods.
    ///</summary>
    public static class Helpers
    {
        /// <summary>
        /// Add elements to the set of matched elements.
        /// </summary>
        /// <param name="expression">The set of matched elements to add to.</param>
        /// <param name="arguments">The arguments to pass to the function.</param>
        /// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
        public static CallOperationExpression Add(Expression expression, params Expression[] arguments)
        {
            return new CallOperationExpression(expression.Dot("add"), arguments);
        }

        /// <summary>
        /// Add elements to the set of matched elements.
        /// </summary>
        /// <param name="expression">The set of matched elements to add to.</param>
        /// <param name="arguments">The arguments to pass to the function.</param>
        /// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
        public static CallOperationExpression Add(Expression expression, IEnumerable<Expression> arguments)
        {
            return new CallOperationExpression(expression.Dot("add"), arguments);
        }

        /// <summary>
        /// Adds the specified class(es) to each of the set of matched elements.
        /// </summary>
        /// <param name="expression">The set of matched elements to call this function on.</param>
        /// <param name="argument">The argument to pass to the function.</param>
        /// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
        public static CallOperationExpression AddClass(this Expression expression, Expression argument)
        {
            return new CallOperationExpression(expression.Dot("addClass"), argument);
        }

        /// <summary>
        ///  Insert content, specified by the parameter, after each element in the set of matched elements.
        /// </summary>
        /// <param name="expression">The set of matched elements to call this function on.</param>
        /// <param name="argument">The argument to pass to the function.</param>
        /// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
        public static CallOperationExpression After(this Expression expression, Expression argument)
        {
            return new CallOperationExpression(expression.Dot("after"), argument);
        }

        /// <summary>
        /// Insert content, specified by the parameter, to the end of each element in the set of matched elements.
        /// </summary>
        /// <param name="expression">The set of matched elements to call this function on.</param>
        /// <param name="argument">The argument to pass to the function.</param>
        /// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
        public static CallOperationExpression Append(this Expression expression, Expression argument)
        {
            return new CallOperationExpression(expression.Dot("append"), argument);
        }

        /// <summary>
        /// Store arbitrary data associated with the matched elements.
        /// </summary>
        /// <param name="expression">The set of matched elements to call this function on.</param>
        /// <param name="key">The key argument to pass to the function.</param>
        /// <param name="value">The value argument to pass to the function.</param>
        /// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
        public static CallOperationExpression Data(this Expression expression, Expression key, Expression value)
        {
            return new CallOperationExpression(expression.Dot("data"), key, value);
        }

        // And so on...
    }
}
