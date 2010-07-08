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
        public static readonly char[] QuoteChars = new[] { '\'', '"' };

        /// <summary>
        /// Contains the list of reserved keywords as defined by Javascript.
        /// </summary>
        private static readonly string[] Reserved = ("abstract as boolean break byte case catch char class continue " +
            "const debugger default delete do double else enum export extends false final finally float for " +
            "function goto if implements import in instanceof int interface is long namespace native new null " +
            "package private protected public return short static super switch synchronized this throw throws " +
            "transient true try typeof use var void volatile while with").Split(' ');


        #region Helper Methods

        /// <summary>
        /// Returns an expression for the object presented.
        /// </summary>
        /// <param name="o">The object to turn into an expression</param>
        /// <returns>an instance deriving from <see cref="Expression" />.</returns>
        /// <remarks>
        /// If <see cref="o" /> is null, an instance of <see cref="NullExpression" /> is returned.
        /// If <see cref="o" /> is a string, an instance of <see cref="StringExpression" /> is returned representing the string.
        /// If <see cref="o" /> is an instance of a class derived from <see cref="Expression" />, it is returned unchanged.
        /// If <see cref="o" /> is an instance of a class that implements <see cref="T:System.Collections.IEnumerable" />, <see cref="JS.Array" /> is called to return an instance of <see cref="ArrayExpression" />.
        /// If <see cref="o" /> is a reference type, <see cref="JS.Object" /> is called to return an instance of <see cref="ObjectLiteralExpression" />.
        /// If <see cref="o" /> is a boolean, an instance of <see cref="BooleanExpression" /> is returned.
        /// If <see cref="o" /> can be converted into a double, an instance of <see cref="NumberExpression" /> is returned.
        /// In all other cases, <see cref="M:System.Object.ToString" /> is called, and the result is wrapped in an instance of <see cref="LiteralExpression" /> and returned.
        /// </remarks>
        private static Expression ObjectToExpression(object o)
        {
            string s = o as string;
            Expression expr;
            double d;

            if (o == null)
            {
                expr = Null();
            }
            else if (s != null)
            {
                expr = s;
            }
            else if (o is Expression)
            {
                expr = (Expression)o;
            }
            else if (o is IEnumerable)
            {
                expr = Array((IEnumerable)o);
            }
            else if (o.GetType().IsClass)
            {
                expr = Object(o);
            }
            else if (o is Boolean)
            {
                return new BooleanExpression((Boolean) o);
            }
            else if (double.TryParse(o.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out d))
            {
                return new NumberExpression(d);
            }
            else
            {
                expr = o.ToString();
            }

            return expr;
        }

        /// <summary>
        /// Converts a single <see cref="T:System.Char" /> into a corresponding representation in JavaScript.
        /// </summary>
        /// <param name="c">The character to convert.</param>
        /// <returns>A string representing the character in JavaScript.</returns>
        public static string CharToUnicode(char c)
        {
            return string.Format(@"\u{0:x4}", (int)c);
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
        /// <param name="o">The <see cref="T:System.Object" /> to convert.</param>
        /// <returns>A dictionary of expressions to expressions representing the values of the properties of the passed object.</returns>
        /// <remarks>
        /// This method uses reflection to retrieve all the properties of an object, so you can use anonymous objects to be converted into
        /// JavaScript object literals. These objects can be nested, as well as contain arrays.
        /// </remarks>     
        public static IDictionary<Expression, Expression> GetValues(object o)
        {
            Dictionary<Expression, Expression> result = new Dictionary<Expression, Expression>(); 
   
            if (o != null)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(o))
                {
                    string name = property.Name;

                    Expression key = IsValidIdentifier(name) ? (Expression)Id(name) : (Expression)name;

                    result.Add(key, ObjectToExpression(property.GetValue(o)));
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
                   !name.Except(validChars).Any() &&
                   !Reserved.Any(n => n.Equals(name));
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
        /// <param name="quoteChar">The quote character to use.</param>
        /// <returns>The quoted string.</returns>
        /// <remarks>
        ///     All the characters that need to be present in the string are escaped, including the control characters.
        ///     The escape character '\' is not escaped itself, for example to preserve regex patterns.
        /// </remarks>
        public static string QuoteString(IEnumerable<char> source, char quoteChar)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            StringBuilder builder = new StringBuilder();

            builder.Append(quoteChar);

            foreach (char c in source)
            {
                switch (c)
                {
                    case '\\':
                        builder.Append(@"\\");
                        break;

                    case '\'':
                    case '"':
                        if (c == quoteChar)
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

            builder.Append(quoteChar);

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
                .Select(element => ObjectToExpression(element)));
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
        /// Creates a new instance of <see cref="BreakStatement" />.
        /// </summary>
        /// <returns>an instance of <see cref="BreakStatement" />.</returns>
        public static BreakStatement Break()
        {
            return Break(null);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BreakStatement" /> that breaks to the specified label.
        /// </summary>
        /// <param name="label">The label to break to.</param>
        /// <returns>an instance of <see cref="BreakStatement" /> that breaks to the specified label.</returns>
        public static BreakStatement Break(IdentifierExpression label)
        {
            return new BreakStatement(label);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContinueStatement" />.
        /// </summary>
        /// <returns>an instance of <see cref="ContinueStatement" />.</returns>
        public static ContinueStatement Continue()
        {
            return Continue(null);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContinueStatement" /> that continues at the specified label.
        /// </summary>
        /// <param name="label">The label to continue at.</param>
        /// <returns>an instance of <see cref="ContinueStatement" /> that continues at the specified label.</returns>
        public static ContinueStatement Continue(IdentifierExpression label)
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

        /// <summary>
        /// Creates a new instance of <see cref="LoopStatement" /> that represents an eternal loop.
        /// </summary>
        /// <returns>an instance of <see cref="LoopStatement" /> that represents an eternal loop.</returns>
        /// <remarks>
        /// The result represents the following snippet of JavaScript:
        /// <code>
        /// for (;;) ;
        /// </code>
        /// This is also known as "an eternal loop". Unless the body contains a break statement, the loop will continue forever.
        /// </remarks>
        public static LoopStatement For()
        {
            return For(null, null, null);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LoopStatement" /> that represents a JavaScript for-loop with only an iteration expression.
        /// </summary>
        /// <param name="iteration">The expression to use as the loop iterator.</param>
        /// <returns>an instance of <see cref="LoopStatement" />.</returns>
        /// <remarks>
        /// The loop iterator expression may be null to indicate that this part is not present in the loop.
        /// </remarks>
        public static LoopStatement For(Expression iteration)
        {
            return For(null, null, iteration);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LoopStatement" /> that represents a JavaScript for-loop with a loop condition and loop iteration expression.
        /// </summary>
        /// <param name="condition">The expression to use as the loop condition.</param>
        /// <param name="iteration">The expression to use as the loop iterator.</param>
        /// <returns>a new instance of <see cref="LoopStatement" />.</returns>
        /// <remarks>
        /// Any of the parameters may be null to indicate that this part is not present in the loop.
        /// </remarks>
        public static LoopStatement For(Expression condition, Expression iteration)
        {
            return For(null, condition, iteration);
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
        public static LoopStatement For(Expression initialization, Expression condition, Expression iteration)
        {
            return new LoopStatement(initialization, condition, iteration, Empty());
        }

        /// <summary>
        /// Creates a new instance of <see cref="FunctionExpression" /> that represents an anonymous function.
        /// </summary>
        /// <returns>a new instance of <see cref="FunctionExpression" />.</returns>
        public static FunctionExpression Function()
        {
            return new FunctionExpression(null, null, null);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FunctionExpression" /> that represents a named function.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <returns>a new instance of <see cref="FunctionExpression" />.</returns>
        public static FunctionExpression Function(IdentifierExpression name)
        {
            return new FunctionExpression(name, null, null);
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
        /// Hypoglycemic a new instance of <see cref="ConditionalStatement" /> for the specified condition.
        /// </summary>
        /// <param name="condition">The expression that specifies the condition.</param>
        /// <returns>a new instance of <see cref="ConditionalStatement" />.</returns>
        public static ConditionalStatement If(Expression condition)
        {
            return new ConditionalStatement(condition, null, null);
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
        /// Returns a new instance of <see cref="NumberExpression" /> that represents the passed value.
        /// </summary>
        /// <param name="value">The value that must be represented by the instance.</param>
        /// <returns>a new instance of <see cref="NumberExpression" />.</returns>
        public static NumberExpression Number(int value)
        {
            return new NumberExpression(value);
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
                    if (result == null)
                    {
                        result = expression;
                    }
                    else
                    {
                        result = new BinaryOperationExpression(result, expression, BinaryOperator.MultipleEvaluation);
                    }
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
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that represents the creation of a new object.
        /// </summary>
        /// <param name="expression">An expression that returns a constructor.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" />.</returns>
        public static UnaryOperationExpression New(Expression expression)
        {
            return new UnaryOperationExpression(new CallOperationExpression(expression), UnaryOperator.New);
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
        public static UnaryOperationExpression New(Expression expression, IEnumerable<Expression> arguments)
        {
            return new UnaryOperationExpression(new CallOperationExpression(expression, arguments), UnaryOperator.New);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnaryOperationExpression" /> that performs a logical not operator (!) on an expression.
        /// </summary>
        /// <param name="expression">The expression to perform the logical not operator on.</param>
        /// <returns>a new instance of <see cref="UnaryOperationExpression" /></returns>
        public static Expression Not(Expression expression)
        {
            return new UnaryOperationExpression(expression, UnaryOperator.LogicalNot);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NullExpression" />.
        /// </summary>
        /// <returns>a new instance of <see cref="NullExpression" />.</returns>
        public static Expression Null()
        {
            return new NullExpression();
        }

        /// <summary>
        /// Creates a new instance of <see cref="ObjectLiteralExpression" /> representing an empty object literal.
        /// </summary>
        /// <returns>a new instance of <see cref="ObjectLiteralExpression" /></returns>
        public static ObjectLiteralExpression Object()
        {
            return new ObjectLiteralExpression();
        }

        /// <summary>
        /// Creates a new instance of <see cref="ObjectLiteralExpression" />.
        /// </summary>
        /// <param name="properties">A dictionary that contains the properties to apply to the object literal.</param>
        /// <returns>a new instance of <see cref="ObjectLiteralExpression" />.</returns>
        public static ObjectLiteralExpression Object(IDictionary<Expression, Expression> properties)
        {
            return new ObjectLiteralExpression(properties);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ObjectLiteralExpression" />.
        /// </summary>
        /// <param name="o">The object whose properties will be represented by the object literal.</param>
        /// <returns>a new instance of <see cref="ObjectLiteralExpression" />.</returns>
        /// <remarks>
        /// This method calls <see cref="GetValues" /> to retrieve all the properties of the specified object.
        /// </remarks>
        public static ObjectLiteralExpression Object(object o)
        {
            return new ObjectLiteralExpression(GetValues(o));
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
        /// Creates a new instance of <see cref="ReturnStatement" /> that represents a return statement without a return value.
        /// </summary>
        /// <returns>a new instance of <see cref="ReturnStatement" /> without return value.</returns>
        public static ReturnStatement Return()
        {
            return new ReturnStatement();
        }

        /// <summary>
        /// Creates a new instance of <see cref="ReturnStatement" /> that returns the specified value.
        /// </summary>
        /// <param name="value">An expression that represents the value to return.</param>
        /// <returns>a new instance of <see cref="ReturnStatement" />.</returns>
        public static ReturnStatement Return(Expression value)
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
        /// Creates a new instance of <sse cref="SnippetExpression" /> that represents the specified content..
        /// </summary>
        /// <param name="content">The content to be produced by the snippet.</param>
        /// <returns>a new instance of <sse cref="SnippetExpression" /></returns>
        /// <remarks>
        /// The content that this instance contains is added as is, without conversion, encoding or quoting.
        /// </remarks>
        public static SnippetExpression Snippet(string content)
        {
            return new SnippetExpression(content);
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

        public static CallOperationExpression Alert(Expression a)
        {
            return new CallOperationExpression(Id("alert"), a);
        }
    }
}
