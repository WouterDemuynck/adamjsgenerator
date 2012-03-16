using System;
using System.Text;

namespace Adam.JSGenerator
{	
	/// <summary>
	/// An expression that contains a valid identifier.
	/// </summary>
	public class IdentifierExpression : Expression
	{
		private string _name;

		private static void CheckName(string name)
		{
			if (!JS.IsValidIdentifier(name))
			{
				throw new ArgumentException("Not a valid identifier.", "name");
			}
		}

		/// <summary>
		/// Creates a new IdentifierExpression instance that represents the identifier passed in the name argument.
		/// </summary>
		/// <param name="name">The name of the identifier.</param>
		public IdentifierExpression(string name)
		{
			CheckName(name);
			_name = name;
		}

		protected void EnsureNoReservedWords()
		{
			if (JS.IsReserved(Name))
			{
				string message = string.Format("The specified IdentifierExpression has name '{0}' which is a reserved word and cannot be used in this context.", Name);
				throw new InvalidOperationException(message);
			}
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

			if (!allowReservedWords)
			{
				EnsureNoReservedWords();
			}

			builder.Append(_name);
		}

		/// <summary>
		/// Implicitly converts a string into an identifier.
		/// </summary>
		/// <param name="name">The name to convert.</param>
		/// <returns>The IdentifierExpression instance that represents the identifier passed in the name argument.</returns>
		public static implicit operator IdentifierExpression(string name)
		{
			return new IdentifierExpression(name);
		}

		/// <summary>
		/// Implicitly converts a string into an identifier.
		/// </summary>
		/// <param name="name">The name to convert.</param>
		/// <returns>The IdentifierExpression instance that represents the identifier passed in the name argument.</returns>
		public static new IdentifierExpression FromString(string name)
		{
			return new IdentifierExpression(name);
		}

		/// <summary>
		/// Gets or sets the name of the identifier.
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				CheckName(value);
				_name = value;
			}
		}

	}
}
