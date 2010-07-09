using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ThrowStatementTests
    {
        [TestMethod]
        public void ThrowStatementRequiresExpression()
        {
            var statement = new ThrowStatement(null);

            Expect.Throw<InvalidOperationException>(() => statement.ToString());
        }

        [TestMethod]
        public void ThrowStatementHasProperties()
        {
            var statement = new ThrowStatement(null);

            statement.Expression = 1;

            Assert.AreEqual(JS.Number(1), statement.Expression);
            Assert.AreEqual("throw 1;", statement.ToString());
        }

        [TestMethod]
        public void ThowStatementProducesThrow()
        {
            var statement = new ThrowStatement(1);

            Assert.AreEqual("throw 1;", statement.ToString());
        }
    }
}
