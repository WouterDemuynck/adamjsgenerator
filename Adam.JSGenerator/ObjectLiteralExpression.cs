using System.Collections.Generic;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines an object literal.
    /// </summary>
    public class ObjectLiteralExpression : Expression
    {
        private readonly Dictionary<Expression, Expression> _Properties;

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectLiteralExpression" />.
        /// </summary>
        public ObjectLiteralExpression()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectLiteralExpression" /> that defines the specified properties.
        /// </summary>
        /// <param name="properties"></param>
        public ObjectLiteralExpression(IDictionary<Expression, Expression> properties)
        {
            if (properties != null)
            {
                this._Properties = new Dictionary<Expression, Expression>(properties);
            }
            else
            {
                this._Properties = new Dictionary<Expression, Expression>();
            }
        }

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            builder.Append("{");

            bool isFirst = true;

            foreach (KeyValuePair<Expression, Expression> element in this._Properties)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    builder.Append(",");
                }

                element.Key.AppendScript(builder, options);
                builder.Append(":");

                if (element.Value != null)
                {
                    element.Value.AppendScript(builder, options);
                }
                else
                {
                    JS.Null().AppendScript(builder, options);
                }
            }

            builder.Append("}");
        }

        /// <summary>
        /// Gets or sets the dictionary of properties.
        /// </summary>
        public IDictionary<Expression, Expression> Properties
        {
            get
            {
                return this._Properties;
            }
        }

    }
}
