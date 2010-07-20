using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines an index operation.
    /// </summary>
    public class IndexOperationExpression : Expression
    {
        private Expression _OperandLeft;
        private Expression _OperandRight;

        /// <summary>
        /// Initializes a new instance of <see cref="IndexOperationExpression" />.
        /// </summary>
        /// <param name="operandLeft">The operand on which to perform the index operation.</param>
        /// <param name="operandRight">The operand that specifies the index to retrieve.</param>
        public IndexOperationExpression(Expression operandLeft, Expression operandRight)
        {
            this._OperandLeft = operandLeft;
            this._OperandRight = operandRight;
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            if (this.OperandLeft == null)
            {
                throw new InvalidOperationException("OperandLeft cannot be null.");
            }

            if (this.OperandRight == null)
            {
                throw new InvalidOperationException("OperandRight cannot be null.");
            }

            _OperandLeft.AppendScript(builder, options);
            builder.Append("[");
            _OperandRight.AppendScript(builder, options);
            builder.Append("]");
        }

        /// <summary>
        /// Gets or sets the operand on which to perform the index operation.
        /// </summary>
        public Expression OperandLeft
        {
            get
            {
                return _OperandLeft;
            }
            set
            {
                _OperandLeft = value;
            }
        }

        /// <summary>
        /// Gets or sets the operand that specifies the index to retrieve.
        /// </summary>
        public Expression OperandRight
        {
            get
            {
                return _OperandRight;
            }
            set
            {
                _OperandRight = value;
            }
        }

        /// <summary>
        /// Indicates the level of precedence valid for this expresison.
        /// </summary>
        /// <remarks>
        /// This is used when combining expressions, to determine where parens are needed.
        /// </remarks>
        public override Precedence PrecedenceLevel
        {
            get
            {
                return new Precedence {Association = Association.LeftToRight, Level = 15};
            }
        }
    }
}
