using System.Collections;
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
        {
            this._Properties = new Dictionary<Expression, Expression>();
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

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectLiteralExpression" /> that defines the specified properties.
        /// </summary>
        /// <param name="properties"></param>
        public static ObjectLiteralExpression FromDictionary(IDictionary properties)
        {
            var result = new ObjectLiteralExpression();

            if (properties != null)
            {
                foreach (DictionaryEntry property in properties)
                {
                    Expression key = property.Key as Expression;

                    if (key == null)
                    {
                        string keyString = property.Key.ToString();

                        key = JS.IsValidIdentifier(keyString) ? (Expression) JS.Id(keyString) : JS.String(keyString);
                    }

                    result.Properties.Add(key, FromObject(property.Value));
                }
            }

            return result;
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, ScriptOptions options)
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

                Expression key = element.Key;

                if (options.AlwaysQuoteObjectLiteralKeys)
                {
                    IdentifierExpression identifier = key as IdentifierExpression;

                    if (identifier != null)
                    {
                        StringExpression quotedIdentifier = new StringExpression(identifier.Name);
                        key = quotedIdentifier;
                    }
                }

                key.AppendScript(builder, options);
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
