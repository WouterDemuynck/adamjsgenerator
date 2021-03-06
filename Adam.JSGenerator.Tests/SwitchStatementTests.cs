﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class SwitchStatementTests
    {
        [TestMethod]
        public void SwitchStatementProducesEmptySwitch()
        {
            var statement = JS.Switch(JS.Id("a"));
    
            Assert.AreEqual("switch(a){}", statement.ToString());

            statement.Expression = JS.Id("b");

            Assert.AreEqual("switch(b){}", statement.ToString());
        }

        [TestMethod]
        public void SwitchStatementRequiresExpression()
        {
            var statement = JS.Switch(null);

            Expect.Throw<InvalidOperationException>(() => statement.ToString());
        }

        [TestMethod]
        public void SwitchStatementProducesSwitch()
        {
            var statement1 = JS.Switch(JS.Id("a"))
                .Case("a").Do(JS.Return("a"));

            Assert.AreEqual("switch(a){case \"a\":return \"a\";}", statement1.ToString());

            var statement2 = JS.Switch(JS.Id("b"))
                .Case(1).Do(JS.Return(100))
                .Case(2).Case(3).Do(JS.Return(200))
                .Case(4, 5, 6).Do(new List<Statement>
                {
                    JS.Alert("Not Done!"),
                    JS.Break()
                })
                .Case(Enumerable.Range(7, 4).Select(i => (Expression) JS.Number(i))).Do(
                    JS.Alert(JS.Id("a")),
                    JS.Break())
                .Default().Do(JS.Break());

            statement2.Cases.Add(null);

            Assert.AreEqual(
                "switch(b){case 1:return 100;case 2:case 3:return 200;" + 
                "case 4:case 5:case 6:alert(\"Not Done!\");break;" +
                "case 7:case 8:case 9:case 10:alert(a);break;default:break;}", 
                statement2.ToString());

            CaseStatement test = new CaseStatement(3);

            test.Value = 4;
            test.Statements.Add(JS.Break());

            var cases = new List<CaseStatement>
            {
                new CaseStatement(1, JS.Break()),
                new CaseStatement(2, new List<Statement> { JS.Break() }),
                test
            };

            var statement3 = new SwitchStatement(JS.Id("c"), cases);

            Assert.AreEqual("switch(c){case 1:break;case 2:break;case 4:break;}", statement3.ToString());
        }

        [TestMethod]
        public void SwitchStatementDefaultMustComeLast()
        {
            var statement = JS.Switch(JS.Id("a"))
                .Default()
                .Do(JS.Break())
                .Case((IEnumerable<Expression>)null)
                .Case(1)
                .Do(JS.Break());

            Expect.Throw<InvalidOperationException>(() => statement.ToString());
        }

        [TestMethod]
        public void SwitchStatementHelpersRequireStatement()
        {
            SwitchStatement statement = null;

            Expect.Throw<ArgumentNullException>(() => statement.Default());
            Expect.Throw<ArgumentNullException>(() => statement.Case(1));
            Expect.Throw<ArgumentNullException>(() => statement.Case(new List<Expression>()));
            Expect.Throw<ArgumentNullException>(() => statement.Break());
            Expect.Throw<ArgumentNullException>(() => statement.Do());
            Expect.Throw<ArgumentNullException>(() => statement.Do(new List<Statement>()));
        }
    }
}
