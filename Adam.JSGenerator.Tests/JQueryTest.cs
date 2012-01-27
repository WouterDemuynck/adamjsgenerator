using Adam.JSGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Adam.JSGenerator.Tests
{
	[TestClass]
	public class JQueryTests
	{
		private IdentifierExpression _oldJq;
		[TestInitialize]
		public void Initialize()
		{
			_oldJq = JQuery.JQ;
			JQuery.JQ = "$";
		}

		[TestMethod]
		public void JQueryHasJQ()
		{
			var expression = JS.JQuery();

			Assert.AreEqual("$();", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAdd()
		{
			var expression = JS.JQuery("div").Add("test");

			Assert.AreEqual(@"$(""div"").add(""test"");", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAddClass()
		{
			var expression = JS.JQuery("div").AddClass("test");

			Assert.AreEqual(@"$(""div"").addClass(""test"");", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAfter()
		{
			var expression = JS.JQuery("#this").After(JS.JQuery("#that"));

			Assert.AreEqual(@"$(""#this"").after($(""#that""));", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAjax()
		{
			var expression1 = JQuery.Ajax("http://service.com");
			var expression2 = JQuery.Ajax("http://service.com", new
			{
				accepts = "text/html",
				cache = false,
				complete = JS.Function().Parameters("xhr", "status").Do(JS.Alert(JS.Id("status")))
			});

			Assert.AreEqual(@"$.ajax(""http://service.com"");", expression1.ToString());
			Assert.AreEqual(@"$.ajax(""http://service.com"",{accepts:""text/html"",cache:false,complete:function(xhr,status){alert(status);}});", expression2.ToString());
		}

		[TestMethod]
		public void JQueryHasAjaxComplete()
		{
			var expression = JS.JQuery("div").AjaxComplete(JS.Function());

			Assert.AreEqual(@"$(""div"").ajaxComplete(function(){});", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAjaxError()
		{
			var expression = JS.JQuery("div").AjaxError(JS.Function());

			Assert.AreEqual(@"$(""div"").ajaxError(function(){});", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAjaxPrefilter()
		{
			var expression = JQuery.AjaxPrefilter("json", JS.Function());

			Assert.AreEqual(@"$.ajaxPrefilter(""json"",function(){});", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAjaxSend()
		{
			var expression = JS.JQuery("div").AjaxSend(JS.Function());

			Assert.AreEqual(@"$(""div"").ajaxSend(function(){});", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAjaxSetup()
		{
			var expression = JQuery.AjaxSetup(new {cache = false});

			Assert.AreEqual(@"$.ajaxSetup({cache:false});", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAjaxStart()
		{
			var expression = JS.JQuery("div").AjaxStart(JS.Function());

			Assert.AreEqual(@"$(""div"").ajaxStart(function(){});", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAjaxStop()
		{
			var expression = JS.JQuery("div").AjaxStop(JS.Function());

			Assert.AreEqual(@"$(""div"").ajaxStop(function(){});", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAjaxSuccess()
		{
			var expression = JS.JQuery("div").AjaxSuccess(JS.Function());

			Assert.AreEqual(@"$(""div"").ajaxSuccess(function(){});", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAddAndSelf()
		{
			var expression = JS.JQuery("div").AndSelf();

			Assert.AreEqual(@"$(""div"").andSelf();", expression.ToString());
		}

		[TestMethod]
		public void JQueryHasAnimate()
		{
			var expression = JS.JQuery("div").Animate(new {background = "#000", width = 100});

			Assert.AreEqual(@"$(""div"").animate({background:""#000"",width:100});", expression.ToString());
		}

		[TestCleanup]
		public void CleanUp()
		{
			JQuery.JQ = _oldJq;
		}
	}
}
