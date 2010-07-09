using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents a "null" value in JavaScript.
    /// </summary>
    public class NullExpression : Expression
    {
        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            builder.Append("null");
        }

    }
}
