using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a throw statement.
    /// </summary>
    public class ThrowStatement : Statement
    {
        private Expression _Expression;

        /// <summary>
        /// Initializes a new instance of <see cref="ThrowStatement" />.
        /// </summary>
        /// <param name="expression">The expression whose value is thrown.</param>
        public ThrowStatement(Expression expression)
        {
            this.Expression = expression;
        }

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            if (this._Expression == null)
            {
                throw new InvalidOperationException("Expression cannot be null.");
            }

            builder.Append("throw ");
            this._Expression.AppendScript(builder, options);
        }

        /// <summary>
        /// Gets or sets the expression whose value is thrown.
        /// </summary>
        public Expression Expression
        {
            get
            {
                return this._Expression;
            }
            set
            {
                this._Expression = value;
            }
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
