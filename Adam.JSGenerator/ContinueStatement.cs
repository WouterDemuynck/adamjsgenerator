using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a continue statement.
    /// </summary>
    public class ContinueStatement : Statement
    {
        private IdentifierExpression _label;

        /// <summary>
        /// Initializes a new instanec of <see cref="ContinueStatement" />.
        /// </summary>
        public ContinueStatement()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ContinueStatement" /> that jumps to the specified label.
        /// </summary>
        /// <param name="label">The name of the label to jump to.</param>
        public ContinueStatement(IdentifierExpression label)
        {
            Label = label;
        }

        /// <summary>
        /// Gets or sets the label to jump to. 
        /// </summary>
        /// <remarks>
        /// If the continue statement should not specify a label, set this property to null.
        /// </remarks>
        public IdentifierExpression Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
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

            builder.Append("continue");

            if (_label != null)
            {
                builder.Append(" ");
                _label.AppendScript(builder, options);
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
