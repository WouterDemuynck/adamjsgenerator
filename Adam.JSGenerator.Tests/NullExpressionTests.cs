using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class NullExpressionTests
    {
        [TestMethod]
        public void NullExpressionProducesNull()
        {
            var expression = new NullExpression();

            Assert.AreEqual("null;", expression.ToString());
        }
    }
}
