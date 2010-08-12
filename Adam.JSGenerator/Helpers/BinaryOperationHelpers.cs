using System;
using System.Collections.Generic;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="BinaryOperationExpression" />.
    /// </summary>
    public static class BinaryOperationHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that assigns one expression to another.
        /// </summary>
        /// <param name="expression">The left side of the assignment.</param>
        /// <param name="operand">The right side of the assignment.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression AssignWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Assign);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that adds one expression to another.
        /// </summary>
        /// <param name="expression">The left side of the addition.</param>
        /// <param name="operand">The right side of the addition.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression AddWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Add);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that subtracts one expression from another.
        /// </summary>
        /// <param name="expression">The left side of the subtraction.</param>
        /// <param name="operand">The right side of the subtraction.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression SubtractWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Subtract);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that multiplies one expression by another.
        /// </summary>
        /// <param name="expression">The left side of the multiplication.</param>
        /// <param name="operand">The right side of the multiplication.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression MultiplyBy(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Multiply);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that divides one expression by another.
        /// </summary>
        /// <param name="expression">The left side of the division.</param>
        /// <param name="operand">The right side of the division.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression DivideBy(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Divide);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that computes the remainder of a division.
        /// </summary>
        /// <param name="expression">The left side of the remainder operation.</param>
        /// <param name="operand">The right side of the remainder operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression RemainderBy(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Remain);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a bitwise and operation.
        /// </summary>
        /// <param name="expression">The left side of the bitwise and operation.</param>
        /// <param name="operand">The right side of the bitwise and operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression BitwiseAndWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.BitwiseAnd);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a bitwise or operation.
        /// </summary>
        /// <param name="expression">The left side of the bitwise or operation.</param>
        /// <param name="operand">The right side of the bitwise or operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression BitwiseOrWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.BitwiseOr);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a bitwise exclusive or operation.
        /// </summary>
        /// <param name="expression">The left side of the bitwise exclusive or operation.</param>
        /// <param name="operand">The right side of the bitwise exclusive or operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression BitwiseXorWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.BitwiseXor);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a left shift operation.
        /// </summary>
        /// <param name="expression">The left side of the left shift operation.</param>
        /// <param name="operand">The right side of the left shift operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression ShiftLeftWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.ShiftLeft);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a right shift operation.
        /// </summary>
        /// <param name="expression">The left side of the right shift operation.</param>
        /// <param name="operand">The right side of the right shift operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression ShiftRightWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.ShiftRight);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs an equal comparison.
        /// </summary>
        /// <param name="expression">The left side of the equal comparison.</param>
        /// <param name="operand">The right side of the equal comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsEqualTo(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Equals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs an identical comparison.
        /// </summary>
        /// <param name="expression">The left side of the identical comparison.</param>
        /// <param name="operand">The right side of the identical comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsIdenticalTo(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Identical);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a not-equal comparison.
        /// </summary>
        /// <param name="expression">The left side of the not-equal comparison.</param>
        /// <param name="operand">The right side of the not-equal comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsNotEqualTo(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.NotEqual);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a not-identical comparison. 
        /// </summary>
        /// <param name="expression">The left side of the not-identical comparison.</param>
        /// <param name="operand">The right side of the not-identical comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsNotIdenticalTo(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.NotIdentical);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a greater-than comparison.
        /// </summary>
        /// <param name="expression">The left side of the greater-than comparison.</param>
        /// <param name="operand">The right side of the greater-than comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsGreaterThan(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.GreaterThan);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a greater-than-or-equal comparison.
        /// </summary>
        /// <param name="expression">The left side of the comparison.</param>
        /// <param name="operand">The right side of the comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsGreaterThanOrEqualTo(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.GreaterThanOrEqualTo);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a less-than comparison.
        /// </summary>
        /// <param name="expression">The left side of the less-than comparison.</param>
        /// <param name="operand">The right side of the less-than comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsLessThan(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.LessThan);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a less-than-or-equal comparison.
        /// </summary>
        /// <param name="expression">The left side of the less-than comparison.</param>
        /// <param name="operand">The right side of the less-than comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsLessThanOrEqualTo(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.LessThanOrEqualTo);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a logical and operation.
        /// </summary>
        /// <param name="expression">The left side of the logical and operation.</param>
        /// <param name="operand">The right side of the logical and operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression LogicalAndWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.LogicalAnd);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a logical or operation.
        /// </summary>
        /// <param name="expression">The left side of the logical or operation.</param>
        /// <param name="operand">The right side of the logical or operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression LogicalOrWith(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.LogicalOr);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs an instanceof operation.
        /// </summary>
        /// <param name="expression">The expression to test with instanceof.</param>
        /// <param name="operand">The expression to test for.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsInstanceOf(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.InstanceOf);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs an 'in' operation.
        /// </summary>
        /// <param name="expression">The expression as the left side of the operation.</param>
        /// <param name="operand">The expression as the right side of the operation.</param>
        /// <returns>A new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression IsIn(this Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.In);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> based on an existing one, and adds assignment to the operation.
        /// </summary>
        /// <param name="expression">The expression to base the new one on.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        /// <remarks>
        /// This method creates a new instance of <see cref="BinaryOperationExpression" />, and copies the operands from the specified expression.
        /// In addition, it will replace the operator with one that adds assignment to the opersion. For example, addition becomes add-and-assign, 
        /// multiplication becomes multiply-and-assign, and so forth.
        /// Operators that do not support assignment (mostly comparisons, logical operators) remain unchanged.
        /// </remarks>
        public static BinaryOperationExpression AndAssign(this BinaryOperationExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            BinaryOperator newOperator = expression.Operator;

            switch (expression.Operator)
            {
                case BinaryOperator.Add:
                    newOperator = BinaryOperator.AddAndAssign;
                    break;

                case BinaryOperator.Subtract:
                    newOperator = BinaryOperator.SubtractAndAssign;
                    break;

                case BinaryOperator.Multiply:
                    newOperator = BinaryOperator.MultiplyAndAssign;
                    break;

                case BinaryOperator.Divide:
                    newOperator = BinaryOperator.DivideAndAssign;
                    break;

                case BinaryOperator.Remain:
                    newOperator = BinaryOperator.RemainAndAssign;
                    break;

                case BinaryOperator.BitwiseAnd:
                    newOperator = BinaryOperator.BitwiseAndAndAssign;
                    break;

                case BinaryOperator.BitwiseOr:
                    newOperator = BinaryOperator.BitwiseOrAndAssign;
                    break;

                case BinaryOperator.BitwiseXor:
                    newOperator = BinaryOperator.BitwiseXorAndAssign;
                    break;

                case BinaryOperator.ShiftLeft:
                    newOperator = BinaryOperator.ShiftLeftAndAssign;
                    break;

                case BinaryOperator.ShiftRight:
                    newOperator = BinaryOperator.ShiftRightAndAssign;
                    break;
            }

            return new BinaryOperationExpression(expression.OperandLeft, expression.OperandRight, newOperator);
        }

        /// <summary>
        /// Combines the sequence of expressions using the specified binary operator.
        /// </summary>
        /// <param name="expressions">A sequence of expressions to combine.</param>
        /// <param name="op">The <see cref="BinaryOperator" /> to use when combining.</param>
        /// <returns>An instance of <see cref="Expression" /> that represents the combination of all the expressions in the sequence.</returns>
        /// <remarks>
        /// When the sequence is empty, null is returned.
        /// When the sequence contains a single expression, that expression is returned.
        /// In all other cases, all expressions are combined in a chain of instances of <see cref="BinaryOperationExpression" />.
        /// Null values in the sequence are replaced with instances of <see cref="NullExpression" />.
        /// </remarks>
        public static Expression Combined(this IEnumerable<Expression> expressions, BinaryOperator op)
        {
            Expression result = null;

            foreach (Expression expression in expressions.WithConvertedNulls())
            {
                if (result == null)
                {
                    result = expression;
                }
                else
                {
                    result = new BinaryOperationExpression(result, expression, op);
                }
            }

            return result;
        }
    }
}
