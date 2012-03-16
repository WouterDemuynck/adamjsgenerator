using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines an index operation.
    /// </summary>
    public class IndexOperationExpression : Expression
    {
        private Expression _operandLeft;
        private Expression _operandRight;

        /// <summary>
        /// Initializes a new instance of <see cref="IndexOperationExpression" />.
        /// </summary>
        /// <param name="operandLeft">The operand on which to perform the index operation.</param>
        /// <param name="operandRight">The operand that specifies the index to retrieve.</param>
        public IndexOperationExpression(Expression operandLeft, Expression operandRight)
        {
            _operandLeft = operandLeft;
            _operandRight = operandRight;
        }

    	/// <summary>
    	/// Appends the script to represent this object to the StringBuilder.
    	/// </summary>
    	/// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
    	/// <param name="options">The options to use when appending JavaScript</param>
    	/// <param name="allowReservedWords"></param>
    	internal protected override void AppendScript(StringBuilder builder, ScriptOptions options, bool allowReservedWords)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            if (OperandLeft == null)
            {
                throw new InvalidOperationException();
            }

            if (OperandRight == null)
            {
                throw new InvalidOperationException();
            }

            _operandLeft.AppendScript(builder, options, allowReservedWords);
            builder.Append("[");
            _operandRight.AppendScript(builder, options, allowReservedWords);
            builder.Append("]");
        }

        /// <summary>
        /// Gets or sets the operand on which to perform the index operation.
        /// </summary>
        public Expression OperandLeft
        {
            get
            {
                return _operandLeft;
            }
            set
            {
                _operandLeft = value;
            }
        }

        /// <summary>
        /// Gets or sets the operand that specifies the index to retrieve.
        /// </summary>
        public Expression OperandRight
        {
            get
            {
                return _operandRight;
            }
            set
            {
                _operandRight = value;
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
