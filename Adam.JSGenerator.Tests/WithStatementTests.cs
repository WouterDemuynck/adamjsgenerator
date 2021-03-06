﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class WithStatementTests
    {
        [TestMethod]
        public void WithStatementRequiresExpressionAndStatement()
        {
            var statement = new WithStatement();

            Expect.Throw<InvalidOperationException>(() => statement.ToString());

            statement.Expression = JS.Id("a");

            Expect.Throw<InvalidOperationException>(() => statement.ToString());

            statement.Statement = JS.Block();

            Assert.AreEqual("a;", statement.Expression.ToString());
            Assert.AreEqual("{}", statement.Statement.ToString());
            Assert.AreEqual("with(a){}", statement.ToString());
        }

        [TestMethod]
        public void WithStatementHasHelpers()
        {
            var statement1 = JS.With(JS.Id("a")).Do(JS.Empty());
            var statement2 = JS.With(JS.Id("a")).Do(new List<Statement> {JS.Empty()});

            Assert.AreEqual("with(a);", statement1.ToString());
            Assert.AreEqual("with(a);", statement2.ToString());
        }

        [TestMethod]
        public void WithStatementHelpersRequiresStatement()
        {
            WithStatement statement = null;

            Expect.Throw<ArgumentNullException>(() => statement.Do());
            Expect.Throw<ArgumentNullException>(() => statement.Do(new List<Statement>()));
        }
    }
}
