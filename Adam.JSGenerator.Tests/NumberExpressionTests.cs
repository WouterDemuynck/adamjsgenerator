using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class NumberExpressionTests
    {
        [TestMethod]
        public void NumberExpressionProducesNumbers()
        {
            NumberExpression n1 = new NumberExpression(1.0);
            NumberExpression n2 = new NumberExpression(12);
            NumberExpression n3 = new NumberExpression(0.5);
            NumberExpression n4 = new NumberExpression(-58);

            Assert.AreEqual("1;", n1.ToString());
            Assert.AreEqual("12;", n2.ToString());
            Assert.AreEqual("0.5;", n3.ToString());
            Assert.AreEqual("-58;", n4.ToString());

            n4.Value = n4.Value + 1;

            Assert.AreEqual("-57;", n4.ToString());
        }
    }
}
