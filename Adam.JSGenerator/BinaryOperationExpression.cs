using System;
using System.Collections.Generic;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Contains a binary operation.
    /// </summary>
    public class BinaryOperationExpression : Expression
    {
        // Source: JavaScript: The Definitive Guide.
        private static readonly Dictionary<BinaryOperator, Precedence> PrecedenceLevels = new Dictionary
            <BinaryOperator, Precedence>        
        {
            { BinaryOperator.Assign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.Add, new Precedence { Level = 12, Association = Association.LeftToRight } },
            { BinaryOperator.AddAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.Subtract, new Precedence { Level = 12, Association = Association.LeftToRight } },
            { BinaryOperator.SubtractAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.Multiply, new Precedence { Level = 13, Association = Association.LeftToRight } },
            { BinaryOperator.MultiplyAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.Divide, new Precedence { Level = 13, Association = Association.LeftToRight } },
            { BinaryOperator.DivideAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.Remain, new Precedence { Level = 13, Association = Association.LeftToRight } },
            { BinaryOperator.RemainAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.BitwiseAnd, new Precedence { Level = 8, Association = Association.LeftToRight } },
            { BinaryOperator.BitwiseAndAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.BitwiseOr, new Precedence { Level = 6, Association = Association.LeftToRight } },
            { BinaryOperator.BitwiseOrAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.BitwiseXor, new Precedence { Level = 7, Association = Association.LeftToRight } },
            { BinaryOperator.BitwiseXorAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.ShiftLeft, new Precedence { Level = 11, Association = Association.LeftToRight } },
            { BinaryOperator.ShiftLeftAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.ShiftRight, new Precedence { Level = 11, Association = Association.LeftToRight } },
            { BinaryOperator.ShiftRightAndAssign, new Precedence { Level = 2, Association = Association.RightToLeft } },
            { BinaryOperator.Equals, new Precedence { Level = 9, Association = Association.LeftToRight } },
            { BinaryOperator.Identical, new Precedence { Level = 9, Association = Association.LeftToRight } },
            { BinaryOperator.NotEqual, new Precedence { Level = 9, Association = Association.LeftToRight } },
            { BinaryOperator.NotIdentical, new Precedence { Level = 9, Association = Association.LeftToRight } },
            { BinaryOperator.GreaterThan, new Precedence { Level = 10, Association = Association.LeftToRight } },
            { BinaryOperator.GreaterThanOrEqualTo, new Precedence { Level = 10, Association = Association.LeftToRight } },
            { BinaryOperator.LessThan, new Precedence { Level = 10, Association = Association.LeftToRight } },
            { BinaryOperator.LessThanOrEqualTo, new Precedence { Level = 10, Association = Association.LeftToRight } },
            { BinaryOperator.LogicalAnd, new Precedence { Level = 5, Association = Association.LeftToRight } },
            { BinaryOperator.LogicalOr, new Precedence { Level = 4, Association = Association.LeftToRight } },
            { BinaryOperator.InstanceOf, new Precedence { Level = 10, Association = Association.LeftToRight } },
            { BinaryOperator.In, new Precedence { Level = 10, Association = Association.LeftToRight } },
            { BinaryOperator.MultipleEvaluation, new Precedence { Level = 1, Association = Association.LeftToRight } }
        };

        private Expression _operandLeft;
        private Expression _operandRight;
        private BinaryOperator _operator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperationExpression" />.
        /// </summary>
        public BinaryOperationExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperationExpression" /> with the specified operator and operands.
        /// </summary>
        /// <param name="operandLeft">The left side of the binary operation.</param>
        /// <param name="operandRight">The right side of the binary operation.</param>
        /// <param name="op">The binary operator</param>
        public BinaryOperationExpression(Expression operandLeft, Expression operandRight, BinaryOperator op)
        {
            _operandLeft = operandLeft;
            _operandRight = operandRight;
            _operator = op;
        }

    	/// <summary>
    	/// Appends the script to represent this object to the StringBuilder.
    	/// </summary>
    	/// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
    	/// <param name="options">The options to use when appending JavaScript</param>
    	/// <param name="allowReservedWords"></param>
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        internal protected override void AppendScript(StringBuilder builder, ScriptOptions options, bool allowReservedWords)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            Expression operandLeft = _operandLeft ?? new NullExpression();
            Expression operandRight = _operandRight ?? new NullExpression();

            if (operandLeft.PrecedenceLevel.RequiresGrouping(PrecedenceLevel, Association.LeftToRight))
            {
                operandLeft = JS.Group(operandLeft);
            }

            if (operandRight.PrecedenceLevel.RequiresGrouping(PrecedenceLevel, Association.RightToLeft))
            {
                operandRight = JS.Group(operandRight);
            }

            operandLeft.AppendScript(builder, options, allowReservedWords);

            switch (_operator)
            {
                case BinaryOperator.Assign:
                    builder.Append("=");
                    break;
                case BinaryOperator.Add:
                    builder.Append("+");
                    break;
                case BinaryOperator.AddAndAssign:
                    builder.Append("+=");
                    break;
                case BinaryOperator.Subtract:
                    builder.Append("-");
                    break;
                case BinaryOperator.SubtractAndAssign:
                    builder.Append("-=");
                    break;
                case BinaryOperator.Multiply:
                    builder.Append("*");
                    break;
                case BinaryOperator.MultiplyAndAssign:
                    builder.Append("*=");
                    break;
                case BinaryOperator.Divide:
                    builder.Append("/");
                    break;
                case BinaryOperator.DivideAndAssign:
                    builder.Append("/=");
                    break;
                case BinaryOperator.Remain:
                    builder.Append("%");
                    break;
                case BinaryOperator.RemainAndAssign:
                    builder.Append("%=");
                    break;
                case BinaryOperator.BitwiseAnd:
                    builder.Append("&");
                    break;
                case BinaryOperator.BitwiseAndAndAssign:
                    builder.Append("&=");
                    break;
                case BinaryOperator.BitwiseOr:
                    builder.Append("|");
                    break;
                case BinaryOperator.BitwiseOrAndAssign:
                    builder.Append("|=");
                    break;
                case BinaryOperator.BitwiseXor:
                    builder.Append("^");
                    break;
                case BinaryOperator.BitwiseXorAndAssign:
                    builder.Append("^=");
                    break;
                case BinaryOperator.ShiftLeft:
                    builder.Append("<<");
                    break;
                case BinaryOperator.ShiftLeftAndAssign:
                    builder.Append("<<=");
                    break;
                case BinaryOperator.ShiftRight:
                    builder.Append(">>");
                    break;
                case BinaryOperator.ShiftRightAndAssign:
                    builder.Append(">>=");
                    break;
                case BinaryOperator.Equals:
                    builder.Append("==");
                    break;
                case BinaryOperator.Identical:
                    builder.Append("===");
                    break;
                case BinaryOperator.NotEqual:
                    builder.Append("!=");
                    break;
                case BinaryOperator.NotIdentical:
                    builder.Append("!==");
                    break;
                case BinaryOperator.GreaterThan:
                    builder.Append(">");
                    break;
                case BinaryOperator.GreaterThanOrEqualTo:
                    builder.Append(">=");
                    break;
                case BinaryOperator.LessThan:
                    builder.Append("<");
                    break;
                case BinaryOperator.LessThanOrEqualTo:
                    builder.Append("<=");
                    break;
                case BinaryOperator.LogicalAnd:
                    builder.Append("&&");
                    break;
                case BinaryOperator.LogicalOr:
                    builder.Append("||");
                    break;
                case BinaryOperator.InstanceOf:
                    builder.Append(" instanceof ");
                    break;
                case BinaryOperator.In:
                    builder.Append(" in ");
                    break;
                case BinaryOperator.MultipleEvaluation:
                    builder.Append(",");
                    break;
                default:
                    throw new InvalidOperationException("What is this?");
            }

            operandRight.AppendScript(builder, options, allowReservedWords);
        }

        /// <summary>
        /// Gets or sets the operand on the left side of the binary operation.
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
        /// Gets or sets the operand on the right side of the binary operation.
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
        /// Gets or sets the operator to use in the binary operation.
        /// </summary>
        public BinaryOperator Operator
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
        /// Determines the precedence level of this binary operation.
        /// </summary>
        public override Precedence PrecedenceLevel
        {
            get
            {
                Precedence precedence;
                return PrecedenceLevels.TryGetValue(_operator, out precedence) ? precedence : Precedence.Quarantine;
            }
        }
    }
}
