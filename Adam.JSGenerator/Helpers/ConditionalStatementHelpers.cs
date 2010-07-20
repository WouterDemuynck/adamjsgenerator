using System;
using System.Collections.Generic;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="ConditionalStatement" />.
    /// </summary>
    public static class ConditionalStatementHelpers
    {
        /// <summary>
        /// Creates a copy of the specified instance of <see cref="ConditionalStatement" /> and adds a then statement.
        /// </summary>
        /// <param name="statement">The instance of <see cref="ConditionalStatement" /> to copy the <see cref="ConditionalStatement.Parent" />, 
        /// <see cref="ConditionalStatement.Condition" /> and <see cref="ConditionalStatement.ElseStatement" /> from.</param>
        /// <param name="statements">An array of statements to add to the then block of the new instance.</param>
        /// <returns>a new instance of <see cref="ConditionalStatement" />.</returns>
        public static ConditionalStatement Then(this ConditionalStatement statement, params Statement[] statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new ConditionalStatement(statement.Parent, statement.Condition, JS.BlockOrStatement(statements), statement.ElseStatement);
        }

        /// <summary>
        /// Creates a copy of the specified instance of <see cref="ConditionalStatement" /> and adds a then statement.
        /// </summary>
        /// <param name="statement">The instance of <see cref="ConditionalStatement" /> to copy the <see cref="ConditionalStatement.Parent" />, 
        /// <see cref="ConditionalStatement.Condition" /> and <see cref="ConditionalStatement.ElseStatement" /> from.</param>
        /// <param name="statements">A sequence of statements to add to the then block of the new instance.</param>
        /// <returns>a new instance of <see cref="ConditionalStatement" />.</returns>
        public static ConditionalStatement Then(this ConditionalStatement statement, IEnumerable<Statement> statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new ConditionalStatement(statement.Parent, statement.Condition, JS.BlockOrStatement(statements), statement.ElseStatement);
        }

        /// <summary>
        /// Creates a copy of the specified instance of <see cref="ConditionalStatement" /> and adds a then statement.
        /// </summary>
        /// <param name="statement">The instance of <see cref="ConditionalStatement" /> to copy the <see cref="ConditionalStatement.Parent" />, 
        /// <see cref="ConditionalStatement.Condition" /> and <see cref="ConditionalStatement.ThenStatement" /> from.</param>
        /// <param name="statements">An array of statements to add to the then block of the new instance.</param>
        /// <returns>a new instance of <see cref="ConditionalStatement" />.</returns>
        public static ConditionalStatement Else(this ConditionalStatement statement, params Statement[] statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new ConditionalStatement(statement.Parent, statement.Condition, statement.ThenStatement, JS.BlockOrStatement(statements));
        }

        /// <summary>
        /// Creates a copy of the specified instance of <see cref="ConditionalStatement" /> and adds a then statement.
        /// </summary>
        /// <param name="statement">The instance of <see cref="ConditionalStatement" /> to copy the <see cref="ConditionalStatement.Parent" />, 
        /// <see cref="ConditionalStatement.Condition" /> and <see cref="ConditionalStatement.ThenStatement" /> from.</param>
        /// <param name="statements">A sequence of statements to add to the then block of the new instance.</param>
        /// <returns>a new instance of <see cref="ConditionalStatement" />.</returns>
        public static ConditionalStatement Else(this ConditionalStatement statement, IEnumerable<Statement> statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new ConditionalStatement(statement.Parent, statement.Condition, statement.ThenStatement, JS.BlockOrStatement(statements));
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConditionalStatement" /> that forms an else-if condition after the specified condition. 
        /// </summary>
        /// <param name="statement">The conditional to which to add an else-if condition to.</param>
        /// <param name="condition">The condition to test.</param>
        /// <returns>a new instance of <see cref="ConditionalStatement" />.</returns>
        /// <remarks>
        /// This produces a new instance, and has no side effects on the existing statement (as all of the helpers are designed to) but
        /// it does refer to the existing instance. Therefore, there may be undesired effects when the original is somehow modified.
        /// However, in the typical use case (a fluent description of the conditional statement) there is no such problem.
        /// </remarks>
        public static ConditionalStatement ElseIf(this ConditionalStatement statement, Expression condition)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            ConditionalStatement parent = new ConditionalStatement(statement.Parent, statement.Condition, statement.ThenStatement, null);
            ConditionalStatement result = new ConditionalStatement(parent, condition, null, null);
            parent.ElseStatement = result;

            return result;
        }
    }
}
