using System;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines an execption handling statement e.g. try-catch-finally.
    /// </summary>
    public class ExceptionHandlingStatement : Statement
    {
        private CompoundStatement _tryBlock;
        private IdentifierExpression _catchVariable;
        private CompoundStatement _catchBlock;
        private CompoundStatement _finallyBlock;

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
            _tryBlock = tryBlock;
            _catchVariable = catchVariable;
            _catchBlock = catchBlock;
            _finallyBlock = finallyBlock;
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

            if (_tryBlock == null)
            {
                throw new InvalidOperationException();
            }

            builder.Append("try");
            _tryBlock.AppendScript(builder, options, allowReservedWords);

            if (CatchBlock != null)
            {
                if (CatchVariable == null)
                {                    
                    throw new InvalidOperationException();
                }

                builder.Append("catch(");
                CatchVariable.AppendScript(builder, options, allowReservedWords);
                builder.Append(")");
                CatchBlock.AppendScript(builder, options, allowReservedWords);
            }

            if (FinallyBlock != null)
            {
                builder.Append("finally");
                FinallyBlock.AppendScript(builder, options, allowReservedWords);
            }
        }

        /// <summary>
        /// Gets or sets the try block.
        /// </summary>
        public CompoundStatement TryBlock
        {
            get
            {
                return _tryBlock;
            }
            set
            {
                _tryBlock = value;
            }
        }

        /// <summary>
        /// Gets or sets the variable that will hold the exception for the catch block.
        /// </summary>
        public IdentifierExpression CatchVariable
        {
            get
            {
                return _catchVariable;
            }
            set
            {
                _catchVariable = value;
            }
        }

        /// <summary>
        /// Gets or sets the catch block.
        /// </summary>
        public CompoundStatement CatchBlock
        {
            get
            {
                return _catchBlock;
            }
            set
            {
                _catchBlock = value;
            }
        }

        /// <summary>
        /// Gets or sets the finally block.
        /// </summary>
        public CompoundStatement FinallyBlock
        {
            get
            {
                return _finallyBlock;
            }
            set
            {
                _finallyBlock = value;
            }
        }
    }
}
