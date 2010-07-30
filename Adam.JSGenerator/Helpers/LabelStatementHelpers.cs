using System;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods for creating new instances of <see cref="LabelStatement" />
    /// </summary>
    public static class LabelStatementHelpers
    {
        /// <summary>
        /// Precedes a statement with a new instance of <see cref="LabelStatement" /> that adds the specified label.
        /// </summary>
        /// <param name="statement">The statement to precede.</param>
        /// <param name="expression">The label to add.</param>
        /// <returns>An instance of <see cref="LabelStatement" />.</returns>
        public static LabelStatement Labeled(this Statement statement, IdentifierExpression expression)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new LabelStatement(expression, statement);
        }
    }
}
