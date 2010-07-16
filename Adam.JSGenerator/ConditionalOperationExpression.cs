using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Contains the conditional operation (?:)
    /// </summary>
    public class ConditionalOperationExpression : Expression
    {
        private Expression _Condition;
        private Expression _Then;
        private Expression _Else;

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
            this._Condition = condition;
            this._Then = then;
            this._Else = @else;
        }

        /// <summary>
        /// Gets or sets the condition of the operation.
        /// </summary>
        public Expression Condition
        {
            get { return _Condition; }
            set { _Condition = value; }
        }

        /// <summary>
        /// Gets or sets the expression that is returned when the condition is true.
        /// </summary>
        public Expression Then
        {
            get { return _Then; }
            set { _Then = value; }
        }

        /// <summary>
        /// Gets or sets the expression that is returned when the condition is false.
        /// </summary>
        public Expression Else
        {
            get { return _Else; }
            set { _Else = value; }
        }

        protected internal override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            if (this.Condition == null)
            {
                throw new InvalidOperationException("The Condition property cannot be null.");
            }

            if (this.Then == null)
            {
                throw new InvalidOperationException("The Then property cannot be null.");
            }

            if (this.Else == null)
            {
                throw new InvalidOperationException("The Else property cannot be null.");
            }

            // TODO: Check if we need to support Precedence.
            this.Condition.AppendScript(builder, options);
            builder.Append("?");
            this.Then.AppendScript(builder, options);
            builder.Append(":");
            this.Else.AppendScript(builder, options);
        }

        public override Precedence PrecedenceLevel
        {
            get
            {
                return new Precedence {Association = Association.RightToLeft, Level = 3};
            }
        }
    }
}
