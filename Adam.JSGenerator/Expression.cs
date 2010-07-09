namespace Adam.JSGenerator
{
    /// <summary>
    /// The base class to all forms of expressions.
    /// </summary>
    public abstract class Expression : Statement
    {
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
        public static BooleanExpression FromBoolean(bool value)
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
        public static NumberExpression FromInteger(int value)
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
        public static NumberExpression FromDouble(double value)
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
            return new StringExpression(value);
        }

        /// <summary>
        /// Converts a string into a <see cref="StringExpression" /> that represents its value.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The <see cref="StringExpression" /> object that represents its value.</returns>
        public static StringExpression FromString(string value)
        {
            return new StringExpression(value);
        }
    }
}
