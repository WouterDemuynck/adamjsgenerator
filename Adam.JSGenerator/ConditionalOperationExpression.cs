using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Contains the conditional operation (?:)
    /// </summary>
    public class ConditionalOperationExpression : Expression
    {
        private Expression _condition;
        private Expression _then;
        private Expression _else;

        /// <summary>
        /// Initializes a new instance of <see cref="ConditionalOperationExpression" />.
        /// </summary>
        public ConditionalOperationExpression()
        {            
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ConditionalOperationExpression" />.
        /// </summary>
        public ConditionalOperationExpression(Expression condition, Expression then, Expression @else)
        {
            _condition = condition;
            _then = then;
            _else = @else;
        }

        /// <summary>
        /// Gets or sets the condition of the operation.
        /// </summary>
        public Expression Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        /// <summary>
        /// Gets or sets the expression that is returned when the condition is true.
        /// </summary>
        public Expression Then
        {
            get { return _then; }
            set { _then = value; }
        }

        /// <summary>
        /// Gets or sets the expression that is returned when the condition is false.
        /// </summary>
        public Expression Else
        {
            get { return _else; }
            set { _else = value; }
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        protected internal override void AppendScript(StringBuilder builder, ScriptOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            if (Condition == null)
            {
                throw new InvalidOperationException("The Condition property cannot be null.");
            }

            if (Then == null)
            {
                throw new InvalidOperationException("The Then property cannot be null.");
            }

            if (Else == null)
            {
                throw new InvalidOperationException("The Else property cannot be null.");
            }

            // TODO: Check if we need to support Precedence.
            Condition.AppendScript(builder, options);
            builder.Append("?");
            Then.AppendScript(builder, options);
            builder.Append(":");
            Else.AppendScript(builder, options);
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
                return new Precedence {Association = Association.RightToLeft, Level = 3};
            }
        }
    }
}
