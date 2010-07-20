using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents the empty statement. Only a terminating semicolon is produced.
    /// </summary>
    public class EmptyStatement : Statement
    {
        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
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

    }
}
