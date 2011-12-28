using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a with statement.
    /// </summary>
    public class WithStatement : Statement
    {
        private Expression _expression;
        private Statement _statement;

        /// <summary>
        /// Initializes a new instance of <see cref="WithStatement" />.
        /// </summary>
        public WithStatement()
        {            
        }

        /// <summary>
        /// Initializes a new instance of <see cref="WithStatement" /> for the specified expression and statement.
        /// </summary>
        /// <param name="expression">The expression to add to the scope.</param>
        /// <param name="statement">The statement to run in the scope.</param>
        public WithStatement(Expression expression, Statement statement)
        {
            _expression = expression;
            _statement = statement;
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

            if (_expression == null)
            {
                throw new InvalidOperationException();
            }

            if (_statement == null)
            {
                throw new InvalidOperationException();
            }

            builder.Append("with(");
            _expression.AppendScript(builder, options);
            builder.Append(")");
            _statement.AppendScript(builder, options);
            _statement.AppendRequiredTerminator(builder);
        }

        /// <summary>
        /// Gets or sets the expression that is added to the scope.
        /// </summary>
        public Expression Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement that is run in the scope.
        /// </summary>
        public Statement Statement
        {
            get
            {
                return _statement;
            }
            set
            {
                _statement = value;
            }
        }
    }
}
