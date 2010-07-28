using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a break statement.
    /// </summary>
    public class BreakStatement : Statement
    {
        private IdentifierExpression _Label;

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
            this.Label = label;
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
                return this._Label;
            }
            set
            {
                this._Label = value;
            }
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, ScriptOptions options)
        {
            builder.Append("break");

            if (this._Label != null)
            {
                builder.Append(" ");
                this._Label.AppendScript(builder, options);
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
