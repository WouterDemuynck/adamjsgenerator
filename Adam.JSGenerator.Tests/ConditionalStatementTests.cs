using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ConditionalStatementTests
    {
        // ReSharper disable InconsistentNaming
        private static readonly Expression a = JS.Id("a");
        // ReSharper restore InconsistentNaming

        [TestMethod]
        public void ConditionalStatementProducesErrorWithMissingCondition()
        {
            var c = new ConditionalStatement();

            Expect.Throw<InvalidOperationException>(() => c.ToString());
        }

        [TestMethod]
        public void ConditionalStatementProducesIfWithEmptyThen()
        {
            var c = new ConditionalStatement();
            c.Condition = JS.Id("a");

            Assert.AreEqual("if(a);", c.ToString());
        }

        [TestMethod]
        public void ConditionalStatementProducesIfWithThenAndElse()
        {
            var c = JS.If(a).Then(JS.Return(a)).Else(JS.Return());

            Assert.AreEqual("if(a)return a; else return;", c.ToString());
        }

        [TestMethod]
        public void ConditionalStatementProducesIfThenElseIfThenElse()
        {
            var c1 = JS.If(a).Then(JS.Return(a));
            var c2 = new ConditionalStatement(JS.Not(a), null, null);
            c2.Parent = c1;
            c2.ThenStatement = JS.Return();
            c2.ElseStatement = JS.Return();

            Assert.AreEqual("if(a)return a; else if(!a)return; else return;", c2.ToString());
        }

        [TestMethod]
        public void ConditionalStatementHasHelpers()
        {
            var statement = JS.If(JS.Null());
            var then = statement.Then(new List<Statement> { JS.Return() });

            Assert.AreEqual("if(null)return;", then.ToString());

            var @else = then.Else(new List<Statement> { JS.Return() });

            Assert.AreEqual("if(null)return; else return;", @else.ToString());

            var elseif = then.ElseIf(JS.Null()).Then(JS.Return());

            Assert.AreEqual("if(null)return; else if(null)return;", elseif.ToString());
        }

        [TestMethod]
        public void ConditionalStatementHelpersRequireStatement()
        {
            ConditionalStatement statement = null;
            Expect.Throw<ArgumentNullException>(() => statement.Then());
            Expect.Throw<ArgumentNullException>(() => statement.Then(new List<Statement>()));
            Expect.Throw<ArgumentNullException>(() => statement.Else());
            Expect.Throw<ArgumentNullException>(() => statement.Else(new List<Statement>()));
            Expect.Throw<ArgumentNullException>(() => statement.ElseIf(null));
        }
   }
}
