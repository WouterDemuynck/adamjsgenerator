using System;
using System.Collections.Generic;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="ExceptionHandlingStatement" />.
    /// </summary>
    public static class ExceptionHandlingStatementHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="ExceptionHandlingStatement" /> by copying the <see cref="ExceptionHandlingStatement.TryBlock" /> 
        /// and <see cref="ExceptionHandlingStatement.FinallyBlock" /> from the specified statement, and adding the specified expression and statements to the <see cref="ExceptionHandlingStatement.CatchBlock" />.
        /// </summary>
        /// <param name="statement">The statement from which to copy the <see cref="ExceptionHandlingStatement.TryBlock" /> and <see cref="ExceptionHandlingStatement.FinallyBlock" /> properties.</param>
        /// <param name="expression">The expression to set in the Catch block.</param>
        /// <param name="statements"> An array of statements to add to the Catch block.</param>
        /// <returns>a new instance of <see cref="ExceptionHandlingStatement" />.</returns>
        public static ExceptionHandlingStatement Catch(this ExceptionHandlingStatement statement, IdentifierExpression expression, params Statement[] statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return Catch(statement, expression, new CompoundStatement(statements));
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExceptionHandlingStatement" /> by copying the <see cref="ExceptionHandlingStatement.TryBlock" /> 
        /// and <see cref="ExceptionHandlingStatement.FinallyBlock" /> from the specified statement, and adding the specified expression and statements to the <see cref="ExceptionHandlingStatement.CatchBlock" />.
        /// </summary>
        /// <param name="statement">The statement from which to copy the <see cref="ExceptionHandlingStatement.TryBlock" /> and <see cref="ExceptionHandlingStatement.FinallyBlock" /> properties.</param>
        /// <param name="expression">The expression to set in the Catch block.</param>
        /// <param name="statements">A sequence of statements to add to the Catch block.</param>
        /// <returns>a new instance of <see cref="ExceptionHandlingStatement" />.</returns>
        public static ExceptionHandlingStatement Catch(this ExceptionHandlingStatement statement, IdentifierExpression expression, IEnumerable<Statement> statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return Catch(statement, expression, new CompoundStatement(statements));
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExceptionHandlingStatement" /> by copying the <see cref="ExceptionHandlingStatement.TryBlock" /> 
        /// and <see cref="ExceptionHandlingStatement.FinallyBlock" /> from the specified statement, and adding the specified expression and statements to the <see cref="ExceptionHandlingStatement.CatchBlock" />.
        /// </summary>
        /// <param name="statement">The statement from which to copy the <see cref="ExceptionHandlingStatement.TryBlock" /> and <see cref="ExceptionHandlingStatement.FinallyBlock" /> properties.</param>
        /// <param name="expression">The expression to set in the Catch block.</param>
        /// <param name="block">The block to use as the Catch block.</param>
        /// <returns>a new instance of <see cref="ExceptionHandlingStatement" />.</returns>
        public static ExceptionHandlingStatement Catch(this ExceptionHandlingStatement statement, IdentifierExpression expression, CompoundStatement block)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new ExceptionHandlingStatement(statement.TryBlock, expression, block, statement.FinallyBlock);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExceptionHandlingStatement" /> by copying the <see cref="ExceptionHandlingStatement.TryBlock" />, <see cref="ExceptionHandlingStatement.CatchVariable" /> 
        /// and <see cref="ExceptionHandlingStatement.CatchBlock" /> from the specified statement, and adding the specified statements to the <see cref="ExceptionHandlingStatement.FinallyBlock" />.
        /// </summary>
        /// <param name="statement">The statement from which to copy the <see cref="ExceptionHandlingStatement.TryBlock" /> and <see cref="ExceptionHandlingStatement.CatchBlock" /> properties.</param>
        /// <param name="statements">An array of statements to add to the Catch block.</param>
        /// <returns>a new instance of <see cref="ExceptionHandlingStatement" />.</returns>
        public static ExceptionHandlingStatement Finally(this ExceptionHandlingStatement statement, params Statement[] statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return Finally(statement, new CompoundStatement(statements));
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExceptionHandlingStatement" /> by copying the <see cref="ExceptionHandlingStatement.TryBlock" />, <see cref="ExceptionHandlingStatement.CatchVariable" /> 
        /// and <see cref="ExceptionHandlingStatement.CatchBlock" /> from the specified statement, and adding the specified statements to the <see cref="ExceptionHandlingStatement.FinallyBlock" />.
        /// </summary>
        /// <param name="statement">The statement from which to copy the <see cref="ExceptionHandlingStatement.TryBlock" /> and <see cref="ExceptionHandlingStatement.CatchBlock" /> properties.</param>
        /// <param name="statements">A sequence of statements to add to the Catch block.</param>
        /// <returns>a new instance of <see cref="ExceptionHandlingStatement" />.</returns>
        public static ExceptionHandlingStatement Finally(this ExceptionHandlingStatement statement, IEnumerable<Statement> statements)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return Finally(statement, new CompoundStatement(statements));
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExceptionHandlingStatement" /> by copying the <see cref="ExceptionHandlingStatement.TryBlock" />, <see cref="ExceptionHandlingStatement.CatchVariable" /> 
        /// and <see cref="ExceptionHandlingStatement.CatchBlock" /> from the specified statement, and adding the specified statements to the <see cref="ExceptionHandlingStatement.FinallyBlock" />.
        /// </summary>
        /// <param name="statement">The statement from which to copy the <see cref="ExceptionHandlingStatement.TryBlock" /> and <see cref="ExceptionHandlingStatement.CatchBlock" /> properties.</param>
        /// <param name="block">The block to use as the Catch block.</param>
        /// <returns>a new instance of <see cref="ExceptionHandlingStatement" />.</returns>
        public static ExceptionHandlingStatement Finally(this ExceptionHandlingStatement statement, CompoundStatement block)
        {
            if (statement == null)
            {
                throw new ArgumentNullException("statement");
            }

            return new ExceptionHandlingStatement(statement.TryBlock, statement.CatchVariable, statement.CatchBlock, block);
        }
    }
}
