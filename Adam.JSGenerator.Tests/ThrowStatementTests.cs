using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ThrowStatementTests
    {
        [TestMethod]
        public void ThrowStatement_Requires_Expression()
        {
            var statement = new ThrowStatement(null);

            Expect.Throw<InvalidOperationException>(() => statement.ToString());
        }

        [TestMethod]
        public void ThrowStatement_Has_Properties()
        {
            var statement = new ThrowStatement(null);

            statement.Expression = 1;

            Assert.AreEqual(JS.Number(1), statement.Expression);
            Assert.AreEqual("throw 1;", statement.ToString());
        }

        [TestMethod]
        public void ThowStatement_Produces_Throw()
        {
            var statement = new ThrowStatement(1);

            Assert.AreEqual("throw 1;", statement.ToString());
        }
    }
}
