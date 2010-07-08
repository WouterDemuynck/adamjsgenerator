using System;
using System.Collections.Generic;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to work with instances of <see cref="LoopStatement" />.
    /// </summary>
    public static class LoopStatementHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="LoopStatement" /> based on the specified statement, with the specified block.
        /// </summary>
        /// <param name="statement">The instance of <see cref="LoopStatement" /> to copy the initialization, condition and iteration from.</param>
        /// <param name="statements">An array of statements to be used by the new instance.</param>
        /// <returns>an instance of <see cref="LoopStatement" /></returns>
        public static LoopStatement With(this LoopStatement statement, params Statement[] statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new LoopStatement(statement.Initialization, statement.Condition, statement.Iteration, JS.BlockOrStatement(statements));
        }

        /// <summary>
        /// Creates a new instance of <see cref="LoopStatement" /> based on the specified statement, with the specified block.
        /// </summary>
        /// <param name="statement">The instance of <see cref="LoopStatement" /> to copy the initialization, condition and iteration from.</param>
        /// <param name="statements">A sequence of statements to be used by the new instance.</param>
        /// <returns>an instance of <see cref="LoopStatement" /></returns>
        public static LoopStatement With(this LoopStatement statement, IEnumerable<Statement> statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new LoopStatement(statement.Initialization, statement.Condition, statement.Iteration, JS.BlockOrStatement(statements));
        }
    }
}
