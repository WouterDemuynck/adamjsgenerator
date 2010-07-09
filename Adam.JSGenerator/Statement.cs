using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides the base class for all Javascript statements.
    /// </summary>
    public abstract class Statement
    {
        private const string Terminator = ";";

        /// <summary>
        /// Helper method that appends a terminating semicolon to the StringBuilder, if this object requires one.
        /// </summary>
        /// <param name="builder">The StringBuilder to apply a terminating semicolon to.</param>
        public void AppendRequiredTerminator(StringBuilder builder)
        {
            if (RequiresTerminator)
            {
                builder.Append(Terminator);
            }
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected abstract void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options);

        /// <summary>
        /// Indicates that this object requires a terminating semicolon when used as a statement.
        /// </summary>
        internal protected virtual bool RequiresTerminator
        {
            get
            {
                // A statement usually does not need to be terminated.
                return false;
            }
        }

        /// <summary>
        /// Converts the object to a string containing the JavaScript that it represents.
        /// </summary>
        /// <param name="includeTerminator">If true, a statement terminator is appended if required.</param>
        /// <param name="options">The options to use when generating JavaScript.</param>
        /// <returns>A string containing the JavaScript that it represents.</returns>
        public string ToString(bool includeTerminator, GenerateJavaScriptOptions options)
        {
            StringBuilder builder = new StringBuilder();

            AppendScript(builder, options);
            
            if (includeTerminator)
            {
                AppendRequiredTerminator(builder);
            }
            
            return builder.ToString();
        }

        /// <summary>
        /// Converts the object to a string containing the JavaScript that it represents.
        /// </summary>
        /// <param name="includeTerminator">If true, a statement terminator is appended if required.</param>
        /// <returns>A string containing the JavaScript that it represents.</returns>
        public string ToString(bool includeTerminator)
        {
            return this.ToString(includeTerminator, new GenerateJavaScriptOptions());
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return this.ToString(true);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            
            return obj.GetType().Equals(this.GetType()) && 
                string.Equals(this.ToString(), obj.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
