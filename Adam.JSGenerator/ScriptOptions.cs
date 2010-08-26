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
    public class ScriptOptions
    {
        private char _PreferredQuoteChar = '"';
        private bool _AlwaysQuoteObjectLiteralKeys;

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

        /// <summary>
        /// Gets or sets a value indicating whether the keys of object literals are always quoted, even if they're valid JavaScript identifiers.
        /// </summary>
        /// <remarks>
        /// Set this value to true when generating script that serves as JSON.
        /// </remarks>
        public bool AlwaysQuoteObjectLiteralKeys
        {
            get { return _AlwaysQuoteObjectLiteralKeys; }
            set { _AlwaysQuoteObjectLiteralKeys = value; }
        }

        /// <summary>
        /// Returns an instance of <see cref="ScriptOptions" /> with the default options set.
        /// </summary>
        public static ScriptOptions Default
        {
            get { return new ScriptOptions(); }
        }

        /// <summary>
        /// Returns an instance of <see cref="ScriptOptions" /> suitable for return JSON script.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Json")]
        public static ScriptOptions Json
        {
            get
            {
                return new ScriptOptions
                {
                    AlwaysQuoteObjectLiteralKeys = true,
                    PreferredQuoteChar = '"'
                };
            }
        }
    }
}
