using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines the conditional statement if-else.
    /// </summary>
    public class ConditionalStatement : Statement
    {
        private Expression _Condition;
        private Statement _ThenStatement;
        private Statement _ElseStatement;
        private ConditionalStatement _Parent;

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
            this._Parent = parent;
            this._Condition = condition;
            this._ThenStatement = thenStatement;
            this._ElseStatement = elseStatement;
        }

        private void InternalAppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            if (_Parent != null)
            {
                _Parent.InternalAppendScript(builder, options);

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

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            this.InternalAppendScript(builder, options);

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
                return _Condition;
            }
            set
            {
                _Condition = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement to run if the condition evaluates to true.
        /// </summary>
        public Statement ThenStatement
        {
            get
            {
                return _ThenStatement;
            }
            set
            {
                _ThenStatement = value;
            }
        }

        /// <summary>
        /// Gets or sets the statement to run if the condition evaluates to falsy.
        /// </summary>
        public Statement ElseStatement
        {
            get
            {
                return _ElseStatement;
            }
            set
            {
                _ElseStatement = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent condition in the chain of if-then-elseif conditions.
        /// </summary>
        public ConditionalStatement Parent
        {
            get
            {
                return this._Parent;
            }
            set
            {
                this._Parent = value;
            }
        }

        #endregion

    }
}
