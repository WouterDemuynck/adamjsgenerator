using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a do-while loop.
    /// </summary>
    public class DoWhileStatement : Statement
    {
        private Expression _condition;
        private Statement _statement;

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
            Condition = condition;
            Statement = statement;
        }

        /// <summary>
        /// Gets or sets the condition to check in the loop.
        /// </summary>
        public Expression Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement to run in the loop.
        /// </summary>
        public Statement Statement
        {
            get
            {
                return _statement;
            }
            set
            {
                _statement = value;
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

            if (_condition == null)
            {
                throw new InvalidOperationException("Condition cannot be null.");
            }

            if (_statement == null)
            {
                throw new InvalidOperationException("Statement cannot be null.");
            }

            builder.Append("do ");
            _statement.AppendScript(builder, options);
            _statement.AppendRequiredTerminator(builder);
            builder.Append("while(");
            _condition.AppendScript(builder, options);
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
