using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a statement block.
    /// </summary>
    public class CompoundStatement : Statement
    {
        private readonly List<Statement> _statements = new List<Statement>();

        /// <summary>
        /// Creates a new empty instance of <see cref="CompoundStatement" />.
        /// </summary>
        public CompoundStatement()
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="CompoundStatement" /> containing the specified statements.
        /// </summary>
        /// <param name="statements">An array of statements to add to the CompoundStatement object.</param>
        public CompoundStatement(params Statement[] statements)
            : this(statements.AsEnumerable())
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="CompoundStatement" /> containing the passed statements.
        /// </summary>
        /// <param name="statements">The statements to add to the CompoundStatement object.</param>
        public CompoundStatement(IEnumerable<Statement> statements)
        {
            if (statements != null)
            {
                _statements.AddRange(statements);
            }
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, ScriptOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            builder.Append("{");

            foreach (Statement statement in _statements.WithConvertedNulls())
            {
                statement.AppendScript(builder, options);
                statement.AppendRequiredTerminator(builder);
            }

            builder.Append("}");
        }

        /// <summary>
        /// Gets or sets the list of statements contained in this instance.
        /// </summary>
        public IList<Statement> Statements
        {
            get
            {
                return _statements;
            }
        }
    }
}
