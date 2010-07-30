using System;
using System.Collections.Generic;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods that create new instances of <see cref="WithStatement" />.
    /// </summary>
    public static class WithStatementHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="WithStatement" /> that copies the specified statement's expression, then adds statements to it.
        /// </summary>
        /// <param name="statement">The statement to copy the expression from.</param>
        /// <param name="statements">An array of statements to add to the new instance.</param>
        /// <returns>a new instance of <see cref="WithStatement" /></returns>
        public static WithStatement Do(this WithStatement statement, params Statement[] statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new WithStatement(statement.Expression, JS.BlockOrStatement(statements));
        }

        /// <summary>
        /// Creates a new instance of <see cref="WithStatement" /> that copies the specified statement's expression, then adds statements to it.
        /// </summary>
        /// <param name="statement">The statement to copy the expression from.</param>
        /// <param name="statements">A sequence of statements to add to the new instance.</param>
        /// <returns>a new instance of <see cref="WithStatement" /></returns>
        public static WithStatement Do(this WithStatement statement, IEnumerable<Statement> statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new WithStatement(statement.Expression, JS.BlockOrStatement(statements));
        }
    }
}
