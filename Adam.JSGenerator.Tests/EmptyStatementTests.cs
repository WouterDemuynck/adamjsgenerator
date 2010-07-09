using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for EmptyStatement
    /// </summary>
    [TestClass]
    public class EmptyStatementTests
    {
        [TestMethod]
        public void EmptyStatement_Produces_Empty_Statement()
        {
            var e = JS.Empty();

            Assert.AreEqual(";", e.ToString());
        }

        [TestMethod]
        public void EmptyStatement_Produces_Block()
        {
            var b = JS.BlockOrStatement(JS.Empty(), JS.Empty());

            Assert.AreEqual("{;;}", b.ToString());
        }
    }
}
