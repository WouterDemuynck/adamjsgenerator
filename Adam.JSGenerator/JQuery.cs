namespace Adam.JSGenerator
{
	///<summary>
	/// Serves as an example for writing extension methods.
	///</summary>
	public static class JQ
	{
		/// <summary>
		/// The name of the jQuery function to use. To be safe, leave this at 'jQuery', but if you want to use the shorthand you can set this to '$'.
		/// </summary>
		public static IdentifierExpression JQueryFunction = new IdentifierExpression("jQuery");


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
			return JQueryFunction.Dot("ajax").Call(settings);
		}

		/// <summary>
		/// Perform an asynchronous HTTP (Ajax) request.
		/// </summary>
		/// <param name="url">A string containing the URL to which the request is sent.</param>
		/// <param name="settings">A set of key/value pairs that configure the Ajax request. All settings are optional. A default can be set for any option with $.ajaxSetup(). See jQuery.ajax( settings ) below for a complete list of all settings.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression Ajax(Expression url, Expression settings)
		{
			return JQueryFunction.Dot("ajax").Call(url, settings);
		}

		
		/// <summary>
		/// Handle custom Ajax options or modify existing options before each request is sent and before they are processed by $.ajax().
		/// </summary>
		/// <param name="dataTypes">An optional string containing one or more space-separated dataTypes</param>
		/// <param name="handler">A handler to set default values for future Ajax requests.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxPrefilter(string dataTypes, Expression handler)
		{
			return JQueryFunction.Dot("ajaxPrefilter").Call(dataTypes, handler);
		}

		/// <summary>
		/// Handle custom Ajax options or modify existing options before each request is sent and before they are processed by $.ajax().
		/// </summary>
		/// <param name="handler">A handler to set default values for future Ajax requests.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxPrefilter(Expression handler)
		{
			return JQueryFunction.Dot("ajaxPrefilter").Call(handler);
		}

		/// <summary>
		/// Handle custom Ajax options or modify existing options before each request is sent and before they are processed by $.ajax().
		/// </summary>
		/// <param name="options">A set of key/value pairs that configure the default Ajax request. All options are optional.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>
		public static CallOperationExpression AjaxSetup(object options)
		{
			return JQueryFunction.Dot("ajaxSetup").Call(Expression.FromObject(options));
		}



		/// <summary>
		/// Attach a handler to an event for the elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="events">A map of one or more DOM event types and functions to execute for them.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>		
		public static CallOperationExpression Bind(this Expression expression, object events)
		{
			return new CallOperationExpression(expression.Dot("bind"), Expression.FromObject(events));
		}

		/// <summary>
		/// Triggers the blur event on the selected elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <returns>A new instance of <see cref="CallOperationExpression" />.</returns>		
		public static CallOperationExpression Blur(this Expression expression)
		{
			return new CallOperationExpression(expression.Dot("blur"));
		}

		/// <summary>
		/// Trigger the "change" event on an element.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Change(this Expression expression)
		{
			return new CallOperationExpression(expression.Dot("change"));
		}

		/// <summary>
		/// Bind an event handler to the "change" JavaScript event, or trigger that event on an element.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="handlerOrData">A function to execute each time the event is triggered or a map of data that will be passed to the event handler.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Change(this Expression expression, object handlerOrData)
		{
			return new CallOperationExpression(expression.Dot("change"), Expression.FromObject(handlerOrData));
		}

		/// <summary>
		/// Trigger the "change" event on an element.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="data">A map of data that will be passed to the event handler.</param>
		/// <param name="handler">A function to execute each time the event is triggered.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Change(this Expression expression, object data, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("change"), Expression.FromObject(data), handler);
		}

		/// <summary>
		/// Get the children of each element in the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Children(this Expression expression)
		{
			return new CallOperationExpression(expression.Dot("children"));
		}

		/// <summary>
		/// Get the children of each element in the set of matched elements filtered by a selector.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="selector">The selector.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Children(this Expression expression, object selector)
		{
			return new CallOperationExpression(expression.Dot("children"), Expression.FromObject(selector));
		}

		/// <summary>
		/// Remove from the queue all items that have not yet been run.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression ClearQueue(this Expression expression)
		{
			return new CallOperationExpression(expression.Dot("clearQueue"));
		}

		/// <summary>
		/// Remove from the queue all items that have not yet been run.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="queueName">Name of the queue.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression ClearQueue(this Expression expression, object queueName)
		{
			return new CallOperationExpression(expression.Dot("clearQueue"), Expression.FromObject(queueName));
		}

		/// <summary>
		/// Trigger the "click" event on an element.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Click(this Expression expression)
		{
			return new CallOperationExpression(expression.Dot("click"));
		}

		/// <summary>
		/// Bind an event handler to the "click" JavaScript event, or trigger that event on an element.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="handlerOrData">A function to execute each time the event is triggered or a map of data that will be passed to the event handler.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Click(this Expression expression, object handlerOrData)
		{
			return new CallOperationExpression(expression.Dot("click"), Expression.FromObject(handlerOrData));
		}

		/// <summary>
		/// Trigger the "click" event on an element.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="data">A map of data that will be passed to the event handler.</param>
		/// <param name="handler">A function to execute each time the event is triggered.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Click(this Expression expression, object data, Expression handler)
		{
			return new CallOperationExpression(expression.Dot("click"), Expression.FromObject(data), handler);
		}

		/// <summary>
		/// Create a deep copy of the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Clone(this Expression expression)
		{
			return new CallOperationExpression(expression.Dot("clone"));
		}

		/// <summary>
		/// Create a deep copy of the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="withDataAndEvents">A Boolean indicating whether event handlers should be copied along with the elements. As of jQuery 1.4, element data will be copied as well.</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Clone(this Expression expression, object withDataAndEvents)
		{
			return new CallOperationExpression(expression.Dot("clone"), Expression.FromObject(withDataAndEvents));
		}

		/// <summary>
		/// Create a deep copy of the set of matched elements.
		/// </summary>
		/// <param name="expression">The set of matched elements to call this function on.</param>
		/// <param name="withDataAndEvents">A Boolean indicating whether event handlers should be copied along with the elements. As of jQuery 1.4, element data will be copied as well.</param>
		/// <param name="deepWithDataAndEvents">A Boolean indicating whether event handlers and data for all children of the cloned element should be copied. By default its value matches the first argument's value (which defaults to false).</param>
		/// <returns>
		/// A new instance of <see cref="CallOperationExpression"/>.
		/// </returns>
		public static CallOperationExpression Clone(this Expression expression, object withDataAndEvents, object deepWithDataAndEvents)
		{
			return new CallOperationExpression(expression.Dot("clone"), Expression.FromObject(withDataAndEvents), Expression.FromObject(deepWithDataAndEvents));
		}
	}
}
