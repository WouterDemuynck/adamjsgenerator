using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class EmptyStatementTests
    {
        [TestMethod]
        public void EmptyStatementProducesEmptyStatement()
        {
            var e = JS.Empty();

            Assert.AreEqual(";", e.ToString());
        }

        [TestMethod]
        public void EmptyStatementProducesBlock()
        {
            var b = JS.BlockOrStatement(JS.Empty(), JS.Empty());

            Assert.AreEqual("{;;}", b.ToString());
        }
    }
}
