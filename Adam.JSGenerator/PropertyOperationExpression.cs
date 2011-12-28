using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a property operation. (aka the dot '.' operator)
    /// </summary>
    public class PropertyOperationExpression : Expression
    {
        private Expression _operandLeft;
        private IdentifierExpression _operandRight;

        /// <summary>
        /// Initializes a new instance of <see cref="PropertyOperationExpression" /> for the specified left and right operands.
        /// </summary>
        /// <param name="operandLeft">The left operand of the operation.</param>
        /// <param name="operandRight">The right operand of the operation.</param>
        public PropertyOperationExpression(Expression operandLeft, IdentifierExpression operandRight)
        {
            _operandLeft = operandLeft;
            _operandRight = operandRight;
        }

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

            if (_operandLeft == null)
            {
                throw new InvalidOperationException();
            }

            if (_operandRight == null)
            {
                throw new InvalidOperationException();
            }

            Expression operandLeft = _operandLeft;
            Expression operandRight = _operandRight;

            if (operandLeft.PrecedenceLevel.RequiresGrouping(PrecedenceLevel, Association.LeftToRight))
            {
                operandLeft = JS.Group(operandLeft);
            }

            operandLeft.AppendScript(builder, options);

            builder.Append(".");

            operandRight.AppendScript(builder, options);
        }

        /// <summary>
        /// Gets or sets the left operand of the operation.
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
        /// Gets or sets the right operand of the operation.
        /// </summary>
        public IdentifierExpression OperandRight
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
                return new Precedence { Association = Association.LeftToRight, Level = 15 };
            }
        }
    }
}
