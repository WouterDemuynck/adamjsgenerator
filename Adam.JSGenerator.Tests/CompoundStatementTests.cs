using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adam.JSGenerator;
using System;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for CompoundStatement
    /// </summary>
    [TestClass]
    public class CompoundStatementTests
    {
        [TestMethod]
        public void CompoundStatement_Produces_Empty_Block()
        {
            var c = new CompoundStatement();

            Assert.AreEqual("{}", c.ToString());
        }

        [TestMethod]
        public void CompoundStatement_Produces_Block_With_Statements()
        {
            var c = new CompoundStatement(new NullExpression(), new NullExpression(), new ReturnStatement());

            Assert.AreEqual("{null;null;return;}", c.ToString());
        }

        [TestMethod]
        public void CompoundStatement_Produces_Another_Block_With_Statements()
        {
            var c = new CompoundStatement();
            c.Statements.AddRange(new Statement[] { new NullExpression(), new NullExpression(), new ReturnStatement() });

            Assert.AreEqual("{null;null;return;}", c.ToString());
        }


        [TestMethod]
        public void CompoundStatement_Requires_Statements()
        {
            var c = new CompoundStatement();
            c.Statements = null;

            Expect.Throw<InvalidOperationException>(() => c.ToString());
        }

        [TestMethod]
        public void CompoundStatement_Has_Helpers()
        {
            var c = JS.Return();

            Assert.AreEqual("return;", c.ToString());
        }
    }
}
