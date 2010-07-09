using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for ContinueStatement
    /// </summary>
    [TestClass]
    public class ContinueStatementTests
    {
        [TestMethod]
        public void ContinueStatement_Produces_Continue_Without_Label()
        {
            var c = new ContinueStatement();

            Assert.AreEqual("continue;", c.ToString());
        }

        [TestMethod]
        public void ContinueStatement_Produces_Continue_With_Label()
        {
            var c = new ContinueStatement("here");

            Assert.AreEqual("here", c.Label);
            Assert.AreEqual("continue here;", c.ToString());
        }
    }
}
