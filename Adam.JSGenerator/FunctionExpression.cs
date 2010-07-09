using System.Collections.Generic;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a function expression.
    /// </summary>
    public class FunctionExpression : Expression
    {
        private IdentifierExpression _Name;
        private readonly List<IdentifierExpression> _Parameters = new List<IdentifierExpression>();
        private CompoundStatement _Body;

        /// <summary>
        /// Initializes a new instance of <see cref="FunctionExpression" />.
        /// </summary>
        public FunctionExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="FunctionExpression" /> for the specified name, parameters and body.
        /// </summary>
        /// <param name="name">The name of the function, if not anonymous.</param>
        /// <param name="parameters">The parameters that the function expects.</param>
        /// <param name="body">The body of the function.</param>
        public FunctionExpression(IdentifierExpression name, IEnumerable<IdentifierExpression> parameters, CompoundStatement body)
        {
            this._Name = name;
            this._Body = body;

            if (parameters != null)
            {
                this._Parameters.AddRange(parameters);
            }
        }

        /// <summary>
        /// Gets or sets the name of the function. Specify null for an anonymous function.
        /// </summary>
        public IdentifierExpression Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of parameters for the function.
        /// </summary>
        public IList<IdentifierExpression> Parameters
        {
            get
            {
                return _Parameters;
            }
        }

        /// <summary>
        /// Gets or sets the body of the function.
        /// </summary>
        public CompoundStatement Body
        {
            get
            {
                return _Body;
            }
            set
            {
                _Body = value;
            }
        }

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            builder.Append("function");

            if (this._Name != null)
            {
                builder.Append(" ");
                this._Name.AppendScript(builder, options);
            }

            builder.Append("(");

            bool isFirst = true;

            foreach (IdentifierExpression item in this._Parameters)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    builder.Append(",");
                }

                item.AppendScript(builder, options);
            }

            builder.Append(")");

            (this._Body ?? new CompoundStatement()).AppendScript(builder, options);
        }

    }
}
