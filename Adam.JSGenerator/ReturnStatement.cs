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
            this._Value = null;
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

        internal protected override bool RequiresTerminator
        {
            get
            {
                return true;
            }
        }

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
