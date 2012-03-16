using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator.JQuery
{
	public static class JQueryHelpers
	{
		/// <summary>
		/// Add elements to the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to add to.</param>
		/// <param name="arguments">The arguments to pass to the function.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Add(this Expression expression, params Expression[] arguments)
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
			var parameters = new[] { Expression.FromObject(properties) }.Concat(extras);
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
		/// Insert content, specified by the parameter, before each element in the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="content">HTML string, DOM element, or jQuery object to insert before each element in the set of matched elements.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>		
		public static CallOperationExpression Before(this Expression expression, params Expression[] content)
		{
			return new CallOperationExpression(expression.Dot("before"), content);
		}

		/// <summary>
		/// Attach a handler to an event for the elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="eventType">A string containing one or more DOM event types, such as "click" or "submit," or custom event names.</param>
		/// <param name="extras">
		/// Extra optional parameters, including:
		/// - A map of data that will be passed to the event handler.
		/// - A function to execute each time the event is triggered or <c>false</c> to attach a function that prevents the default action from occurring and stops the event from bubbling.
		/// </param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>		
		public static CallOperationExpression Bind(this Expression expression, Expression eventType, params Expression[] extras)
		{
			var arguments = new[] { eventType }.Concat(extras);
			return new CallOperationExpression(expression.Dot("bind"), arguments);
		}

		/// <summary>
		/// Bind an event handler to the "blur" JavaScript event, or trigger that event on an element.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="handler">A function to execute each time the event is triggered.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>		
		public static CallOperationExpression Blur(this Expression expression, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("bind"), handler);
		}

		/// <summary>
		/// Bind an event handler to the "blur" JavaScript event, or trigger that event on an element.
		/// </summary>
		/// <param name="eventData">A map of data that will be passed to the event handler.</param>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="handler">A function to execute each time the event is triggered.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>		
		public static CallOperationExpression Blur(this Expression expression, object eventData, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("blur"), Expression.FromObject(eventData), handler);
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
