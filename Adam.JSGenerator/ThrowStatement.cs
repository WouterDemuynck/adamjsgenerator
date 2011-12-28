using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a throw statement.
    /// </summary>
    public class ThrowStatement : Statement
    {
        private Expression _expression;

        /// <summary>
        /// Initializes a new instance of <see cref="ThrowStatement" />.
        /// </summary>
        /// <param name="expression">The expression whose value is thrown.</param>
        public ThrowStatement(Expression expression)
        {
            Expression = expression;
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

            if (_expression == null)
            {
                throw new InvalidOperationException();
            }

            builder.Append("throw ");
            _expression.AppendScript(builder, options);
        }

        /// <summary>
        /// Gets or sets the expression whose value is thrown.
        /// </summary>
        public Expression Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value;
            }
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
