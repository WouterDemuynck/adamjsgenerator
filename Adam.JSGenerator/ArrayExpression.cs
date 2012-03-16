using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines an expression that represents an array.
    /// </summary>
    public class ArrayExpression : Expression
    {
        private readonly List<Expression> _elements = new List<Expression>();

        /// <summary>
        /// Initializes a new empty instance of the <see cref="ArrayExpression" /> class.
        /// </summary>
        public ArrayExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayExpression" /> class using the specified elements.
        /// </summary>
        /// <param name="elements">An array of expressions to add to the Array.</param>
        public ArrayExpression(params Expression[] elements)
            : this((elements.AsEnumerable()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayExpression" /> class using the specified elements.
        /// </summary>
        /// <param name="elements">A sequence of expressions to add to the Array.</param>
        public ArrayExpression(IEnumerable<Expression> elements)
        {
            if (elements != null)
            {
                _elements.AddRange(elements);
            }
        }

    	/// <summary>
    	/// Appends the script to represent this object to the StringBuilder.
    	/// </summary>
    	/// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
    	/// <param name="options">The options to use when appending JavaScript</param>
    	/// <param name="allowReservedWords"></param>
    	internal protected override void AppendScript(StringBuilder builder, ScriptOptions options, bool allowReservedWords)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            builder.Append("[");

            bool isFirst = true;

            foreach (Expression element in _elements.WithConvertedNulls())
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    builder.Append(",");
                }

                element.AppendScript(builder, options, allowReservedWords);
            }

            builder.Append("]");
        }

        /// <summary>
        /// Gets the list of elements that make up the array.
        /// </summary>
        public IList<Expression> Elements
        {
            get
            {
                return _elements;
            }
        }
    }
}
