using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines an interating for-loop. (for (var v in c))
    /// </summary>
    public class IteratorStatement : Statement
    {
        private Expression _variable;
        private Expression _collection;
        private Statement _statement;

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
            Variable = variable;
            Collection = collection;
            Statement = statement;
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

            if (_variable == null)
            {
                throw new InvalidOperationException();
            }

            if (_collection == null)
            {
                throw new InvalidOperationException();
            }

            if (_statement == null)
            {
                throw new InvalidOperationException();
            }

            builder.Append("for(");
            _variable.AppendScript(builder, options, allowReservedWords);
            builder.Append(" in ");
            _collection.AppendScript(builder, options, allowReservedWords);
            builder.Append(")");
            _statement.AppendScript(builder, options, allowReservedWords);
            _statement.AppendRequiredTerminator(builder);
        }

        /// <summary>
        /// Gets or sets the variable that holds the value of the iteration.
        /// </summary>
        public Expression Variable
        {
            get
            {
                return _variable;
            }
            set
            {
                _variable = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection that is iterated on.
        /// </summary>
        public Expression Collection
        {
            get
            {
                return _collection;
            }
            set
            {
                _collection = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement that is run on each iteration.
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
