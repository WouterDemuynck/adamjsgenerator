﻿using System;
using System.Text;

namespace Adam.JSGenerator
{
	/// <summary>
	/// Represents an expression whose value is inserted as is.
	/// </summary>
	public class SnippetExpression : Expression
	{
		private string _value;

		/// <summary>
		/// Initializes a new instance of <see cref="SnippetExpression" /> for the specified Value.
		/// </summary>
		/// <param name="value">The string value that this instance must represent.</param>
		public SnippetExpression(string value)
		{
			_value = value;
		}

		/// <summary>
		/// Appends the script to represent this object to the StringBuilder.
		/// </summary>
		/// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
		/// <param name="options">The options to use when appending JavaScript</param>
		/// <param name="allowReservedWords"></param>
		protected internal override void AppendScript(StringBuilder builder, ScriptOptions options, bool allowReservedWords)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}

			builder.Append(_value);
		}

		/// <summary>
		/// Gets or sets the Value to append.
		/// </summary>
		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}
	}
}
