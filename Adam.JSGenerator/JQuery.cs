using System.Collections.Generic;

namespace Adam.JSGenerator
{
	///<summary>
	/// Serves as an example for writing extension methods.
	///</summary>
	public static class JQuery
	{
		/// <summary>
		/// The name of the jQuery function to use. To be safe, leave this at 'jQuery', but if you want to use the shorthand you can set this to '$'.
		/// </summary>
		public static IdentifierExpression JQ = new IdentifierExpression("jQuery");

		/// <summary>
		/// Add elements to the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to add to.</param>
		/// <param name="arguments">The arguments to pass to the function.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Add(Expression expression, params Expression[] arguments)
		{
			return new CallOperationExpression(expression.Dot("add"), arguments);
		}

		/// <summary>
		/// Add elements to the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to add to.</param>
		/// <param name="arguments">The arguments to pass to the function.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Add(Expression expression, IEnumerable<Expression> arguments)
		{
			return new CallOperationExpression(expression.Dot("add"), arguments);
		}

		/// <summary>
		/// Adds the specified class(es) to each of the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="argument">The argument to pass to the function.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AddClass(this Expression expression, Expression argument)
		{
			return new CallOperationExpression(expression.Dot("addClass"), argument);
		}

		/// <summary>
		///  Insert content, specified by the parameter, after each element in the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="argument">The argument to pass to the function.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression After(this Expression expression, Expression argument)
		{
			return new CallOperationExpression(expression.Dot("after"), argument);
		}

		/// <summary>
		/// Perform an asynchronous HTTP (Ajax) request.
		/// </summary>
		/// <param name="url">A string containing the URL to which the request is sent.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Ajax(string url)
		{
			return Ajax(JS.String(url));
		}

		/// <summary>
		/// Perform an asynchronous HTTP (Ajax) request.
		/// </summary>
		/// <param name="url">A string containing the URL to which the request is sent.</param>
		/// <param name="settings">A set of key/value pairs that configure the Ajax request. All settings are optional. A default can be set for any option with $.ajaxSetup(). See jQuery.ajax( settings ) below for a complete list of all settings.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Ajax(string url, object settings)
		{
			return Ajax(JS.String(url), Expression.FromObject(settings));
		}

		/// <summary>
		/// Perform an asynchronous HTTP (Ajax) request.
		/// </summary>
		/// <param name="settings">A set of key/value pairs that configure the Ajax request. All settings are optional. A default can be set for any option with $.ajaxSetup(). See jQuery.ajax( settings ) below for a complete list of all settings.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Ajax(object settings)
		{
			return Ajax(Expression.FromObject(settings));
		}

		/// <summary>
		/// Perform an asynchronous HTTP (Ajax) request.
		/// </summary>
		/// <param name="settings">A set of key/value pairs that configure the Ajax request. All settings are optional. A default can be set for any option with $.ajaxSetup(). See jQuery.ajax( settings ) below for a complete list of all settings.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Ajax(Expression settings)
		{
			return JQ.Dot("ajax").Call(settings);
		}

		/// <summary>
		/// Perform an asynchronous HTTP (Ajax) request.
		/// </summary>
		/// <param name="url">A string containing the URL to which the request is sent.</param>
		/// <param name="settings">A set of key/value pairs that configure the Ajax request. All settings are optional. A default can be set for any option with $.ajaxSetup(). See jQuery.ajax( settings ) below for a complete list of all settings.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Ajax(Expression url, Expression settings)
		{
			return JQ.Dot("ajax").Call(url, settings);
		}

		/// <summary>
		/// Register a handler to be called when Ajax requests complete. This is an Ajax Event.
		/// </summary>
		/// <param name="expression">The jQuery set to apply this call.</param>
		/// <param name="handler">The function to be invoked.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxComplete(this Expression expression, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("ajaxComplete"), handler);
		}

		/// <summary>
		/// Register a handler to be called when Ajax requests complete with an error. This is an Ajax Event.
		/// </summary>
		/// <param name="expression">The jQuery set to apply this call.</param>
		/// <param name="handler">The function to be invoked.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxError(this Expression expression, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("ajaxError"), handler);
		}
		
		/// <summary>
		/// Insert content, specified by the parameter, to the end of each element in the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="argument">The argument to pass to the function.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Append(this Expression expression, Expression argument)
		{
			return new CallOperationExpression(expression.Dot("append"), argument);
		}

		/// <summary>
		/// Store arbitrary data associated with the matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="key">The key argument to pass to the function.</param>
		/// <param name="value">The value argument to pass to the function.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Data(this Expression expression, Expression key, Expression value)
		{
			return new CallOperationExpression(expression.Dot("data"), key, value);
		}
	}
}
