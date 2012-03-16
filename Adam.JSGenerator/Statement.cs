using System;
using System.Text;

namespace Adam.JSGenerator
{
	/// <summary>
	/// Provides the base class for all Javascript statements.
	/// </summary>
	public abstract class Statement
	{
		private const string Terminator = ";";

		/// <summary>
		/// Helper method that appends a terminating semicolon to the StringBuilder, if this object requires one.
		/// </summary>
		/// <param name="builder">The StringBuilder to apply a terminating semicolon to.</param>
		public void AppendRequiredTerminator(StringBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}

			if (RequiresTerminator)
			{
				builder.Append(Terminator);
			}
		}

		/// <summary>
		/// Appends the script to represent this object to the StringBuilder.
		/// </summary>
		/// <param name="builder">The StringBuilder to which the Javascript is appended.</param>
		/// <param name="options">The options to use when appending JavaScript</param>
		/// <param name="allowReservedWords">Indicate to the statement/expression that the use of reserved words is allowed.</param>
		internal protected abstract void AppendScript(StringBuilder builder, ScriptOptions options, bool allowReservedWords);

		/// <summary>
		/// Indicates that this object requires a terminating semicolon when used as a statement.
		/// </summary>
		internal protected virtual bool RequiresTerminator
		{
			get
			{
				// A statement usually does not need to be terminated.
				return false;
			}
		}

		/// <summary>
		/// Converts the object to a string containing the JavaScript that it represents.
		/// </summary>
		/// <param name="includeTerminator">If true, a statement terminator is appended if required.</param>
		/// <param name="options">The options to use when generating JavaScript.</param>
		/// <param name="allowReservedWords">Indicate to the statement/expression that the use of reserved words is allowed.</param>
		/// <returns>A string containing the JavaScript that it represents.</returns>
		public string ToString(bool includeTerminator, ScriptOptions options, bool allowReservedWords)
		{
			StringBuilder builder = new StringBuilder();

			if (options.WrapInScriptBlock)
			{
				builder.Append("<script type=\"text/javascript\">");
			}

			AppendScript(builder, options, allowReservedWords);
			
			if (includeTerminator)
			{
				AppendRequiredTerminator(builder);
			}

			if (options.WrapInScriptBlock)
			{
				builder.Append("</script>");
			}
			
			return builder.ToString();
		}

		/// <summary>
		/// Converts the object to a string containing the JavaScript that it represents.
		/// </summary>
		/// <param name="includeTerminator">If true, a statement terminator is appended if required.</param>
		/// <returns>A string containing the JavaScript that it represents.</returns>
		public string ToString(bool includeTerminator)
		{
			return ToString(includeTerminator, new ScriptOptions(), false);
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override string ToString()
		{
			return ToString(true);
		}

		/// <summary>
		/// Returns a value indicating whether this instance is equal to the specified object.
		/// </summary>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			
			if(ReferenceEquals(this, obj))
			{
				return true;
			}

			Statement statement = obj as Statement;

			return obj.GetType().Equals(GetType()) && statement != null && string.Equals(ToString(false, ScriptOptions.Default, true), statement.ToString(false, ScriptOptions.Default, true));
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		public override int GetHashCode()
		{
			return ToString(false, ScriptOptions.Default, true).GetHashCode();
		}
	}
}
