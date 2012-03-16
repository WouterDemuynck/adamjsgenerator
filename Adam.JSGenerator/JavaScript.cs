using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Collections;

namespace Adam.JSGenerator
{
	/// <summary>
	/// Helper class used in generating Javascript snippets from the server.
	/// </summary>
	// ReSharper disable InconsistentNaming
	public static class JS
	// ReSharper restore InconsistentNaming
	{
		/// <summary>
		/// Contains the list of characters allowed for quoting.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
		public static readonly IEnumerable<char> QuoteChars = new [] { '\'', '"' };

		/// <summary>
		/// Contains the list of reserved keywords as defined by Javascript.
		/// </summary>
		private static readonly string[] Reserved = ("break case catch continue debugger default delete do else " + 
			"finally for function if in instanceof return switch this throw try typeof var void while with").Split(' ');
		private static readonly string[] ReservedForFutureUse = ("class enum extends super const export import").Split(' ');
		private static readonly string[] StrictlyReserved = ("implements let private public yield interface package protected public static").Split(' ');

		#region Helper Methods


		/// <summary>
		/// Converts a single <see cref="T:System.Char" /> into a corresponding representation in JavaScript.
		/// </summary>
		/// <param name="character">The character to convert.</param>
		/// <returns>A string representing the character in JavaScript.</returns>
		public static string CharToUnicode(char character)
		{
			return string.Format(CultureInfo.InvariantCulture, @"\u{0:x4}", (int)character);
		}

		/// <summary>
		/// Determines the optimal char to use as a quote char.
		/// </summary>
		/// <param name="source">A sequence of characters to analyze.</param>
		/// <returns>The most optimal char to use as a quote char.</returns>
		/// <remarks>
		/// JavaScript allows both the single quote (') and double quote (") to quote strings.
		/// Therefore, it's better to find the quote char that has been used less than the other, to minimize escaping.        
		/// </remarks>
		public static char FindMostSuitableQuoteChar(IEnumerable<char> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			return QuoteChars.OrderBy(c => source.Count(s => s == c)).First();
		}

		/// <summary>
		/// Uses reflection to create a dictionary of expressions to expressions for each property of the passed object.
		/// </summary>
		/// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
		/// <returns>A dictionary of expressions to expressions representing the values of the properties of the passed object.</returns>
		/// <remarks>
		/// This method uses reflection to retrieve all the properties of an object, so you can use anonymous objects to be converted into
		/// JavaScript object literals. These objects can be nested, as well as contain arrays.
		/// </remarks>     
		public static IDictionary<Expression, Expression> GetValues(object value)
		{
			Dictionary<Expression, Expression> result = new Dictionary<Expression, Expression>(); 
   
			if (value != null)
			{
				foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value))
				{
					string name = property.Name;

					Expression key = IsValidIdentifier(name) ? Id(name) : JSGenerator.Expression.FromObject(name);

					result.Add(key, JSGenerator.Expression.FromObject(property.GetValue(value)));
				}   
			}

