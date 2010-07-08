using System.Globalization;

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
        /// Converts a Boolean into a LiteralExpression that represents its value.
        /// </summary>
        /// <param name="b">The Boolean to convert.</param>
        /// <returns>An instance of LiteralExpression that represents its value.</returns>
        public static implicit operator Expression(bool b)
        {
            return new BooleanExpression(b);
        }

        /// <summary>
        /// Converts an integer into a LiteralExpression that represents its value.
        /// </summary>
        /// <param name="i">The integer to convert.</param>
        /// <returns>The LiteralExpression object that represents its value.</returns>
        public static implicit operator Expression(int i)
        {
            return new NumberExpression(i);
        }

        /// <summary>
        /// Converts a double into a LiteralExpression that represents its value.
        /// </summary>
        /// <param name="d">The double to convert.</param>
        /// <returns>The LiteralExpression object that represents its value.</returns>
        public static implicit operator Expression(double d)
        {
            return new NumberExpression(d);
        }

        /// <summary>
        /// Converts a string into a LiteralExpression that represents its value.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>The LiteralExpression object that represents its value.</returns>
        public static implicit operator Expression(string s)
        {
            return new StringExpression(s);
        }
    }
}
