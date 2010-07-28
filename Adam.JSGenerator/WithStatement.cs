using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a with statement.
    /// </summary>
    public class WithStatement : Statement
    {
        private Expression _Expression;
        private Statement _Statement;

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
            this._Expression = expression;
            this._Statement = statement;
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, ScriptOptions options)
        {
            if (this._Expression == null)
            {
                throw new InvalidOperationException("Expression cannot be null.");
            }

            if (this._Statement == null)
            {
                throw new InvalidOperationException("Statement cannot be null");
            }

            builder.Append("with(");
            this._Expression.AppendScript(builder, options);
            builder.Append(")");
            this._Statement.AppendScript(builder, options);
            this._Statement.AppendRequiredTerminator(builder);
        }

        /// <summary>
        /// Gets or sets the expression that is added to the scope.
        /// </summary>
        public Expression Expression
        {
            get
            {
                return this._Expression;
            }
            set
            {
                this._Expression = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement that is run in the scope.
        /// </summary>
        public Statement Statement
        {
            get
            {
                return this._Statement;
            }
            set
            {
                this._Statement = value;
            }
        }
    }
}
