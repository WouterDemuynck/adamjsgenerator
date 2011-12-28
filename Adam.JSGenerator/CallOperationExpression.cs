using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents a call operation on an expression.
    /// </summary>
    public class CallOperationExpression : Expression
    {
        private Expression _operand;
        private readonly List<Expression> _arguments = new List<Expression>();

        /// <summary>
        /// Creates a new instance of the CallOperationExpression class, 
        /// calling on the provided operand with the optionally supplied arguments.
        /// </summary>
        /// <param name="operand">The expression on which to apply the call operation.</param>
        /// <param name="arguments">The arguments to pass in the call.</param>
        public CallOperationExpression(Expression operand, IEnumerable<Expression> arguments)
        {            
            _operand = operand;

            if (arguments != null)
            {
                _arguments.AddRange(arguments);
            }
        }

        /// <summary>
        /// Creates a new instance of the CallOperationExpression class, 
        /// calling on the provided operand with the optionally supplied arguments.
        /// </summary>
        /// <param name="operand">The expression on which to apply the call operation.</param>
        /// <param name="arguments">The arguments to pass in the call.</param>
        public CallOperationExpression(Expression operand, params Expression[] arguments)
            : this(operand, arguments.AsEnumerable())
        {
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

            Expression operand = _operand;            

            if (operand.PrecedenceLevel.RequiresGrouping(PrecedenceLevel, Association.LeftToRight))
            {
                operand = JS.Group(_operand);
            }

            operand.AppendScript(builder, options);

            builder.Append("(");

            bool isFirst = true;

            foreach (Expression param in _arguments.WithConvertedNulls())
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    builder.Append(",");
                }

                param.AppendScript(builder, options);
            }

            builder.Append(")");
        }

        /// <summary>
        /// Gets or sets the expression on which to apply the call operation.
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
        /// Gets or sets the list of arguments to pass.
        /// </summary>
        public IList<Expression> Arguments
        {
            get
            {
                return _arguments;
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
