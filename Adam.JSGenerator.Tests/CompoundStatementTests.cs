using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class CompoundStatementTests
    {
        [TestMethod]
        public void CompoundStatementProducesEmptyBlock()
        {
            var c = new CompoundStatement();

            Assert.AreEqual("{}", c.ToString());
        }

        [TestMethod]
        public void CompoundStatementProducesBlockWithStatements()
        {
            var c = new CompoundStatement(new NullExpression(), new NullExpression(), new ReturnStatement());

            Assert.AreEqual("{null;null;return;}", c.ToString());
        }

        [TestMethod]
        public void CompoundStatementHasHelpers()
        {
            var c = JS.Return();

            Assert.AreEqual("return;", c.ToString());
        }
    }
}
