using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents a "null" value in JavaScript.
    /// </summary>
    public class NullExpression : Expression
    {
        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, ScriptOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            builder.Append("null");
        }
    }
}
