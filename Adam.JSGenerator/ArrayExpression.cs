﻿using System;
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
        private readonly List<Expression> _Elements = new List<Expression>();

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
                this._Elements.AddRange(elements);
            }
        }

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            builder.Append("[");

            bool isFirst = true;

            foreach (Expression element in this._Elements.WithConvertedNulls())
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    builder.Append(",");
                }

                element.AppendScript(builder, options);
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
                return _Elements;
            }
        }
    }
}
