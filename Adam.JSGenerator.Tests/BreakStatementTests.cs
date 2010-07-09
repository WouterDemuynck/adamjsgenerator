using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for BreakStatement
    /// </summary>
    [TestClass]
    public class BreakStatementTests
    {
        [TestMethod]
        public void BreakStatement_Produces_Break()
        {
            var b = new BreakStatement();

            Assert.AreEqual("break;", b.ToString());
        }

        [TestMethod]
        public void BreakStatement_Produces_Break_With_Label()
        {
            var b = new BreakStatement("a");

            Assert.AreEqual("a", b.Label);
            Assert.AreEqual("break a;", b.ToString());
        }
    }
}
