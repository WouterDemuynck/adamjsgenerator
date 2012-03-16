using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Contains an unary operation.
    /// </summary>
    public class UnaryOperationExpression : Expression
    {
        private Expression _operand;
        private UnaryOperator _operator;

        /// <summary>
        /// Creates a new instance of the UnaryOperation class.
        /// </summary>
        /// <param name="operand">The operand.</param>
        /// <param name="op">The operator.</param>
        public UnaryOperationExpression(Expression operand, UnaryOperator op)
        {
            _operand = operand;
            _operator = op;
        }

        /// <summary>
        /// Gets or sets the operand for this unary operation.
        /// </summary>
        public Expression Operand
        {
            get
            {
                return _operand;
            }
            set
            {
                _operand = value;
            }
        }

        /// <summary>
        /// Gets or sets the operator for this unary operation.
        /// </summary>
        public UnaryOperator Operator
        {
            get
            {
                return _operator;
            }
            set
            {
                _operator = value;
            }
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

            bool noLeftSide = false;
            bool noRightSide = false;

            switch (_operator)
            {
                case UnaryOperator.Number:
                    builder.Append("+");
                    break;

                case UnaryOperator.Negative:
                    builder.Append("-");
                    break;

                case UnaryOperator.BitwiseNot:
                    builder.Append("~");
                    break;

                case UnaryOperator.LogicalNot:
                    builder.Append("!");
                    break;

                case UnaryOperator.PreIncrement:
                    builder.Append("++");
                    break;

                case UnaryOperator.PreDecrement:
                    builder.Append("--");
                    break;

                case UnaryOperator.TypeOf:
                    builder.Append("typeof ");
                    break;

                case UnaryOperator.New:
                    builder.Append("new ");
                    break;

                case UnaryOperator.Delete:
                    builder.Append("delete ");
                    break;

                case UnaryOperator.Group:
                    builder.Append("(");
                    break;

                default:
                    noLeftSide = true;
                    break;
                    
            }

            Expression operand = _operand ?? new NullExpression();
            operand.AppendScript(builder, options, allowReservedWords);

            switch (_operator)
            {
                case UnaryOperator.PostIncrement:
                    builder.Append("++");
                    break;
                
                case UnaryOperator.PostDecrement:
                    builder.Append("--");
                    break;
                
                case UnaryOperator.Group:
                    builder.Append(")");
                    break;

                default:
                    noRightSide = true;
                    break;
            }

            if (noLeftSide && noRightSide)
            {
                throw new InvalidOperationException("This operator yielded no result.");
            }
        }

        /// <summary>
        /// Gets a value indicating the precedence level of this expression.
        /// </summary>
        public override Precedence PrecedenceLevel
        {
            get
            {
                int level = 14;

                switch (_operator)
                {
                    case UnaryOperator.Group:
                        level = 16;
                        break;

                    case UnaryOperator.New:
                        level = 15;
                        break;
                }

                return new Precedence { Level = level, Association = Association.RightToLeft };
            }
        }

    }
}
