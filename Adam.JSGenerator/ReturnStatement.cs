using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a return statement.
    /// </summary>
    public class ReturnStatement : Statement
    {
        private Expression _Value;

        /// <summary>
        /// Initializes a new instance of <see cref="ReturnStatement" />
        /// </summary>
        public ReturnStatement()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ReturnStatement" /> that returns the specified value.
        /// </summary>
        /// <param name="value">The value to return.</param>
        public ReturnStatement(Expression value)
        {
            this._Value = value;
        }

        /// <summary>
        /// Gets or sets the value to return.
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
        /// Indicates that this object requires a terminating semicolon when used as a statement.
        /// </summary>
        internal protected override bool RequiresTerminator
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            builder.Append("return");

            if (this._Value != null)
            {
                builder.Append(" ");
                this._Value.AppendScript(builder, options);
            }
        }

    }
}
