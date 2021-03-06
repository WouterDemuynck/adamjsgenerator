﻿using System;
using System.Collections.Generic;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create instances of <see cref="IteratorStatement" />.
    /// </summary>
    public static class IteratorStatementHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="IteratorStatement" /> that iterates over the specified collection.
        /// </summary>
        /// <param name="statement">The statement to copy the properties from.</param>
        /// <param name="collection">The expression to use as the collection.</param>
        /// <returns>a new instance of <see cref="IteratorStatement" /></returns>
        /// <remarks>
        /// This helper method completes a <see cref="IteratorStatement" />.
        /// It's used as in the following example:
        /// <code>
        /// var iteratorstatement = JS.For(id).In(collection);
        /// </code>
        /// </remarks>
        public static IteratorStatement In(this IteratorStatement statement, Expression collection)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new IteratorStatement(statement.Variable, collection, statement.Statement);
        }

        /// <summary>
        /// Creates a new instance of <see cref="IteratorStatement" /> that copies the <see cref="IteratorStatement.Variable" /> 
        /// and <see cref="IteratorStatement.Collection" /> properties of the specified statement, and adds the statements to the body.
        /// </summary>
        /// <param name="statement">The statement to copy the properties from.</param>
        /// <param name="statements">An array of statements to add to the body.</param>
        /// <returns>a new instance of <see cref="IteratorStatement" /></returns>
        public static IteratorStatement Do(this IteratorStatement statement, params Statement[] statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new IteratorStatement(statement.Variable, statement.Collection, JS.BlockOrStatement(statements));
        }

        /// <summary>
        /// Creates a new instance of <see cref="IteratorStatement" /> that copies the <see cref="IteratorStatement.Variable" /> 
        /// and <see cref="IteratorStatement.Collection" /> properties of the specified statement, and adds the statements to the body.
        /// </summary>
        /// <param name="statement">The statement to copy the properties from.</param>
        /// <param name="statements">A sequence of statements to add to the body.</param>
        /// <returns>a new instance of <see cref="IteratorStatement" /></returns>
        public static IteratorStatement Do(this IteratorStatement statement, IEnumerable<Statement> statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new IteratorStatement(statement.Variable, statement.Collection, JS.BlockOrStatement(statements));
        }
    }
}
