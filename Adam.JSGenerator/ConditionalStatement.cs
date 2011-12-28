using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines the conditional statement if-else.
    /// </summary>
    public class ConditionalStatement : Statement
    {
        private Expression _condition;
        private Statement _thenStatement;
        private Statement _elseStatement;
        private ConditionalStatement _parent;

        /// <summary>
        /// Initializes a new instance of <see cref="ConditionalStatement" />
        /// </summary>
        public ConditionalStatement()
            : this(null, null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ConditionalStatement" /> for the specified condition, true statement and false statement.
        /// </summary>
        /// <param name="condition">The condition that is tested.</param>
        /// <param name="thenStatement">The statement that is run when the condition evaluates to anything else but falsy.</param>
        /// <param name="elseStatement">The statement that is run when the condition evaluates to falsy.</param>
        public ConditionalStatement(Expression condition, Statement thenStatement, Statement elseStatement)
            : this(null, condition, thenStatement, elseStatement)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ConditionalStatement" /> for the specified condition, true statement and false statement.
        /// </summary>
        /// <param name="parent">The parent condition in a chain of if-elseif conditions.</param>
        /// <param name="condition">The condition that is tested.</param>
        /// <param name="thenStatement">The statement that is run when the condition evaluates to anything else but falsy.</param>
        /// <param name="elseStatement">The statement that is run when the condition evaluates to falsy.</param>
        public ConditionalStatement(ConditionalStatement parent, Expression condition, Statement thenStatement, Statement elseStatement)
        {
            _parent = parent;
            _condition = condition;
            _thenStatement = thenStatement;
            _elseStatement = elseStatement;
        }

        private void InternalAppendScript(StringBuilder builder, ScriptOptions options)
        {
            if (_parent != null)
            {
                _parent.InternalAppendScript(builder, options);

                builder.Append(" else ");
            }

            if (Condition == null)
            {
                throw new InvalidOperationException("Condition cannot be null.");
            }

            builder.Append("if(");
            Condition.AppendScript(builder, options);
            builder.Append(")");

            Statement then = ThenStatement ?? new EmptyStatement();

            then.AppendScript(builder, options);
            then.AppendRequiredTerminator(builder);
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

            InternalAppendScript(builder, options);

            if (ElseStatement != null)
            {
                builder.Append(" else ");
                ElseStatement.AppendScript(builder, options);
                ElseStatement.AppendRequiredTerminator(builder);
            }
        }

        #region Properties

        /// <summary>
        /// Gets or sets the condition of the conditional statement.
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
        /// Gets or sets the statement to run if the condition evaluates to true.
        /// </summary>
        public Statement ThenStatement
        {
            get
            {
                return _thenStatement;
            }
            set
            {
                _thenStatement = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement to run if the condition evaluates to falsy.
        /// </summary>
        public Statement ElseStatement
        {
            get
            {
                return _elseStatement;
            }
            set
            {
                _elseStatement = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent condition in the chain of if-then-elseif conditions.
        /// </summary>
        public ConditionalStatement Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        #endregion

    }
}
