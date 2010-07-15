using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents a boolean value, inserted as a literal.
    /// </summary>
    public class BooleanExpression : Expression
    {
        private const string FalseValue = "false";
        private const string TrueValue = "true";

        private bool _Value;

        /// <summary>
        /// Initializes a new instance of <see cref="BooleanExpression" /> for the specified value.
        /// </summary>
        /// <param name="value"></param>
        public BooleanExpression(bool value)
        {
            this._Value = value;
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        protected internal override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            builder.Append(this._Value ?  TrueValue : FalseValue);
        }

        /// <summary>
        /// Gets or sets the value to be appended as a literal.
        /// </summary>
        public bool Value
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
