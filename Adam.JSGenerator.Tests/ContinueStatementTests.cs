using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ContinueStatementTests
    {
        [TestMethod]
        public void ContinueStatementProducesContinueWithoutLabel()
        {
            var c = new ContinueStatement();

            Assert.AreEqual("continue;", c.ToString());
        }

        [TestMethod]
        public void ContinueStatementProducesContinueWithLabel()
        {
            var c = new ContinueStatement("here");

            Assert.AreEqual("here", c.Label);
            Assert.AreEqual("continue here;", c.ToString());
        }
    }
}
