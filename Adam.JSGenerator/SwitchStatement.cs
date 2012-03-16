using System;
using System.Collections.Generic;
using System.Text;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines a switch statement.
    /// </summary>
    public class SwitchStatement : Statement
    {
        private Expression _expression;
        private readonly List<CaseStatement> _cases = new List<CaseStatement>();

        /// <summary>
        /// Initializes a new instance of <see cref="SwitchStatement" /> for the specified expression.
        /// </summary>
        /// <param name="expression">The expression on which to switch.</param>
        public SwitchStatement(Expression expression)
        {
            _expression = expression;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SwitchStatement" /> for the specified expression and cases.
        /// </summary>
        /// <param name="expression">The expresson on which to switch.</param>
        /// <param name="cases">A sequence of cases.</param>
        public SwitchStatement(Expression expression, IEnumerable<CaseStatement> cases)
        {
            _expression = expression;
            _cases.AddRange(cases);
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

            if (_expression == null)
            {
                throw new InvalidOperationException();
            }

            builder.Append("switch(");
            _expression.AppendScript(builder, options, allowReservedWords);
            builder.Append("){");

            bool defaultPassed = false;

            foreach (CaseStatement @case in _cases)
            {
                if (@case == null)
                {
                    continue;
                }

                if (defaultPassed)
                {
                    throw new InvalidOperationException();
                }

                @case.AppendScript(builder, options);

                if (@case.Value == null)
                {
                    defaultPassed = true;
                }
            }

            builder.Append("}");
        }

        #region Properties

        /// <summary>
        /// Gets or sets the expresson on which to switch.
        /// </summary>
        public Expression Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of cases.
        /// </summary>
        public IList<CaseStatement> Cases
        {
            get
            {
                return _cases;
            }
        }

        #endregion

    }
}
