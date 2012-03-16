using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines the while statement.
    /// </summary>
    public class WhileStatement : Statement
    {
        private Expression _condition;
        private Statement _statement;

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
            _condition = condition;
            _statement = statement;
        }

    	/// <summary>
    	/// Appends the script to represent this object to the StringBuilder.
    	/// </summary>
    	/// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
    	/// <param name="options">The options to use when appending JavaScript</param>
    	/// <param name="allowReservedWords"></param>
    	internal protected override void AppendScript(StringBuilder builder, ScriptOptions options, bool allowReservedWords)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            if (_condition == null)
            {
                throw new InvalidOperationException();
            }

            if (_statement == null)
            {
                throw new InvalidOperationException();
            }

            builder.Append("while(");
            _condition.AppendScript(builder, options, allowReservedWords);
            builder.Append(")");
            _statement.AppendScript(builder, options, allowReservedWords);
            _statement.AppendRequiredTerminator(builder);
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

    }
}
