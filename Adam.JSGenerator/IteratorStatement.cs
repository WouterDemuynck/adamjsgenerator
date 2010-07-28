using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines an interating for-loop. (for (var v in c))
    /// </summary>
    public class IteratorStatement : Statement
    {
        private Expression _Variable;
        private Expression _Collection;
        private Statement _Statement;

        /// <summary>
        /// Initializes a new instance of <see cref="IteratorStatement" />.
        /// </summary>
        public IteratorStatement()
            : this(null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IteratorStatement" /> for the specified variable, collection and statement.
        /// </summary>
        /// <param name="variable">The variable that holds the item for an iteration.</param>
        /// <param name="collection">The collection on which to iterate.</param>
        /// <param name="statement">The statement to run on each iteration.</param>
        public IteratorStatement(Expression variable, Expression collection, Statement statement)
        {
            this.Variable = variable;
            this.Collection = collection;
            this.Statement = statement;
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, ScriptOptions options)
        {
            if (this._Variable == null)
            {
                throw new InvalidOperationException("Variable cannot be null.");
            }

            if (this._Collection == null)
            {
                throw new InvalidOperationException("Collection cannot be null.");
            }

            if (this._Statement == null)
            {
                throw new InvalidOperationException("Statement cannot be null");
            }

            builder.Append("for(");
            this._Variable.AppendScript(builder, options);
            builder.Append(" in ");
            this._Collection.AppendScript(builder, options);
            builder.Append(")");
            this._Statement.AppendScript(builder, options);
            this._Statement.AppendRequiredTerminator(builder);
        }

        /// <summary>
        /// Gets or sets the variable that holds the value of the iteration.
        /// </summary>
        public Expression Variable
        {
            get
            {
                return this._Variable;
            }
            set
            {
                this._Variable = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection that is iterated on.
        /// </summary>
        public Expression Collection
        {
            get
            {
                return this._Collection;
            }
            set
            {
                this._Collection = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement that is run on each iteration.
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
