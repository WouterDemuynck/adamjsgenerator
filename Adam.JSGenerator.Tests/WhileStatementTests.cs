using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Adam.JSGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class WhileStatementTests
    {
        [TestMethod]
        public void WhileStatement_Produces_Empty_While()
        {
            var statement = new WhileStatement();
            statement.Condition = true;
            statement.Statement = JS.Empty();

            Assert.AreEqual("true;", statement.Condition.ToString());
            Assert.AreEqual(";", statement.Statement.ToString());
            Assert.AreEqual("while(true);", statement.ToString());
        }

        [TestMethod]
        public void WhileStatement_Requires_Condition_And_Statement()
        {
            var statement = new WhileStatement();

            Expect.Throw<InvalidOperationException>("Condition cannot be null.",
                () => statement.ToString());

            statement.Condition = true;

            Expect.Throw<InvalidOperationException>("Statement cannot be null.",
                () => statement.ToString());

            statement.Statement = JS.Empty();

            Assert.AreEqual("while(true);", statement.ToString());
        }

        [TestMethod]
        public void WhileStatement_Has_Helpers()
        {
            var statement1 = JS.While(true).Do(JS.Empty());

            Assert.AreEqual("true;", statement1.Condition.ToString());
            Assert.AreEqual(";", statement1.Statement.ToString());
            Assert.AreEqual("while(true);", statement1.ToString());

            var statement2 = JS.While(true).Do(new List<Statement> {JS.Empty()});

            Assert.AreEqual("true;", statement2.Condition.ToString());
            Assert.AreEqual(";", statement2.Statement.ToString());
            Assert.AreEqual("while(true);", statement2.ToString());
        }

        [TestMethod]
        public void WhileStatement_Helpers_Require_Statement()
        {
            WhileStatement statement = null;

            Expect.Throw<ArgumentNullException>(() => statement.Do());
            Expect.Throw<ArgumentNullException>(() => statement.Do(new List<Statement>()));
        }

    }
}
