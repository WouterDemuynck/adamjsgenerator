using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a label statement.
    /// </summary>
    public class LabelStatement : Statement
    {
        private IdentifierExpression _name;
        private Statement _statement;

        /// <summary>
        /// Initializes a new instance of <see cref="LabelStatement" /> that precedes the specified statement with a label.
        /// </summary>
        /// <param name="name">The name of the label.</param>
        /// <param name="statement">The statement to precede.</param>
        public LabelStatement(IdentifierExpression name, Statement statement)
        {
            _name = name;
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

            _name.AppendScript(builder, options);
            builder.Append(":");
            _statement.AppendScript(builder, options);
            _statement.AppendRequiredTerminator(builder);
        }

        /// <summary>
        /// Gets or sets the name of the label.
        /// </summary>
        public IdentifierExpression Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement to precede.
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
