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
        private Expression _Operand;
        private readonly List<Expression> _Arguments = new List<Expression>();

        /// <summary>
        /// Creates a new instance of the CallOperationExpression class, 
        /// calling on the provided operand with the optionally supplied arguments.
        /// </summary>
        /// <param name="operand">The expression on which to apply the call operation.</param>
        /// <param name="arguments">The arguments to pass in the call.</param>
        public CallOperationExpression(Expression operand, IEnumerable<Expression> arguments)
        {            
            this._Operand = operand;

            if (arguments != null)
            {
                this._Arguments.AddRange(arguments);
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
        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            _Operand.AppendScript(builder, options);

            builder.Append("(");

            bool isFirst = true;

            foreach (Expression param in this._Arguments.WithConvertedNulls())
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
                return _Operand;
            }
            set
            {
                _Operand = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of arguments to pass.
        /// </summary>
        public IList<Expression> Arguments
        {
            get
            {
                return this._Arguments;
            }
        }
    }
}
