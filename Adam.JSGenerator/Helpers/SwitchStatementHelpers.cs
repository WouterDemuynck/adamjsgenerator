using System;
using System.Collections.Generic;
using System.Linq;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create instances of <see cref="SwitchStatement" />.
    /// </summary>
    public static class SwitchStatementHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="SwitchStatement" />, copying all the cases of the specified statement, and adding a default case.
        /// </summary>
        /// <param name="statement">The statement to copy the cases from.</param>
        /// <returns>a new instance of <see cref="SwitchStatement" />.</returns>
        public static SwitchStatement Default(this SwitchStatement statement)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return Case(statement, new Expression[] { null });
        }

        /// <summary>
        /// Creates a new instance of <see cref="SwitchStatement" />, copying all the cases of the specified statement, and adding cases for all the literals in the specified array.
        /// </summary>
        /// <param name="statement">The statement to copy the cases from.</param>
        /// <param name="values">an array of literals for which to add cases.</param>
        /// <returns>a new instance of <see cref="SwitchStatement" /></returns>
        public static SwitchStatement Case(this SwitchStatement statement, params Expression[] values)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return Case(statement, values.AsEnumerable());
        }

        /// <summary>
        /// Creates a new instance of <see cref="SwitchStatement" />, copying all the cases of the specified statement, and adding cases for all the literals in the specified sequence.
        /// </summary>
        /// <param name="statement">the statement to copy the cases from.</param>
        /// <param name="values">a sequence of literals for which to add cases.</param>
        /// <returns>a new instance of <see cref="SwitchStatement" />.</returns>
        public static SwitchStatement Case(this SwitchStatement statement, IEnumerable<Expression> values)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            if (values != null)
            {
                SwitchStatement @switch = new SwitchStatement(statement.Expression, statement.Cases);

                @switch.Cases.AddRange(values.Select(value => new CaseStatement(value)));

                return @switch;
            }

            return statement;
        }

        /// <summary>
        /// Creates a new instance of <see cref="SwitchStatement" />, copying all the cases of the specified statement, replacing the last case with one that adds a break statement.
        /// </summary>
        /// <param name="statement">The switch statement to copy all cases from.</param>
        /// <returns>a new instance of <see cref="SwitchStatement" /></returns>
        /// <remarks>
        /// The specified instance of <see cref="SwitchStatement" /> must already have at least one case for this method to succeed.
        /// </remarks>
        public static SwitchStatement Break(this SwitchStatement statement)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return Do(statement, JS.Break());
        }

        /// <summary>
        /// Creates a new instance of <see cref="SwitchStatement" />, copying all the cases of the specified statement, replacing the last case with one that adds the specified statements.
        /// </summary>
        /// <param name="statement">The switch statement to copy all cases from.</param>
        /// <param name="statements">An array of statements to append to the last case.</param>
        /// <returns>a new instance of <see cref="SwitchStatement" /></returns>
        /// <remarks>
        /// The specified instance of <see cref="SwitchStatement" /> must already have at least one case for this method to succeed.
        /// </remarks>
        public static SwitchStatement Do(this SwitchStatement statement, params Statement[] statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return Do(statement, statements.AsEnumerable());
        }

        /// <summary>
        /// Creates a new instance of <see cref="SwitchStatement" />, copying all the cases of the specified statement, replacing the last case with one that adds the specified statements.
        /// </summary>
        /// <param name="statement">The switch statement to copy all cases from.</param>
        /// <param name="statements">A sequence of statements to append to the last case.</param>
        /// <returns>a new instance of <see cref="SwitchStatement" /></returns>
        /// <remarks>
        /// The specified instance of <see cref="SwitchStatement" /> must already have at least one case for this method to succeed.
        /// </remarks>
        public static SwitchStatement Do(this SwitchStatement statement, IEnumerable<Statement> statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            SwitchStatement @switch = new SwitchStatement(statement.Expression, statement.Cases);

            if (statements != null)
            {
                int lastIndex = @switch.Cases.Count - 1;
                CaseStatement lastCase = @switch.Cases[lastIndex];
                CaseStatement newLast = new CaseStatement(lastCase.Value, lastCase.Statements);
                newLast.Statements.AddRange(statements);
                @switch.Cases[lastIndex] = newLast;
            }

            return @switch;
        }
    }
}
