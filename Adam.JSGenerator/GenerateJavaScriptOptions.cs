using System;
using System.Linq;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Contains options that are applied to generating JavaScript.
    /// </summary>
    /// <remarks>
    /// A new instance of this class should have sensible defaults.
    /// </remarks>
    public class GenerateJavaScriptOptions
    {
        private char _PreferredQuoteChar = '"';

        /// <summary>
        /// Contains the preferred character to use when quoting strings. Allowed characters are single (') quote and double (") quote.
        /// </summary>
        public char PreferredQuoteChar
        {
            get
            {
                return this._PreferredQuoteChar;
            }
            set
            {
                if (!JS.QuoteChars.Contains(value))
                {
                    throw new ArgumentException(
                        "The preferred quote char can only be one of the allowed quote chars.",
                        "value");
                }
                this._PreferredQuoteChar = value;
            }
        }
    }
}
