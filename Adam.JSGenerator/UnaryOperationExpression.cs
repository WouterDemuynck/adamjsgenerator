using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Contains an unary operation.
    /// </summary>
    public class UnaryOperationExpression : Expression
    {
        private Expression _Operand;
        private UnaryOperator _Operator;

        /// <summary>
        /// Creates a new instance of the UnaryOperation class.
        /// </summary>
        /// <param name="operand">The operand.</param>
        /// <param name="op">The operator.</param>
        public UnaryOperationExpression(Expression operand, UnaryOperator op)
        {
            this._Operand = operand;
            this._Operator = op;
        }

        /// <summary>
        /// Gets or sets the operand for this unary operation.
        /// </summary>
        public Expression Operand
        {
            get
            {
                return _Operand;
            }
            set
            {
                _Operand = value;
            }
        }

        /// <summary>
        /// Gets or sets the operator for this unary operation.
        /// </summary>
        public UnaryOperator Operator
        {
            get
            {
                return _Operator;
            }
            set
            {
                _Operator = value;
            }
        }

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            bool noLeftSide = false;
            bool noRightSide = false;

            switch (this._Operator)
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

            Expression operand = this._Operand ?? new NullExpression();
            operand.AppendScript(builder, options);

            switch (_Operator)
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

        public override Precedence PrecedenceLevel
        {
            get
            {
                int level = 14;

                switch (this._Operator)
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
