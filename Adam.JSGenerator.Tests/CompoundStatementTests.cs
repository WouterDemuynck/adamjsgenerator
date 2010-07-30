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

            Assert.AreEqual(0, c.Statements.Count);
            Assert.AreEqual("{}", c.ToString());
        }

        [TestMethod]
        public void CompoundStatementProducesBlockWithStatements()
        {
            var c = new CompoundStatement(new NullExpression(), new NullExpression(), new ReturnStatement());

            Assert.AreEqual(3, c.Statements.Count);
            Assert.AreEqual("{null;null;return;}", c.ToString());
        }
    }
}
