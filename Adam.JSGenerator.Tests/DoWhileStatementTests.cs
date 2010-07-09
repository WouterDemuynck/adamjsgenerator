using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class DoWhileStatementTests
    {
        [TestMethod]
        public void DoWhileStatementRequiresCondition()
        {
            var d = new DoWhileStatement();

            Expect.Throw<InvalidOperationException>(() => d.ToString());
        }

        [TestMethod]
        public void DoWhileStatementRequiresStatement()
        {
            var d = new DoWhileStatement(JS.Null(), null);

            Expect.Throw<InvalidOperationException>(() => d.ToString());
        }

        [TestMethod]
        public void DoWhileStatementProducesDoWhile()
        {
            var d = JS.Do(JS.Null(), JS.Null()).While(true);

            Assert.AreEqual("true;", d.Condition.ToString());
            Assert.AreEqual("{null;null;}", d.Statement.ToString());
            Assert.AreEqual("do {null;null;}while(true);", d.ToString());
        }

        [TestMethod]
        public void DoWhileStatementHelperRequiresStatement()
        {
            DoWhileStatement statement = null;
            Expect.Throw<ArgumentNullException>(() => statement.While(true));
        }
    }
}
