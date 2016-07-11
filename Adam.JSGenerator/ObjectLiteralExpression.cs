using System;
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
        private readonly Dictionary<Expression, Expression> _properties;

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectLiteralExpression" />.
        /// </summary>
        public ObjectLiteralExpression()
        {
            _properties = new Dictionary<Expression, Expression>();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectLiteralExpression" /> that defines the specified properties.
        /// </summary>
        /// <param name="properties"></param>
        public ObjectLiteralExpression(IDictionary<Expression, Expression> properties)
        {
            _properties = properties != null 
                ? new Dictionary<Expression, Expression>(properties) 
                : new Dictionary<Expression, Expression>();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectLiteralExpression" />.
        /// </summary>
        /// <param name="value">The object whose properties will be represented by the object literal.</param>
        /// <remarks>
        /// This method calls <see cref="JS.GetValues" /> to retrieve all the properties of the specified object.
        /// </remarks>
        public ObjectLiteralExpression(object value) : this(JS.GetValues(value))
        {
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

            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            builder.Append("{");

            bool isFirst = true;

            foreach (KeyValuePair<Expression, Expression> element in _properties)
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
                    	key = new StringExpression(identifier.Name);
                    }
                }

                key.AppendScript(builder, options, true);
                builder.Append(":");

                if (element.Value != null)
                {
                    element.Value.AppendScript(builder, options, allowReservedWords);
                }
                else
                {
                    JS.Null().AppendScript(builder, options, allowReservedWords);
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
                return _properties;
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectLiteralExpression" /> that defines the specified properties.
        /// </summary>
        /// <param name="properties"></param>
        public static ObjectLiteralExpression FromDictionary(IDictionary properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException("properties");
            }

            var result = new ObjectLiteralExpression();
            
            foreach (DictionaryEntry property in properties)
            {
                Expression key = property.Key as Expression ?? 
                    (JS.IsValidIdentifier(property.Key.ToString()) 
                        ? JS.Id(property.Key.ToString()) 
                        : FromString(property.Key.ToString()));

                result.Properties.Add(key, FromObject(property.Value));
            }

            return result;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ObjectLiteralExpression" /> representing the keys and values of the specified <see cref="IDictionary{K,V}" />.
        /// </summary>
        /// <typeparam name="TKey">The type of Key.</typeparam>
        /// <typeparam name="TValue">The type of Value.</typeparam>
        /// <param name="dictionary">The dictionary from which to extract the keys and values to represent.</param>
        /// <returns>A new instance of <see cref="ObjectLiteralExpression" />.</returns>
        public static ObjectLiteralExpression FromDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            ObjectLiteralExpression result = new ObjectLiteralExpression();

            foreach (var pair in dictionary)
            {
                Expression key = pair.Key as Expression ?? 
                    (JS.IsValidIdentifier(pair.Key.ToString()) 
                        ? JS.Id(pair.Key.ToString()) 
                        : FromString(pair.Key.ToString()));

                result.Properties.Add(key, FromObject(pair.Value));
            }

            return result;
        }
    }
}
