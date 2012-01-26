using System.Collections.Generic;
using System.Linq;

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
		/// Handle custom Ajax options or modify existing options before each request is sent and before they are processed by $.ajax().
		/// </summary>
		/// <param name="dataTypes">An optional string containing one or more space-separated dataTypes</param>
		/// <param name="handler">A handler to set default values for future Ajax requests.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxPrefilter(string dataTypes, Expression handler)
		{
			return JQ.Dot("ajaxPrefilter").Call(dataTypes, handler);
		}

		/// <summary>
		/// Handle custom Ajax options or modify existing options before each request is sent and before they are processed by $.ajax().
		/// </summary>
		/// <param name="handler">A handler to set default values for future Ajax requests.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxPrefilter(Expression handler)
		{
			return JQ.Dot("ajaxPrefilter").Call(handler);
		}

		/// <summary>
		/// Attach a function to be executed before an Ajax request is sent. This is an Ajax Event.
		/// </summary>
		/// <param name="expression">The jQuery set to apply this call.</param>
		/// <param name="handler">The function to be invoked.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxSend(this Expression expression, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("ajaxSend"), handler);
		}

		/// <summary>
		/// Handle custom Ajax options or modify existing options before each request is sent and before they are processed by $.ajax().
		/// </summary>
		/// <param name="options">A set of key/value pairs that configure the default Ajax request. All options are optional.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxSetup(object options)
		{
			return JQ.Dot("ajaxSetup").Call(Expression.FromObject(options));
		}

		/// <summary>
		/// Register a handler to be called when the first Ajax request begins. This is an Ajax Event.
		/// </summary>
		/// <param name="expression">The jQuery set to apply this call.</param>
		/// <param name="handler">The function to be invoked.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxStart(this Expression expression, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("ajaxStart"), handler);
		}

		/// <summary>
		/// Register a handler to be called when all Ajax requests have completed. This is an Ajax Event.
		/// </summary>
		/// <param name="expression">The jQuery set to apply this call.</param>
		/// <param name="handler">The function to be invoked.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxStop(this Expression expression, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("ajaxStop"), handler);
		}

		/// <summary>
		/// Attach a function to be executed whenever an Ajax request completes successfully. This is an Ajax Event.
		/// </summary>
		/// <param name="expression">The jQuery set to apply this call.</param>
		/// <param name="handler">The function to be invoked.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxSuccess(this Expression expression, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("ajaxSuccess"), handler);
		}

		/// <summary>
		/// Add the previous set of elements on the stack to the current set.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AndSelf(this Expression expression)
		{
			return new CallOperationExpression(expression.Dot("andSelf"));
		}

		/// <summary>
		/// Perform a custom animation of a set of CSS properties.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="properties">A map of CSS properties that the animation will move toward.</param>
		/// <param name="extras">
		/// Extra optional parameters, including:
		/// - A string or number determining how long the animation will run.
		/// - A string indicating which easing function to use for the transition.
		/// - A function to call once the animation is complete.
		/// </param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Animate(this Expression expression, object properties, params Expression[] extras)
		{
			var parameters = new[] {Expression.FromObject(properties)}.Concat(extras);
			return new CallOperationExpression(expression.Dot("animate"), parameters);
		}

		/// <summary>
		/// Perform a custom animation of a set of CSS properties.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="properties">A map of CSS properties that the animation will move toward.</param>
		/// <param name="options">A map of additional options to pass to the method.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Animate(this Expression expression, object properties, object options)
		{
			return new CallOperationExpression(expression.Dot("animate"), Expression.FromObject(properties), Expression.FromObject(options));
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
		/// Insert every element in the set of matched elements to the end of the target.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="target">A selector, element, HTML string, or jQuery object; the matched set of elements will be inserted at the end of the element(s) specified by this parameter.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AppendTo(this Expression expression, Expression target)
		{
			return new CallOperationExpression(expression.Dot("appendTo"), target);
		}

		/// <summary>
		/// Get the value of an attribute for the first element in the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="attributeName">The name of the attribute to get.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Attr(this Expression expression, Expression attributeName)
		{
			return new CallOperationExpression(expression.Dot("attr"), attributeName);
		}

		/// <summary>
		/// Set one or more attributes for the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="attributeName">The name of the attribute to get.</param>
		/// <param name="value">A value to set for the attribute.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>		
		public static CallOperationExpression Attr(this Expression expression, Expression attributeName, Expression value)
		{
			return new CallOperationExpression(expression.Dot("attr"), attributeName, value);
		}

		/// <summary>
		/// Set one or more attributes for the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="map">A map of attribute-value pairs to set.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>		
		public static CallOperationExpression Attr(this Expression expression, object map)
		{
			return new CallOperationExpression(expression.Dot("attr"), Expression.FromObject(map));
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
