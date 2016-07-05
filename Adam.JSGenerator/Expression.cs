using System;
using System.Collections;
using System.Globalization;

namespace Adam.JSGenerator
{
	/// <summary>
	/// The base class to all forms of expressions.
	/// </summary>
	public abstract class Expression : Statement
	{
		/// <summary>
		/// Indicates that this object requires a terminating semicolon when used as a statement.
		/// </summary>
		internal protected override bool RequiresTerminator
		{
			get
			{
				// An expression usually needs to be terminated.
				return true;
			}
		}		


		/// <summary>
		/// Indicates the level of precedence valid for this expresison.
		/// </summary>
		/// <remarks>
		/// This is used when combining expressions, to determine where parens are needed.
		/// </remarks>
		public virtual Precedence PrecedenceLevel
		{
			get
			{
				return new Precedence { Level = 16, Association = Association.LeftToRight };
			}
		}

		/// <summary>
		/// Converts a Boolean into a <see cref="BooleanExpression" /> that represents its value.
		/// </summary>
		/// <param name="value">The Boolean to convert.</param>
		/// <returns>An instance of <see cref="BooleanExpression" /> that represents its value.</returns>
		public static implicit operator Expression(bool value)
		{
			return new BooleanExpression(value);
		}

		/// <summary>
		/// Converts a Boolean into a <see cref="BooleanExpression" /> that represents its value.
		/// </summary>
		/// <param name="value">The Boolean to convert.</param>
		/// <returns>An instance of <see cref="BooleanExpression" /> that represents its value.</returns>
		public static Expression FromBoolean(bool value)
		{
			return new BooleanExpression(value);
		}

		/// <summary>
		/// Converts an integer into a <see cref="NumberExpression" /> that represents its value.
		/// </summary>
		/// <param name="value">The integer to convert.</param>
		/// <returns>The LiteralExpression object that represents its value.</returns>
		public static implicit operator Expression(int value)
		{
			return new NumberExpression(value);
		}

		/// <summary>
		/// Converts an integer into a <see cref="NumberExpression" /> that represents its value.
		/// </summary>
		/// <param name="value">The integer to convert.</param>
		/// <returns>The <see cref="NumberExpression" /> object that represents its value.</returns>
		public static Expression FromInteger(int value)
		{
			return new NumberExpression(value);
		}

		/// <summary>
		/// Converts a double into a <see cref="NumberExpression" /> that represents its value.
		/// </summary>
		/// <param name="value">The double to convert.</param>
		/// <returns>The <see cref="NumberExpression" /> object that represents its value.</returns>
		public static implicit operator Expression(double value)
		{
			return new NumberExpression(value);
		}

		/// <summary>
		/// Converts a double into a <see cref="NumberExpression" /> that represents its value.
		/// </summary>
		/// <param name="value">The double to convert.</param>
		/// <returns>The <see cref="NumberExpression" /> object that represents its value.</returns>
		public static Expression FromDouble(double value)
		{
			return new NumberExpression(value);
		}

		/// <summary>
		/// Converts a string into a <see cref="StringExpression" /> that represents its value.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The <see cref="StringExpression" /> object that represents its value.</returns>
		public static implicit operator Expression(string value)
		{
			return value != null ? (Expression)new StringExpression(value) : new NullExpression();
		}

		/// <summary>
		/// Converts a string into a <see cref="StringExpression" /> that represents its value.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The <see cref="StringExpression" /> object that represents its value.</returns>
		public static Expression FromString(string value)
		{
			return new StringExpression(value);
		}

		/// <summary>
		/// Converts an array into a <see cref="ArrayExpression" /> that represents its value.
		/// </summary>
		/// <param name="array">The array to convert</param>
		/// <returns>The <see cref="ArrayExpression" /> object that represents its value.</returns>
		public static implicit operator Expression(Array array)
		{
			return array != null ? (Expression)JS.Array((IEnumerable)array) : new NullExpression();
		}

		/// <summary>
		/// Converts an array into a <see cref="ArrayExpression" /> that represents its value.
		/// </summary>
		/// <param name="array">The array to convert</param>
		/// <returns>The <see cref="ArrayExpression" /> object that represents its value.</returns>
		public static Expression FromArray(Array array)
		{
			return JS.Array((IEnumerable)array);
		}

