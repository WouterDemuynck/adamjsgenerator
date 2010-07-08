using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines an execption handling statement e.g. try-catch-finally.
    /// </summary>
    public class ExceptionHandlingStatement : Statement
    {
        private CompoundStatement _TryBlock;
        private IdentifierExpression _CatchVariable;
        private CompoundStatement _CatchBlock;
        private CompoundStatement _FinallyBlock;

        /// <summary>
        /// Initializes a new instance of <see cref="ExceptionHandlingStatement" />.
        /// </summary>
        public ExceptionHandlingStatement()
        {            
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ExceptionHandlingStatement" /> for the specified try, catch and finally blocks.
        /// </summary>
        /// <param name="tryBlock">The try block of the statement.</param>
        /// <param name="catchVariable">The variable that contains the exception for the catch block.</param>
        /// <param name="catchBlock">The catch block of the statement.</param>
        /// <param name="finallyBlock">The finally block of the statement.</param>
        public ExceptionHandlingStatement(CompoundStatement tryBlock, IdentifierExpression catchVariable, CompoundStatement catchBlock, CompoundStatement finallyBlock)
        {
            this._TryBlock = tryBlock;
            this._CatchVariable = catchVariable;
            this._CatchBlock = catchBlock;
            this._FinallyBlock = finallyBlock;
        }

        internal protected override void AppendScript(StringBuilder builder, GenerateJavaScriptOptions options)
        {
            if (this._TryBlock == null)
            {
                throw new InvalidOperationException("TryBlock cannot be null.");
            }

            builder.Append("try");
            this._TryBlock.AppendScript(builder, options);

            if (this.CatchBlock != null)
            {
                if (this.CatchVariable == null)
                {
                    throw new InvalidOperationException("CatchVariable cannot be null.");
                }

                builder.Append("catch(");
                this.CatchVariable.AppendScript(builder, options);
                builder.Append(")");
                this.CatchBlock.AppendScript(builder, options);
            }

            if (this.FinallyBlock != null)
            {
                builder.Append("finally");
                this.FinallyBlock.AppendScript(builder, options);
            }
        }

        /// <summary>
        /// Gets or sets the try block.
        /// </summary>
        public CompoundStatement TryBlock
        {
            get
            {
                return this._TryBlock;
            }
            set
            {
                this._TryBlock = value;
            }
        }

        /// <summary>
        /// Gets or sets the variable that will hold the exception for the catch block.
        /// </summary>
        public IdentifierExpression CatchVariable
        {
            get
            {
                return this._CatchVariable;
            }
            set
            {
                this._CatchVariable = value;
            }
        }

        /// <summary>
        /// Gets or sets the catch block.
        /// </summary>
        public CompoundStatement CatchBlock
        {
            get
            {
                return this._CatchBlock;
            }
            set
            {
                this._CatchBlock = value;
            }
        }

        /// <summary>
        /// Gets or sets the finally block.
        /// </summary>
        public CompoundStatement FinallyBlock
        {
            get
            {
                return this._FinallyBlock;
            }
            set
            {
                this._FinallyBlock = value;
            }
        }


    }
}
