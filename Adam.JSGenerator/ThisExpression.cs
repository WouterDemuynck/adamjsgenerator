using System;
using System.Text;

namespace Adam.JSGenerator
{
	/// <summary>
	/// Represents the "this" keyword in JavaScript.
	/// </summary>
	public class ThisExpression : Expression
	{
		protected internal override void AppendScript(StringBuilder builder, ScriptOptions options)
		{
			if (builder == null)
			{
				throw new ArgumentException("builder");
			}

			builder.Append("this");
		}
	}
}