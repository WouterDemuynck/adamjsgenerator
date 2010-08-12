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
        private Expression _Expression;
        private readonly List<CaseStatement> _Cases = new List<CaseStatement>();

        /// <summary>
        /// Initializes a new instance of <see cref="SwitchStatement" /> for the specified expression.
        /// </summary>
        /// <param name="expression">The expression on which to switch.</param>
        public SwitchStatement(Expression expression)
        {
            this._Expression = expression;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SwitchStatement" /> for the specified expression and cases.
        /// </summary>
        /// <param name="expression">The expresson on which to switch.</param>
        /// <param name="cases">A sequence of cases.</param>
        public SwitchStatement(Expression expression, IEnumerable<CaseStatement> cases)
        {
            this._Expression = expression;
            this._Cases.AddRange(cases);
        }

        /// <summary>
        /// Appends the script to represent this object to the StringBuilder.
        /// </summary>
        /// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
        /// <param name="options">The options to use when appending JavaScript</param>
        internal protected override void AppendScript(StringBuilder builder, ScriptOptions options)
        {
            if (this._Expression == null)
            {
                throw new InvalidOperationException("Expression cannot be null.");
            }

            builder.Append("switch(");
            this._Expression.AppendScript(builder, options);
            builder.Append("){");

            bool defaultPassed = false;

            foreach (CaseStatement @case in _Cases)
            {
                if (@case == null)
                {
                    continue;
                }

                if (defaultPassed)
                {
                    throw new InvalidOperationException("The default case must be the last in the sequence.");
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
                return _Expression;
            }
            set
            {
                _Expression = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of cases.
        /// </summary>
        public IList<CaseStatement> Cases
        {
            get
            {
                return _Cases;
            }
        }

        #endregion

    }
}
