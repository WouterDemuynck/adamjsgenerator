using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class BreakStatementTests
    {
        [TestMethod]
        public void BreakStatementProducesBreak()
        {
            var b = new BreakStatement();

            Assert.AreEqual("break;", b.ToString());
        }

        [TestMethod]
        public void BreakStatementProducesBreakWithLabel()
        {
            var b = new BreakStatement("a");

            Assert.AreEqual("a", b.Label);
            Assert.AreEqual("break a;", b.ToString());
        }
    }
}
