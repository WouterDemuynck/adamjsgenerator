using System;
using System.Collections.Generic;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods that create new instances of <see cref="ObjectLiteralExpression" />
    /// </summary>
    public static class ObjectLiteralExpressionHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="ObjectLiteralExpression" />, by copying the specified expression's properties, and adding the specified name and value to the properties.
        /// </summary>
        /// <param name="expression">The expression to copy the properties from.</param>
        /// <param name="name">The name of the property to add.</param>
        /// <param name="value">The value of the property to add.</param>
        /// <returns>a new instance of <see cref="ObjectLiteralExpression" /></returns>
        public static ObjectLiteralExpression WithProperty(this ObjectLiteralExpression expression, Expression name, Expression value)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            ObjectLiteralExpression result = new ObjectLiteralExpression(expression.Properties);

            result.Properties[name] = value;

            return result;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ObjectLiteralExpression" />, by copying the specified expression's properties, and adding the specified properties.
        /// </summary>
        /// <param name="expression">The expression to copy the properties from.</param>
        /// <param name="values">A dictionary containing properties to add to the new instance.</param>
        /// <returns>a new instance of <see cref="ObjectLiteralExpression" /></returns>
        public static ObjectLiteralExpression WithProperties(this ObjectLiteralExpression expression, IDictionary<Expression, Expression> values)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            ObjectLiteralExpression result = new ObjectLiteralExpression(expression.Properties);

            foreach (KeyValuePair<Expression, Expression> property in values)
            {
                result.Properties[property.Key] = property.Value;
            }

            return result;
        }
    }
}
