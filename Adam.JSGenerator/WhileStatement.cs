using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines the while statement.
    /// </summary>
    public class WhileStatement : Statement
    {
        private Expression _Condition;
        private Statement _Statement;

        /// <summary>
        /// Initializes a new instance of <see cref="WhileStatement" />.
        /// </summary>
        public WhileStatement()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="WhileStatement" /> for the specified condition and statement.
        /// </summary>
        /// <param name="condition">The condition to check in the loop.</param>
        /// <param name="statement">The statement to run in the loop.</param>
        public WhileStatement(Expression condition, Statement statement)
        {
            this._Condition = condition;
            this._Statement = statement;
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

            if (this._Condition == null)
            {
                throw new InvalidOperationException();
            }

            if (this._Statement == null)
            {
                throw new InvalidOperationException();
            }

            builder.Append("while(");
            this._Condition.AppendScript(builder, options);
            builder.Append(")");
            this._Statement.AppendScript(builder, options);
            this._Statement.AppendRequiredTerminator(builder);
        }

        /// <summary>
        /// Gets or sets the condition to check in the loop.
        /// </summary>
        public Expression Condition
        {
            get
            {
                return this._Condition;
            }
            set
            {
                this._Condition = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement to run in the loop.
        /// </summary>
        public Statement Statement
        {
            get
            {
                return this._Statement;
            }
            set
            {
                this._Statement = value;
            }
        }

    }
}
