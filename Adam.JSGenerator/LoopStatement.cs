using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a loop statement. (for(;;);)
    /// </summary>
    public class LoopStatement : Statement
    {
        private Expression _Initialization;
        private Expression _Condition;
        private Expression _Iteration;
        private Statement _Statement;

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
            this._Initialization = initialization;
            this._Condition = condition;
            this._Iteration = iteration;
            this._Statement = statement;
        }

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            if (this._Statement == null)
            {
                throw new InvalidOperationException("Statement cannot be null. Use EmptyStatement instead.");
            }

            builder.Append("for(");

            if (this._Initialization != null)
            {
                this._Initialization.AppendScript(builder, options);
            }

            builder.Append(";");

            if (this._Condition != null)
            {
                this._Condition.AppendScript(builder, options);
            }

            builder.Append(";");

            if (this._Iteration != null)
            {
                this._Iteration.AppendScript(builder, options);
            }

            builder.Append(")");

            this._Statement.AppendScript(builder, options);
            this._Statement.AppendRequiredTerminator(builder);
        }

        /// <summary>
        /// Gets or sets the initialization part of the loop.
        /// </summary>
        public Expression Initialization
        {
            get
            {
                return _Initialization;
            }
            set
            {
                _Initialization = value;
            }
        }

        /// <summary>
        /// Gets or sets the condition of the loop.
        /// </summary>
        public Expression Condition
        {
            get
            {
                return _Condition;
            }
            set
            {
                _Condition = value;
            }
        }

        /// <summary>
        /// Gets or sets the iteration part of the loop.
        /// </summary>
        public Expression Iteration
        {
            get
            {
                return _Iteration;
            }
            set
            {
                _Iteration = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement to run in the loop.
        /// </summary>
        public Statement Statement
        {
            get
            {
                return _Statement;
            }
            set
            {
                _Statement = value;
            }
        }

    }
}
