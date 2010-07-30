using System;
using System.Collections.Generic;
using System.Linq;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="WhileStatement" />.
    /// </summary>
    public static class WhileStatementHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="WhileStatement" />, copying the specified statement's condition, and adding the specified sequence of statements to the body.
        /// </summary>
        /// <param name="statement">The statement to copy the condition from.</param>
        /// <param name="statements">A sequence of statements to add to the body.</param>
        /// <returns>a new instance of <see cref="WhileStatement" /></returns>
        public static WhileStatement Do(this WhileStatement statement, IEnumerable<Statement> statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return Do(statement, statements.ToArray());
        }

        /// <summary>
        /// Creates a new instance of <see cref="WhileStatement" />, copying the specified statement's condition, and adding the specified array of statements to the body.
        /// </summary>
        /// <param name="statement">The statement to copy the condition from.</param>
        /// <param name="statements">An array of statements to add to the body.</param>
        /// <returns>a new instance of <see cref="WhileStatement" /></returns>
        public static WhileStatement Do(this WhileStatement statement, params Statement[] statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new WhileStatement(statement.Condition, JS.BlockOrStatement(statements));
        }
    }
}
