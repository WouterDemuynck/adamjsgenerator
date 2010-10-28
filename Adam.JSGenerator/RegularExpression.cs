﻿using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents a regular expression, inserted as a literal.
    /// </summary>
    public class RegularExpression : Expression
    {
        private string _Value;

        /// <summary>
        /// Initializes a new instance of <see cref="RegularExpression" /> for the specified Value.
        /// </summary>
        /// <param name="value">The regular expression that this instance must represent.</param>
        public RegularExpression(string value)
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
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            if (this._Value == null)
            {
                throw new InvalidOperationException();
            }

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
