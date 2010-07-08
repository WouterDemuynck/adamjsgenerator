using System;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="DoWhileStatement" />.
    /// </summary>
    public static class DoWhileStatementHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="DoWhileStatement" /> and adds a condition.
        /// </summary>
        /// <param name="whileStatement">The existing instance of <see cref="DoWhileStatement" /> to copy the <see cref="DoWhileStatement.Statement" /> from.</param>
        /// <param name="condition">The condition to add to the new instance.</param>
        /// <returns>a new instance of <see cref="DoWhileStatement" />.</returns>
        public static DoWhileStatement While(this DoWhileStatement whileStatement, Expression condition)
        {
            if (whileStatement == null)
            {
                throw new ArgumentNullException("whileStatement");
            }

            return new DoWhileStatement(condition, whileStatement.Statement);
        }
    }
}
