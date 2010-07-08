﻿using System;
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
        private List<Statement> _Statements = new List<Statement>();

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
                this._Statements.AddRange(statements);
            }
        }

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            if (this._Statements == null)
            {
                throw new InvalidOperationException("Statements cannot be null.");
            }

            builder.Append("{");

            foreach (Statement statement in this._Statements.WithConvertedNulls())
            {
                statement.AppendScript(builder, options);
                statement.AppendRequiredTerminator(builder);
            }

            builder.Append("}");
        }

        /// <summary>
        /// Gets or sets the list of statements contained in this instance.
        /// </summary>
        public List<Statement> Statements
        {
            get
            {
                return this._Statements;
            }
            set
            {
                this._Statements = value;
            }
        }
    }
}
