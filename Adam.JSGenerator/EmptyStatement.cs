using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents the empty statement. Only a terminating semicolon is produced.
    /// </summary>
    public class EmptyStatement : Statement
    {
        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
        }

        internal protected override bool RequiresTerminator
        {
            get
            {
                return true;
            }
        }

    }
}
