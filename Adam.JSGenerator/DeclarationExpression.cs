using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a declaration expression (e.g. 'var').
    /// </summary>
    public class DeclarationExpression : Expression
    {
        private List<Expression> _Expressions = new List<Expression>();

        /// <summary>
        /// Initializes a new instance of <see cref="DeclarationExpression" />.
        /// </summary>
        public DeclarationExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DeclarationExpression" /> that declares the specified expressions.
        /// </summary>
        /// <param name="expressions">An array of expression to declare.</param>
        public DeclarationExpression(params Expression[] expressions)
        {
            if (expressions != null)
            {
                this._Expressions.AddRange(expressions);
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DeclarationExpression" /> that declares the specified expressions.
        /// </summary>
        /// <param name="expressions">A sequence of expression to declare.</param>
        public DeclarationExpression(IEnumerable<Expression> expressions)
        {
            if (expressions != null)
            {
                this._Expressions.AddRange(expressions);
            }
        }

        /// <summary>
        /// Gets or sets a list of expressions to declare.
        /// </summary>
        public List<Expression> Expressions
        {
            get
            {
                return this._Expressions;
            }
            set
            {
                this._Expressions = value;
            }
        }

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            if (this._Expressions == null)
            {
                throw new InvalidOperationException("Expressions cannot be null.");
            }

            if (!this._Expressions.Any())
            {
                throw new InvalidOperationException("Expressions cannot be empty.");
            }

            builder.Append("var ");

            bool first = true;

            foreach (Expression expression in this._Expressions)
            {
                if (!first)
                {
                    builder.Append(",");
                }
                else
                {
                    first = false;                        
                }

                expression.AppendScript(builder, options);                    
            }
        }
    }
}
