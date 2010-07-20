using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents a string value, inserted as a literal.
    /// </summary>
    public class StringExpression : Expression
    {
        private string _Value;

        /// <summary>
        /// Initializes a new instance of <see cref="StringExpression" /> with an empty value.
        /// </summary>
        public StringExpression()
        {
            this._Value = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="StringExpression" /> for the specified Value.
        /// </summary>
        /// <param name="value">The string value that this instance must represent.</param>
        public StringExpression(string value)
        {
            this._Value = value;
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        protected internal override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            builder.Append(JS.QuoteString(this._Value, options.PreferredQuoteChar));
        }

        /// <summary>
        /// Gets or sets the Value to append.
        /// </summary>
        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }
    }
}
