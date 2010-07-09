using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class StringExpressionTests
    {
        [TestMethod]
        public void StringExpressionProducesEmptyString()
        {
            var s = new StringExpression();

            Assert.AreEqual("\"\";", s.ToString());
        }

        [TestMethod]
        public void StringExpressionProducesStringThroughConstructor()
        {
            string[] strings = new [] { "one", "two", "three" };

            StringExpression expression;

            foreach (var s in strings)
            {
                expression = new StringExpression(s);

                Assert.AreEqual("\"" + s + "\";", expression.ToString());
            }

            expression = new StringExpression();

            foreach (var s in strings)
            {
                expression.Value = s;

                Assert.AreEqual(s, expression.Value);
            }
        }
    }
}
