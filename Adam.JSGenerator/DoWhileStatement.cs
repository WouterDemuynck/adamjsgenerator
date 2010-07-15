using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a do-while loop.
    /// </summary>
    public class DoWhileStatement : Statement
    {
        private Expression _Condition;
        private Statement _Statement;

        /// <summary>
        /// Initializes a new instance of <see cref="DoWhileStatement" />.
        /// </summary>
        public DoWhileStatement()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DoWhileStatement" /> for the specified condition and statement.
        /// </summary>
        /// <param name="condition">The condition to check after the loop.</param>
        /// <param name="statement">The statement to run in the loop.</param>
        public DoWhileStatement(Expression condition, Statement statement)
        {
            this.Condition = condition;
            this.Statement = statement;
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

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            if (this._Condition == null)
            {
                throw new InvalidOperationException("Condition cannot be null.");
            }

            if (this._Statement == null)
            {
                throw new InvalidOperationException("Statement cannot be null.");
            }

            builder.Append("do ");
            this._Statement.AppendScript(builder, options);
            this._Statement.AppendRequiredTerminator(builder);
            builder.Append("while(");
            this._Condition.AppendScript(builder, options);
            builder.Append(")");
        }

        /// <summary>
        /// Indicates that this object requires a terminating semicolon when used as a statement.
        /// </summary>
        internal protected override bool RequiresTerminator
        {
            get
            {
                return true;
            }
        }

    }
}
