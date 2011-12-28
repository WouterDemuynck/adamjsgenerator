using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a break statement.
    /// </summary>
    public class BreakStatement : Statement
    {
        private IdentifierExpression _label;

        /// <summary>
        /// Initializes a new instance of the <see cref="BreakStatement" /> class.
        /// </summary>
        public BreakStatement()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BreakStatement" /> class for the specified label.
        /// </summary>
        /// <param name="label">A label that the break statement must refer to.</param>
        public BreakStatement(IdentifierExpression label)
        {
            Label = label;
        }

        /// <summary>
        /// Gets or sets the label that the break statement must refer to.
        /// </summary>
        /// <remarks>
        /// To indicate that no label must be referred to, set this member to null.
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

            builder.Append("break");

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
