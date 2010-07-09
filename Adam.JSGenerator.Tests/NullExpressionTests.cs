using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for NullExpressionTests
    /// </summary>
    [TestClass]
    public class NullExpressionTests
    {
        [TestMethod]
        public void NullExpression_Produces_Null()
        {
            var expression = new NullExpression();

            Assert.AreEqual("null;", expression.ToString());
        }
    }
}