			return result;
		}

		/// <summary>
		/// Determines whether the name is a valid identifier.
		/// </summary>
		/// <param name="name">The name to check.</param>
		/// <returns>True if the name is a valid identifier, otherwise false.</returns>
		public static bool IsValidIdentifier(string name)
		{
			const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ$_0123456789";
			const string validStartChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ$_";

			return !string.IsNullOrEmpty(name) &&
				   (validStartChars.IndexOf(name[0]) != -1) &&
				   !name.Except(validChars).Any();
		}

		/// <summary>
		/// Determines whether the specified name is a reserved word.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>
		///   <c>true</c> if the specified name is reserved; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsReserved(string name)
		{
			return 
				Reserved.Any(n => n.Equals(name)) || 
				ReservedForFutureUse.Any(n => n.Equals(name)) || 
				StrictlyReserved.Any(n => n.Equals(name)); // In the future we may be able to introduce a "strict" mode that can be turned off.
		}

		/// <summary>
		/// Quotes the string for use in Javascript.
		/// </summary>
		/// <param name="source">The string to quote.</param>
		/// <returns>The quoted string.</returns>
		/// <remarks>
		///     The most suitable quote character is determined using the FindMostSuitableQuoteChar function.
		/// </remarks>
		public static string QuoteString(IEnumerable<char> source)
		{
			return QuoteString(source, FindMostSuitableQuoteChar(source));
		}

		/// <summary>
		/// Quotes the string for use in Javascript, using the quote character supplied.
		/// </summary>
		/// <param name="source">The string to quote.</param>
		/// <param name="quoteCharacter">The character to use to quote.</param>
		/// <returns>The quoted string.</returns>
		/// <remarks>
		///     All the characters that need to be present in the string are escaped, including the control characters.
		///     The escape character '\' is not escaped itself, for example to preserve regex patterns.
		/// </remarks>
		public static string QuoteString(IEnumerable<char> source, char quoteCharacter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			StringBuilder builder = new StringBuilder();

			builder.Append(quoteCharacter);

			foreach (char c in source)
			{
				switch (c)
				{
					case '\\':
						builder.Append(@"\\");
						break;

					case '\'':
					case '"':
						if (c == quoteCharacter)
						{
							builder.Append('\\');
						}
						builder.Append(c);
						break;

					case '<':
					case '>':
						builder.Append(CharToUnicode(c));
						break;

					case '\b':
						builder.Append(@"\b");
						break;

					case '\t':
						builder.Append(@"\t");
						break;

					case '\n':
						builder.Append(@"\n");
						break;

					case '\f':
						builder.Append(@"\f");
						break;

					case '\r':
						builder.Append(@"\r");
						break;
						
					default:
						if (char.IsControl(c))
						{
							builder.Append(CharToUnicode(c));
						}
						else
						{
							builder.Append(c);
						}                            
						break;
				}
			}

			builder.Append(quoteCharacter);

			return builder.ToString();
		}

		/// <summary>
		/// Returns either an instance of <see cref="CompoundStatement" /> containing the statements, the only statement, or an empty statement depending on the 
		/// number of statements specified.
		/// </summary>
		/// <param name="statements">An array of statements to conditionally wrap in a BlockStatement</param>
		/// <returns>Either an instance of <see cref="CompoundStatement" />, a single statement or an EmptyStatement object.</returns>
		/// <remarks>
		/// The return type of this method depends on the number of inputs. 
		/// If the input is null or empty, an instance of <see cref="EmptyStatement" /> is returned.
		/// If the input has one statement, that statement is returned.
		/// If the input has more than one statement, a new instance of <see cref="CompoundStatement" /> containing those statements is returned.
		/// </remarks>
		public static Statement BlockOrStatement(params Statement[] statements)
		{
			return BlockOrStatement(statements.AsEnumerable());
		}

		/// <summary>
		/// Returns either an instance of <see cref="CompoundStatement" /> containing the statements, the only statement, or an empty statement depending on the 
		/// number of statements specified.
		/// </summary>
		/// <param name="statements">A sequence of statements to conditionally wrap in a BlockStatement</param>
		/// <returns>Either an instance of <see cref="CompoundStatement" />, a single statement or an EmptyStatement object.</returns>
		/// <remarks>
		/// The return type of this method depends on the number of inputs. 
		/// If the input is null or empty, an instance of <see cref="EmptyStatement" /> is returned.
		/// If the input has one statement, that statement is returned.
		/// If the input has more than one statement, a new instance of <see cref="CompoundStatement" /> containing those statements is returned.
		/// </remarks>
		public static Statement BlockOrStatement(IEnumerable<Statement> statements)
		{
			Statement result;

			if (statements.Count() > 1)
			{
				result = new CompoundStatement(statements);
			}
			else if (statements.Count() > 0)
			{
				result = statements.First();
			}
			else
			{
				result = Empty();
			}

			return result;
		}

		/// <summary>
		/// Parses the string for an identifier. Only accepted characters are those valid in identifiers, and the property operator.
		/// </summary>
		/// <param name="name">The string to parse for an identifier</param>
		/// <returns>The parsed identifier as an expression chain.</returns>
		public static Expression ParseId(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}

			string[] identifiers = name.Split('.');
			Expression result = null;

			foreach (string identifier in identifiers)
			{
				if (result == null)
				{
					result = Id(identifier);
				}
				else
				{
					result = new PropertyOperationExpression(result, identifier);
				}
			}

			return result;
		}

		#endregion

		#region Shortcuts to Expressions and Statements

		/// <summary>
		/// Creates a new instance of <see cref="ArrayExpression" /> based on the passed elements.
		/// </summary>
		/// <param name="elements">The elements to add to the array.</param>
		/// <returns>An instance of <see cref="ArrayExpression" /> containing the passed elements.</returns>
		public static ArrayExpression Array(params Expression[] elements)
		{
			return new ArrayExpression(elements);
		}

		/// <summary>
		/// Creates a new instance of <see cref="ArrayExpression" /> based on the passed elements.
		/// </summary>
		/// <param name="elements">An array of expressions to add to the array.</param>
		/// <returns>An instance of <see cref="ArrayExpression" /> containing the passed elements.</returns>
		public static ArrayExpression Array(IEnumerable<Expression> elements)
		{
			return new ArrayExpression(elements);
		}

		/// <summary>
		/// Creates a new instance of <see cref="ArrayExpression" /> based on the passed elements.
		/// </summary>
		/// <param name="elements">A sequence of objects to add to the array.</param>
		/// <returns>An instance of <see cref="ArrayExpression" /> containing the passed elements.</returns>
		/// <remarks>
		/// This overload checks each element's type, and if it inherits from Expression it is passed unchanged into the array.
		/// If it does not, JS.Object is used to create a new ObjectLiteralExpression from it.
		/// </remarks>
		public static ArrayExpression Array(IEnumerable elements)
		{
			return new ArrayExpression(elements.Cast<object>()
				.Select(JSGenerator.Expression.FromObject));
		}

		/// <summary>
		/// Creates a new instance of <see cref="CompoundStatement" /> containing the specified statements.
		/// </summary>
		/// <param name="statements">An array of statements that the block should contain.</param>
		/// <returns>An instance of <see cref="CompoundStatement" /> containing the provided statements.</returns>
		public static CompoundStatement Block(params Statement[] statements)
		{
			return new CompoundStatement(statements);
		}

		/// <summary>
		/// Creates a new instance of <see cref="CompoundStatement" /> containing the specified statements.
		/// </summary>
		/// <param name="statements">A sequence of statements that the block should contain.</param>
		/// <returns>An instance of <see cref="CompoundStatement" /> containing the provided statements.</returns>
		public static CompoundStatement Block(IEnumerable<Statement> statements)
		{
			return new CompoundStatement(statements);
		}

		/// <summary>
		/// Creates a new instance of <see cref="BreakStatement" /> that breaks to the specified label.
		/// </summary>
		/// <param name="label">The label to break to.</param>
		/// <returns>an instance of <see cref="BreakStatement" /> that breaks to the specified label.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public static BreakStatement Break(IdentifierExpression label = null)
		{
			return new BreakStatement(label);
		}

		/// <summary>
		/// Includes the specified content as a comment.
		/// </summary>
		/// <param name="content">The content.</param>
		/// <returns>A new instance of <see cref="CommentStatement" />.</returns>
		/// <remarks>
		/// By default, the content is inserted as a "multi-line comment" ("/* */") unless it contains either "/*", 
		/// "*/" or line breaks, in which case it falls back to "single-line comments", by preceding each line in the 
		/// source with "// ".
		/// </remarks>
		public static CommentStatement Comment(string content)
		{
			return new CommentStatement(content);
		}

		/// <summary>
		/// Creates a new instance of <see cref="ContinueStatement" /> that continues at the specified label.
		/// </summary>
		/// <param name="label">The label to continue at.</param>
		/// <returns>an instance of <see cref="ContinueStatement" /> that continues at the specified label.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public static ContinueStatement Continue(IdentifierExpression label = null)
		{
			return new ContinueStatement(label);
		}

		/// <summary>
		/// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a delete operation on the specified expression.
		/// </summary>
		/// <param name="expression">The expression to perform a delete operation on.</param>
		/// <returns>An instance of <see cref="UnaryOperationExpression" /> that performs a delete operation.</returns>
		public static UnaryOperationExpression Delete(Expression expression)
		{
			return new UnaryOperationExpression(expression, UnaryOperator.Delete);
		}

		/// <summary>
		/// Creates a new instance of <see cref="DoWhileStatement" /> containing the specified statements.
		/// </summary>
		/// <param name="statements">A sequence of statements to include in the body of the do-while loop.</param>
		/// <returns>an instace of <see cref="DoWhileStatement" />.</returns>
		public static DoWhileStatement Do(IEnumerable<Statement> statements)
		{
			return new DoWhileStatement(null, BlockOrStatement(statements));
		}

		/// <summary>
		/// Creates a new instance of <see cref="DoWhileStatement" /> containing the specified statements.
		/// </summary>
		/// <param name="statements">An array of statements to include in the body of the do-while loop.</param>
		/// <returns>an instace of <see cref="DoWhileStatement" />.</returns>
		public static DoWhileStatement Do(params Statement[] statements)
		{
			return new DoWhileStatement(null, BlockOrStatement(statements));
		}

		/// <summary>
		/// Creates a new instance of <see cref="EmptyStatement" />.
		/// </summary>
		/// <returns>an instance of <see cref="EmptyStatement" />.</returns>
		public static EmptyStatement Empty()
		{
			return new EmptyStatement();
		}

		/// <summary>
		/// Creates a new instance of <see cref="CallOperationExpression" /> that performs a call to the Microsoft AJAX global '$find' function.
		/// </summary>
		/// <param name="expression">The expression to use as the first argument to the call to $find.</param>
		/// <returns>an instance of <see cref="CallOperationExpression" /> for the function call.</returns>
		public static CallOperationExpression Find(Expression expression)
		{
			return new CallOperationExpression(Id("$find"), expression);
		}

		///<summary>
		/// Creates a new instance of <see cref="IteratorStatement" /> that is incomplete. You'll need to use the helper method <see cref="IteratorStatementHelpers.In" /> to combine it with a collection to iterator though.
		///</summary>
		///<param name="variable">The expression to use as the variable to loop with.</param>
		///<returns>An instance of <see cref="IteratorStatement" />.</returns>
		public static IteratorStatement For(Expression variable)
		{
			return new IteratorStatement(variable, null, Empty());
		}

		/// <summary>
		/// Creates a new instance of <see cref="LoopStatement" /> that represents a JavaScript for-loop with a loop initializer, a loop condition and loop iteration expression.
		/// </summary>
		/// <param name="initialization">The expression to use as the loop initialization.</param>
		/// <param name="condition">The expression to use as the loop condition.</param>
		/// <param name="iteration">The expression to use as the loop iterator.</param>
		/// <returns>a new instance of <see cref="LoopStatement" />.</returns>
		/// <remarks>
		/// Any of the parameters may be null to indicate that this part is not present in the loop.
		/// </remarks>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public static LoopStatement For(Expression initialization = null, Expression condition = null, Expression iteration = null)
		{
			return new LoopStatement(initialization, condition, iteration, Empty());
		}

		/// <summary>
		/// Creates a new instance of <see cref="FunctionExpression" /> that represents a named function.
		/// </summary>
		/// <param name="name">The name of the function.</param>
		/// <returns>a new instance of <see cref="FunctionExpression" />.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public static FunctionExpression Function(IdentifierExpression name = null)
		{
			return new FunctionExpression(name);
		}

		/// <summary>
		/// Creates a new instance of <see cref="CallOperationExpression" /> that represents a call to the Microsoft AJAX global '$get' function.
		/// </summary>
		/// <param name="expression">The expression to use an argument to the call.</param>
		/// <returns>a new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Get(Expression expression)
		{
			return new CallOperationExpression(Id("$get"), expression);
		}

		/// <summary>
		/// Creates a new instance of <see cref="UnaryOperationExpression" /> that surrounds the specified expression with parens.
		/// </summary>
		/// <param name="expression">The expression to surround by parens.</param>
		/// <returns>a new instance of <see cref="UnaryOperationExpression" />.</returns>
		public static UnaryOperationExpression Group(Expression expression)
		{
			return new UnaryOperationExpression(expression, UnaryOperator.Group);
		}

		/// <summary>
		/// Creates a new instance of <see cref="IdentifierExpression" /> representing the specified identifier.
		/// </summary>
		/// <param name="name">The identifier that this instance must represent.</param>
		/// <returns>a new instance of <see cref="IdentifierExpression" />.</returns>
		public static IdentifierExpression Id(string name)
		{
			// Uses implicit conversion from the IdentifierExpression class.
			return name;
		}

		/// <summary>
		/// Creates a new instance of <see cref="ConditionalStatement" /> for the specified condition.
		/// </summary>
		/// <param name="condition">The expression that specifies the condition.</param>
		/// <returns>a new instance of <see cref="ConditionalStatement" />.</returns>
		public static ConditionalStatement If(Expression condition)
		{
			return new ConditionalStatement(condition, null, null);
		}

		///<summary>
		/// Creates a new instance of <see cref="CallOperationExpression" /> that performs a call to the jQuery function with the specified arguments.
		///</summary>
		///<param name="arguments">The arguments to pass to the jQuery function.</param>
		///<returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression JQuery(params Expression[] arguments)
		{
			return new CallOperationExpression(JSGenerator.JQ.JQueryFunction, arguments);
		}

		/// <summary>
		/// Returns a new instance of <see cref="LabelStatement" />.
		/// </summary>
		/// <param name="name">The name of the label.</param>
		/// <param name="statement">The statement this label precedes.</param>
		/// <returns>a new instance of <see cref="LabelStatement" />.</returns>        
		public static LabelStatement Label(IdentifierExpression name, Statement statement)
		{
			return new LabelStatement(name, statement);
		}

		/// <summary>
		/// Creates a new instance of <see cref="NumberExpression" /> that represents the passed value.
		/// </summary>
		/// <param name="value">The value that must be represented by the instance.</param>
		/// <returns>a new instance of <see cref="NumberExpression" />.</returns>
		public static NumberExpression Number(double value)
		{
			return new NumberExpression(value);
		}

		/// <summary>
		/// Creates a new instance of <see cref="StringExpression" /> that represents the passed value.
		/// </summary>
		/// <param name="value">The value that must be represented by the instance.</param>
		/// <returns>a new instance of <see cref="StringExpression" />.</returns>
		public static StringExpression String(string value)
		{
			return new StringExpression(value);
		}

		/// <summary>
		/// Creates a new instance of <see cref="BooleanExpression" /> that represents the passed value.
		/// </summary>
		/// <param name="value">The value that must be represented by the instance.</param>
		/// <returns>a new instance of <see cref="BooleanExpression" />.</returns>
		public static BooleanExpression Boolean(bool value)
		{
			return new BooleanExpression(value);
		}

		/// <summary>
		/// Returns a new expression that combines one or more expressions using the multiple evaluation operator.
		/// </summary>
		/// <param name="expressions">The expressions to combine.</param>
		/// <returns>
		/// Null if no expressions are passed.
		/// The expression if only one expression is returned from the enumerable. 
		/// A new instance of <see cref="BinaryOperationExpression" /> that combines the expressions using the multiple evaluation operator.</returns>
		/// <remarks>
		/// If the enumeration is null, or if it returns no expressions, null is returned.
		/// If the enumeration returns one expression, that expression is returned.
		/// Otherwise, all the expressions are combined using multiple evaluation operators.
		/// </remarks>
		public static Expression Multiple(IEnumerable<Expression> expressions)
		{            
			Expression result = null;

			if (expressions != null)
			{
				foreach (Expression expression in expressions)
				{
					result = result != null 
						? new BinaryOperationExpression(result, expression, BinaryOperator.MultipleEvaluation) 
						: expression;
				}
			}

			return result;
		}

		/// <summary>
		/// Returns a new expression that combines one or more expressions using the multiple evaluation operator.
		/// </summary>
		/// <param name="expressions">The expressions to combine.</param>
		/// <returns>A new expression that combines the expressions.</returns>
		/// <remarks>
		/// This method returns either null, if no expressions are passed, or the single expression if only one expression is passed,
		/// or a chain of BinaryOperatorExpressions to combine all the passed expressions.
		/// </remarks>
		public static Expression Multiple(params Expression[] expressions)
		{
			return Multiple(expressions.AsEnumerable());
		}

		/// <summary>
		/// Creates a new instance of <see cref="UnaryOperationExpression" /> that represents the creation of a new object, using the specified arguments.
		/// </summary>
		/// <param name="expression">An expression that returns a constructor.</param>
		/// <param name="arguments">An array of arguments to pass to the constructor.</param>
		/// <returns>a new instance of <see cref="UnaryOperationExpression" />.</returns>
		public static UnaryOperationExpression New(Expression expression, params Expression[] arguments)
		{
			return new UnaryOperationExpression(new CallOperationExpression(expression, arguments), UnaryOperator.New);
		}

		/// <summary>
		/// Creates a new instance of <see cref="UnaryOperationExpression" /> that represents the creation of a new object, using the specified arguments.
		/// </summary>
		/// <param name="expression">An expression that returns a constructor.</param>
		/// <param name="arguments">A sequence of arguments to pass to the constructor.</param>
		/// <returns>a new instance of <see cref="UnaryOperationExpression" />.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public static UnaryOperationExpression New(Expression expression, IEnumerable<Expression> arguments = null)
		{
			return new UnaryOperationExpression(new CallOperationExpression(expression, arguments), UnaryOperator.New);
		}

		/// <summary>
		/// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a logical not operator (!) on an expression.
		/// </summary>
		/// <param name="expression">The expression to perform the logical not operator on.</param>
		/// <returns>A new instance of <see cref="UnaryOperationExpression" /></returns>
		public static Expression Not(Expression expression)
		{
			return new UnaryOperationExpression(expression, UnaryOperator.LogicalNot);
		}

		/// <summary>
		/// Creates a new instance of <see cref="NullExpression" />.
		/// </summary>
		/// <returns>A new instance of <see cref="NullExpression" />.</returns>
		public static Expression Null()
		{
			return new NullExpression();
		}

		/// <summary>
		/// Creates a new instance of <see cref="ThisExpression" />.
		/// </summary>
		/// <returns>
		/// A new instance of <see cref="ThisExpression" />.
		/// </returns>
		public static Expression This()
		{
			return new ThisExpression();
		}

		/// <summary>
		/// Creates a new instance of <see cref="ObjectLiteralExpression" /> representing an empty object literal.
		/// </summary>
		/// <returns>A new instance of <see cref="ObjectLiteralExpression" /></returns>
		public static ObjectLiteralExpression Object()
		{
			return new ObjectLiteralExpression();
		}

		/// <summary>
		/// Creates a new instance of <see cref="ObjectLiteralExpression" />.
		/// </summary>
		/// <param name="properties">A dictionary that contains the properties to apply to the object literal.</param>
		/// <returns>A new instance of <see cref="ObjectLiteralExpression" />.</returns>
		public static ObjectLiteralExpression Object(IDictionary<Expression, Expression> properties)
		{
			return new ObjectLiteralExpression(properties);
		}

		/// <summary>
		/// Creates a new instance of <see cref="ObjectLiteralExpression" />.
		/// </summary>
		/// <param name="value">The object whose properties will be represented by the object literal.</param>
		/// <returns>A new instance of <see cref="ObjectLiteralExpression" />.</returns>
		/// <remarks>
		/// This method calls <see cref="GetValues" /> to retrieve all the properties of the specified object.
		/// </remarks>
		public static ObjectLiteralExpression Object(object value)
		{
			return new ObjectLiteralExpression(GetValues(value));
		}

		/// <summary>
		/// Creates a new instance of <see cref="RegularExpression" /> representing a regular expression literal.
		/// </summary>
		/// <param name="expression">A string containing the regular expression.</param>
		/// <returns>a new instance of <see cref="RegularExpression" />.</returns>
		public static RegularExpression Regex(string expression)
		{
			return new RegularExpression(expression);
		}

		/// <summary>
		/// Creates a new instance of <see cref="ReturnStatement" /> that returns the specified value.
		/// </summary>
		/// <param name="value">An expression that represents the value to return.</param>
		/// <returns>a new instance of <see cref="ReturnStatement" />.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public static ReturnStatement Return(Expression value = null)
		{
			return new ReturnStatement(value);
		}

		/// <summary>
		/// Creates a new instance of <see cref="T:Adam.JSGenerator.Script" /> that contains the specified statements.
		/// </summary>
		/// <param name="statements">An array of statements that must be contained.</param>
		/// <returns>a new instance of <see cref="T:Adam.JSGenerator.Script" />.</returns>
		public static Script Script(params Statement[] statements)
		{
			return new Script(statements);
		}

		/// <summary>
		/// Creates a new instance of <see cref="T:Adam.JSGenerator.Script" /> that contains the specified statements.
		/// </summary>
		/// <param name="statements">A sequence of statements that must be contained.</param>
		/// <returns>a new instance of <see cref="T:Adam.JSGenerator.Script" />.</returns>
		public static Script Script(IEnumerable<Statement> statements)
		{
			return new Script(statements);
		}

		/// <summary>
		/// Creates a new instance of <sse cref="SnippetExpression" /> that represents the specified content.
		/// </summary>
		/// <param name="content">The content to be produced by the snippet.</param>
		/// <returns>a new instance of <sse cref="SnippetExpression" /></returns>
		/// <remarks>
		/// The content that this instance contains is added as is, without conversion, encoding or quoting.
		/// 
		/// This method is obsolete, please use the equivalent new method <see cref="Expression" /> instead.
		/// </remarks>		
		[Obsolete("This method has become obsolete. Please consider using JS.Expression().")]
		public static SnippetExpression Snippet(string content)
		{
			return new SnippetExpression(content);
		}

		/// <summary>
		/// Creates a new instance of <sse cref="SnippetExpression" /> that represents the specified content.
		/// </summary>
		/// <param name="content">The content to be produced by the snippet.</param>
		/// <returns>a new instance of <sse cref="SnippetExpression" /></returns>
		/// <remarks>
		/// The content that this instance contains is added as is, without conversion, encoding or quoting.
		/// </remarks>
		public static SnippetExpression Expression(string content)
		{
			return new SnippetExpression(content);
		}

		/// <summary>
		/// Creates a new instance of <sse cref="SnippetStatement" /> that represents the specified content.
		/// </summary>
		/// <param name="content">The content to be produced by the snippet.</param>
		/// <returns>a new instance of <sse cref="SnippetStatement" /></returns>
		/// <remarks>
		/// The content that this instance contains is added as is, without conversion, encoding or quoting.
		/// </remarks>
		public static SnippetStatement Statement(string content)
		{
			return new SnippetStatement(content);
		}


		/// <summary>
		/// Creates a new instance of <see cref="SwitchStatement" /> that switches on the provided expression.
		/// </summary>
		/// <param name="expression">An expression to switch on.</param>
		/// <returns>a new instance of <see cref="SwitchStatement" />.</returns>
		public static SwitchStatement Switch(Expression expression)
		{
			return new SwitchStatement(expression);
		}

		/// <summary>
		/// Creates a new instance of <see cref="ThrowStatement" /> that throws the specified expression as an exception.
		/// </summary>
		/// <param name="expression">The expression to throw.</param>
		/// <returns>a new instance of <see cref="ThrowStatement" />.</returns>
		public static ThrowStatement Throw(Expression expression)
		{
			return new ThrowStatement(expression);
		}

		/// <summary>
		/// Creates a new instance of <see cref="ExceptionHandlingStatement" /> that contains the specified statements in its try block.
		/// </summary>
		/// <param name="statements">An array of statements to place in the try block.</param>
		/// <returns>a new instance of <see cref="ExceptionHandlingStatement" />.</returns>
		public static ExceptionHandlingStatement Try(params Statement[] statements)
		{
			return Try(new CompoundStatement(statements));
		}

		/// <summary>
		/// Creates a new instance of <see cref="ExceptionHandlingStatement" /> that contains the specified statements in its try block.
		/// </summary>
		/// <param name="statements">A sequence of statements to place in the try block.</param>
		/// <returns>a new instance of <see cref="ExceptionHandlingStatement" />.</returns>
		public static ExceptionHandlingStatement Try(IEnumerable<Statement> statements)
		{
			return Try(new CompoundStatement(statements));
		}

		/// <summary>
		/// Creates a new instance of <see cref="ExceptionHandlingStatement" />.
		/// </summary>
		/// <param name="block">The instance of <see cref="CompoundStatement" /> to use for the try block.</param>
		/// <returns>a new instance of <see cref="ExceptionHandlingStatement" />.</returns>
		public static ExceptionHandlingStatement Try(CompoundStatement block)
		{
			return new ExceptionHandlingStatement(block, null, null, null);
		}

		/// <summary>
		/// Creates a new instance of <see cref="DeclarationExpression" /> that declares the specified expressions.
		/// </summary>
		/// <param name="expressions">An array of expressions that contain the variables to declare.</param>
		/// <returns>a new instance of <see cref="DeclarationExpression" />.</returns>
		public static DeclarationExpression Var(params Expression[] expressions)
		{
			return new DeclarationExpression(expressions);
		}

		/// <summary>
		/// Creates a new instance of <see cref="DeclarationExpression" /> that declares the specified expressions.
		/// </summary>
		/// <param name="expressions">A sequence of expressions that contain the variables to declare.</param>
		/// <returns>a new instance of <see cref="DeclarationExpression" />.</returns>
		public static DeclarationExpression Var(IEnumerable<Expression> expressions)
		{
			return new DeclarationExpression(expressions);
		}

		/// <summary>
		/// Creates a new instance of <see cref="WhileStatement" /> that will loop while the specified condition returns true.
		/// </summary>
		/// <param name="condition">An expression that the loop will test for.</param>
		/// <returns>a new instance of <see cref="WhileStatement" />.</returns>
		public static WhileStatement While(Expression condition)
		{
			return new WhileStatement(condition, Empty());
		}

		/// <summary>
		/// Creates a new instance of <see cref="WithStatement" />.
		/// </summary>
		/// <param name="expression">The expression that will be in the global scope.</param>
		/// <returns>a new instance of <see cref="WithStatement" />.</returns>
		public static WithStatement With(Expression expression)
		{
			return new WithStatement(expression, null);
		}

		#endregion

		/// <summary>
		/// Returns an instance of <see cref="CallOperationExpression" /> containing a call to the alert() function with the specified message.
		/// </summary>
		public static CallOperationExpression Alert(Expression message)
		{
			return new CallOperationExpression(Id("alert"), message);
		}

		/// <summary>
		/// Returns an instance of <see cref="CallOperationExpression" /> containing a call to the confirm() function with the specified message.
		/// </summary>
		public static CallOperationExpression Confirm(Expression message)
		{
			return new CallOperationExpression(Id("confirm"), message);
		}

		/// <summary>
		/// Returns an instance of <see cref="CallOperationExpression" /> containing a call to the prompt() function with the specified message.
		/// </summary>
		public static CallOperationExpression Prompt(Expression message)
		{
			return new CallOperationExpression(Id("prompt"), message);
		}

		/// <summary>
		/// Returns an instance of <see cref="CallOperationExpression" /> containing a call to the eval() function with the specified expression.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Eval", 
			Justification = "eval is the name of the JavaScript function.")]
		public static CallOperationExpression Eval(Expression expression)
		{
			return new CallOperationExpression(Id("eval"), expression);
		}

		private static IEnumerable<Type> GetTypesKeyValuePairEnumerableInterfaces(Type type)
		{
			return type.GetInterfaces().Where(
				interfaceType => interfaceType.IsGenericType && 
				interfaceType.GetGenericTypeDefinition() == typeof (IEnumerable<>) &&
				interfaceType.GetGenericArguments().Any(
					argumentType => argumentType.IsGenericType && 
					argumentType.GetGenericTypeDefinition() == typeof(KeyValuePair<,>)));
		}

		private static Type GetObjectsFirstIEnumerableKeyValuePairInterface(object obj)
		{
			return GetTypesKeyValuePairEnumerableInterfaces(obj.GetType())
				.Select(type => type.GetGenericArguments().First())
				.FirstOrDefault();
		}

		/// <summary>
		/// Uses reflection to find out if the specified sequence implements any <see cref="IEnumerable{KeyValuePair}" /> 
		/// and returns an <see cref="ObjectLiteralExpression" /> in that case, or an <see cref="ArrayExpression" /> if not.
		/// </summary>
		/// <param name="enumerable">The sequence to convert.</param>
		/// <returns>Either an instance of <see cref="ObjectLiteralExpression" /> or <see cref="ArrayExpression" />.</returns>
		public static Expression ArrayOrObject(IEnumerable enumerable)
		{
			Type keyValuePairEnumerableType = GetObjectsFirstIEnumerableKeyValuePairInterface(enumerable);

			if (keyValuePairEnumerableType == null)
			{
				return Array(enumerable);
			}
			
			var keyProperty = keyValuePairEnumerableType.GetProperty("Key");
			var valueProperty = keyValuePairEnumerableType.GetProperty("Value");

			return ObjectLiteralExpression.FromDictionary<object, object>(enumerable.Cast<object>().ToDictionary(
				pair => keyProperty.GetValue(pair, null),
				pair => valueProperty.GetValue(pair, null)));
		}
	}
}
