using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
	[TestClass]
	public class ThisExpressionTests
	{
		[TestMethod]
		public void ThisExpressionProducesThis()
		{
			var expression = new ThisExpression();

			Assert.AreEqual("this;", expression.ToString());
		}
	}
}