using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents a string value, inserted as a literal.
    /// </summary>
    public class StringExpression : Expression
    {
        private string _value;

        /// <summary>
        /// Initializes a new instance of <see cref="StringExpression" /> with an empty value.
        /// </summary>
        public StringExpression()
        {
            _value = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="StringExpression" /> for the specified Value.
        /// </summary>
        /// <param name="value">The string value that this instance must represent.</param>
        public StringExpression(string value)
        {
            _value = value;
        }

    	/// <summary>
    	/// Appends the script to represent this object to the StringBuilder.
    	/// </summary>
    	/// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
    	/// <param name="options">The options to use when appending JavaScript</param>
    	/// <param name="allowReservedWords"></param>
    	protected internal override void AppendScript(StringBuilder builder, ScriptOptions options, bool allowReservedWords)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            if (options == null)
            {
                throw new ArgumentNullException("options");
            }
            
            builder.Append(JS.QuoteString(_value, options.PreferredQuoteChar));
        }

        /// <summary>
        /// Gets or sets the Value to append.
        /// </summary>
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
}
