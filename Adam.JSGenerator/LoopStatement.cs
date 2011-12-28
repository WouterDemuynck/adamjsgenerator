using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a loop statement. (for(;;);)
    /// </summary>
    public class LoopStatement : Statement
    {
        private Expression _initialization;
        private Expression _condition;
        private Expression _iteration;
        private Statement _statement;

        /// <summary>
        /// Initializes a new instance of <see cref="LoopStatement" />.
        /// </summary>
        public LoopStatement()
        {            
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LoopStatement" /> for the specified initializtion, condition, iteration and statement.
        /// </summary>
        /// <param name="initialization">The initialization of the loop.</param>
        /// <param name="condition">The condition of the loop.</param>
        /// <param name="iteration">The iteration of the loop.</param>
        /// <param name="statement">The statement to run in the loop.</param>
        /// <remarks>
        /// The Statement property cannot be null. Use an <see cref="EmptyStatement"/> statement if necessary.
        /// All of the other parameters are optional, leaving all of them out will result in an eternal loop.
        /// </remarks>
        public LoopStatement(Expression initialization, Expression condition, Expression iteration, Statement statement)
        {
            _initialization = initialization;
            _condition = condition;
            _iteration = iteration;
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

            if (_statement == null)
            {
                throw new InvalidOperationException();
            }

            builder.Append("for(");

            if (_initialization != null)
            {
                _initialization.AppendScript(builder, options);
            }

            builder.Append(";");

            if (_condition != null)
            {
                _condition.AppendScript(builder, options);
            }

            builder.Append(";");

            if (_iteration != null)
            {
                _iteration.AppendScript(builder, options);
            }

            builder.Append(")");

            _statement.AppendScript(builder, options);
            _statement.AppendRequiredTerminator(builder);
        }

        /// <summary>
        /// Gets or sets the initialization part of the loop.
        /// </summary>
        public Expression Initialization
        {
            get
            {
                return _initialization;
            }
            set
            {
                _initialization = value;
            }
        }

        /// <summary>
        /// Gets or sets the condition of the loop.
        /// </summary>
        public Expression Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
            }
        }

        /// <summary>
        /// Gets or sets the iteration part of the loop.
        /// </summary>
        public Expression Iteration
        {
            get
            {
                return _iteration;
            }
            set
            {
                _iteration = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement to run in the loop.
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
