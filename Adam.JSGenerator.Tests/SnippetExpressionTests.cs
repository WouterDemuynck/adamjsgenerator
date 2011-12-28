using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
	[TestClass]
	public class SnippetExpressionTests
	{
		[TestMethod]
		public void SnippetExpressionProducesSnippet()
		{
			SnippetExpression expression = new SnippetExpression("yay!");

			Assert.AreEqual("yay!;", expression.ToString());
		}

		[TestMethod]
		public void SnippetExpressonHasProperty()
		{
			SnippetExpression expression = new SnippetExpression("");

			expression.Value = "3";

			Assert.AreEqual("3", expression.Value);
		}
	}

	[TestClass]
	public class SnippetStatementTests
	{
		[TestMethod]
		public void SnippetStatementProducesSnippet()
		{
			SnippetStatement statement = new SnippetStatement("yay!");

			Assert.AreEqual("yay!", statement.ToString());
		}

		[TestMethod]
		public void SnippetStatementHasProperty()
		{
			SnippetStatement statement = new SnippetStatement("");

			statement.Value = "3";

			Assert.AreEqual("3", statement.Value);
		}
	}
}
