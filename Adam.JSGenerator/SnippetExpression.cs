using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents an expression whose value is inserted as is.
    /// </summary>
    public class SnippetExpression : Expression
    {
        private string _Value;

        /// <summary>
        /// Initializes a new instance of <see cref="SnippetExpression" /> for the specified Value.
        /// </summary>
        /// <param name="value">The string value that this instance must represent.</param>
        public SnippetExpression(string value)
        {
            this._Value = value;
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        protected internal override void AppendScript(StringBuilder builder, ScriptOptions options)
        {
            builder.Append(this._Value);
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
