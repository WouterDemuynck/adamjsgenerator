using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class WhileStatementTests
    {
        [TestMethod]
        public void WhileStatementProducesEmptyWhile()
        {
            var statement = new WhileStatement();
            statement.Condition = true;
            statement.Statement = JS.Empty();

            Assert.AreEqual("true;", statement.Condition.ToString());
            Assert.AreEqual(";", statement.Statement.ToString());
            Assert.AreEqual("while(true);", statement.ToString());
        }

        [TestMethod]
        public void WhileStatementRequiresConditionAndStatement()
        {
            var statement = new WhileStatement();

            Expect.Throw<InvalidOperationException>(() => statement.ToString());

            statement.Condition = true;

            Expect.Throw<InvalidOperationException>(() => statement.ToString());

            statement.Statement = JS.Empty();

            Assert.AreEqual("while(true);", statement.ToString());
        }

        [TestMethod]
        public void WhileStatementHasHelpers()
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
        public void WhileStatementHelpersRequireStatement()
        {
            WhileStatement statement = null;

            Expect.Throw<ArgumentNullException>(() => statement.Do());
            Expect.Throw<ArgumentNullException>(() => statement.Do(new List<Statement>()));
        }

    }
}
