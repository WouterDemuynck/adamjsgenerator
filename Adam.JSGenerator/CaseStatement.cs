using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a single case in a switch statement.
    /// </summary>
    public class CaseStatement
    {
        private Expression _Value;
        private readonly List<Statement> _Statements = new List<Statement>();

        /// <summary>
        /// Initializes a new instance of <see cref="CaseStatement" />.
        /// </summary>
        /// <param name="statements">An array of statemetns that run in this case.</param>
        /// <remarks>
        /// The case statement without a value is regarded as the 'default' statement and must come last in a <see cref="SwitchStatement" />.
        /// </remarks>
        public CaseStatement(params Statement[] statements)
        {
            if (statements != null)
            {
                this._Statements.AddRange(statements);
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CaseStatement" />.
        /// </summary>
        /// <param name="statements">An array of statemetns that run in this case.</param>
        /// <remarks>
        /// The case statement without a value is regarded as the 'default' statement and must come last in a <see cref="SwitchStatement" />.
        /// </remarks>
        public CaseStatement(IEnumerable<Statement> statements)
        {
            if (statements != null)
            {
                this._Statements.AddRange(statements);
            }
        }
        /// <summary>
        /// Initializes a new instance of <see cref="CaseStatement" />.
        /// </summary>
        /// <param name="value">The literal for which this case is used.</param>
        /// <param name="statements">An array of statements that run in this case.</param>
        public CaseStatement(Expression value, params Statement[] statements)
            : this(value, statements.AsEnumerable())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CaseStatement" />.
        /// </summary>
        /// <param name="value">The literal for which this case is used.</param>
        /// <param name="statements">A sequence of statements that run in this case.</param>
        public CaseStatement(Expression value, IEnumerable<Statement> statements)
        {
            this._Value = value;

            if (statements != null)
            {
                this._Statements.AddRange(statements);
            }
        }

        /// <summary>
        /// Produces the Javascript and appends it to the StringBuilder passed in the builder argument.
        /// </summary>
        /// <param name="builder">The StringBuilder instance to append the Javascript to.</param>
        /// <param name="options">Specifies options to use while producing Javascript.</param>
        public void AppendScript(StringBuilder builder, ScriptOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            if (this._Value != null)
            {
                builder.Append("case ");
                this._Value.AppendScript(builder, options);
                builder.Append(":");
            }
            else
            {
                builder.Append("default:");
            }

            if (this._Statements != null)
            {
                foreach (Statement statement in this._Statements.WithConvertedNulls())
                {
                    statement.AppendScript(builder, options);
                    statement.AppendRequiredTerminator(builder);
                }
            }
        }

        #region Properties

        /// <summary>
        /// Gets or sets the value that this used in this case.
        /// </summary>
        public Expression Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        /// <summary>
        /// Gets or sets a list of statements that is run in this case.
        /// </summary>
        public IList<Statement> Statements
        {
            get
            {
                return _Statements;
            }
        }

        #endregion
    }
}
