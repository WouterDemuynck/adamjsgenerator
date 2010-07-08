using System;
using Adam.JSGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for DoWhileStatementTest
    /// </summary>
    [TestClass]
    public class DoWhileStatementTests
    {
        [TestMethod]
        public void DoWhileStatement_Requires_Condition()
        {
            var d = new DoWhileStatement();

            Expect.Throw<InvalidOperationException>(() => d.ToString());
        }

        [TestMethod]
        public void DoWhileStatement_Requires_Statement()
        {
            var d = new DoWhileStatement(JS.Null(), null);

            Expect.Throw<InvalidOperationException>(() => d.ToString());
        }

        [TestMethod]
        public void DoWhileStatement_Produces_Do_While()
        {
            var d = JS.Do(JS.Null(), JS.Null()).While(true);

            Assert.AreEqual("true;", d.Condition.ToString());
            Assert.AreEqual("{null;null;}", d.Statement.ToString());
            Assert.AreEqual("do {null;null;}while(true);", d.ToString());
        }

        [TestMethod]
        public void DoWhileStatementHelper_Requires_Statement()
        {
            DoWhileStatement statement = null;
            Expect.Throw<ArgumentNullException>(() => statement.While(true));
        }
    }
}