		/// <summary>
		/// Converts any object into an <see cref="Expression" /> object.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Expression FromObject(object value)
		{
			Expression result = value as Expression;

			if (result != null)
			{
				return result;
			}

			IEnumerable enumerable;
			IDictionary dictionary;
			string str;
			double d;

			if (value == null)
			{
				result = JS.Null();
			}
			else if ((str = value as string) != null)
			{
				result = FromString(str);
			}
			else if (value is Statement)
			{
				throw new InvalidOperationException("A statement cannot be used as an expression.");
			}
			else if ((dictionary = value as IDictionary) != null)
			{
				result = ObjectLiteralExpression.FromDictionary(dictionary);
			}
			else if ((enumerable = value as IEnumerable) != null)
			{
				result = JS.ArrayOrObject(enumerable);
			}
			else if (value.GetType().IsClass)
			{
				result = JS.Object(JS.GetValues(value));
			}
			else if (value is Boolean)
			{
				result = FromBoolean((bool)value);
			}
			else if (double.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, out d))
			{
				result = FromDouble(d);
			}
			else
			{
				result = FromString(value.ToString());
			}

			return result;
		}

        #region Overloaded operators

        #region Binary operation expressions

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that adds one expression to another.
        /// </summary>
        /// <param name="expression">The left side of the addition.</param>
        /// <param name="operand">The right side of the addition.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator +(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Add);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that subtracts one expression from another.
        /// </summary>
        /// <param name="expression">The left side of the subtraction.</param>
        /// <param name="operand">The right side of the subtraction.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator -(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Subtract);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that multiplies one expression by another.
        /// </summary>
        /// <param name="expression">The left side of the multiplication.</param>
        /// <param name="operand">The right side of the multiplication.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator *(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Multiply);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that divides one expression by another.
        /// </summary>
        /// <param name="expression">The left side of the division.</param>
        /// <param name="operand">The right side of the division.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator /(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Divide);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that computes the remainder of a division.
        /// </summary>
        /// <param name="expression">The left side of the remainder operation.</param>
        /// <param name="operand">The right side of the remainder operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator %(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.Remain);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a bitwise and operation.
        /// </summary>
        /// <param name="expression">The left side of the bitwise and operation.</param>
        /// <param name="operand">The right side of the bitwise and operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator &(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.BitwiseAnd);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a bitwise or operation.
        /// </summary>
        /// <param name="expression">The left side of the bitwise or operation.</param>
        /// <param name="operand">The right side of the bitwise or operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator |(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.BitwiseOr);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a bitwise exclusive or operation.
        /// </summary>
        /// <param name="expression">The left side of the bitwise exclusive or operation.</param>
        /// <param name="operand">The right side of the bitwise exclusive or operation.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator ^(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.BitwiseXor);
        }
        
        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a greater-than comparison.
        /// </summary>
        /// <param name="expression">The left side of the greater-than comparison.</param>
        /// <param name="operand">The right side of the greater-than comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator >(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.GreaterThan);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a greater-than-or-equal comparison.
        /// </summary>
        /// <param name="expression">The left side of the comparison.</param>
        /// <param name="operand">The right side of the comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator >=(Expression expression, Expression operand)
        {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.GreaterThanOrEqualTo);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a less-than comparison.
        /// </summary>
        /// <param name="expression">The left side of the less-than comparison.</param>
        /// <param name="operand">The right side of the less-than comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator <(Expression expression, Expression operand)
	    {
            return new BinaryOperationExpression(expression, operand, BinaryOperator.LessThan);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BinaryOperationExpression" /> that performs a less-than-or-equal comparison.
        /// </summary>
        /// <param name="expression">The left side of the less-than comparison.</param>
        /// <param name="operand">The right side of the less-than comparison.</param>
        /// <returns>a new instance of <see cref="BinaryOperationExpression" />.</returns>
        public static BinaryOperationExpression operator <=(Expression expression, Expression operand)
	    {
	        return new BinaryOperationExpression(expression, operand, BinaryOperator.LessThanOrEqualTo);
	    }
        
        #endregion

        #region Unary operation expressions

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that converts an expression to a number.
        /// </summary>
        /// <param name="expression">The expression to convert to a number.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        /// <remarks>
        /// Even though some sources state that the unary + operator is close to a no-op, the standard ECMA-262 clearly states its
        /// purpose on p.72: to convert an expression to a number. If the expression cannot be converted, NaN is returned.
        /// </remarks>
        public static UnaryOperationExpression operator +(Expression expression)
        {
            return new UnaryOperationExpression(expression, UnaryOperator.Number);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that negates the specified expression.
        /// </summary>
        /// <param name="expression">The expression to negate.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression operator -(Expression expression)
        {
            return new UnaryOperationExpression(expression, UnaryOperator.Negative);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a bitwise not operation.
        /// </summary>
        /// <param name="expression">The expression on which to perform a bitwise not operation.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression operator ~(Expression expression)
        {
            return new UnaryOperationExpression(expression, UnaryOperator.BitwiseNot);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a logical not operation.
        /// </summary>
        /// <param name="expression">The expression on which to perform a logical not operation.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static UnaryOperationExpression operator !(Expression expression)
	    {
	        return new UnaryOperationExpression(expression, UnaryOperator.LogicalNot);
	    }

	    #endregion

        #endregion

    }
}
