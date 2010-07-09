using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for IteratorStatementTests
    /// </summary>
    [TestClass]
    public class IteratorStatementTests
    {
        [TestMethod]
        public void Iterator_Requires_Variable()
        {
            var iterator = new IteratorStatement();
            iterator.Collection = JS.Id("b");
            iterator.Statement = JS.Empty();

            Expect.Throw<InvalidOperationException>("Variable cannot be null.",
                () => iterator.ToString());
        }

        [TestMethod]
        public void Iterator_Requires_Collection()
        {
            var iterator = new IteratorStatement();
            iterator.Variable = JS.Id("a");
            iterator.Statement = JS.Empty();

            Expect.Throw<InvalidOperationException>("Collection cannot be null.",
                () => iterator.ToString());
        }

        [TestMethod]
        public void Iterator_Requires_Statement()
        {
            var iterator = new IteratorStatement();
            iterator.Variable = JS.Id("a");
            iterator.Collection = JS.Id("b");

            Expect.Throw<InvalidOperationException>("Statement cannot be null",
                () => iterator.ToString());
        }

        [TestMethod]
        public void Iterator_Produces_For_In()
        {
            var id = JS.Id("a");
            var collection = JS.Array();
            var iterator = new IteratorStatement(id, collection, JS.Empty());

            Assert.AreEqual("a;", iterator.Variable.ToString());
            Assert.AreEqual("[];", iterator.Collection.ToString());
            Assert.AreEqual(";", iterator.Statement.ToString());
            Assert.AreEqual("for(a in []);", iterator.ToString());
        }

        [TestMethod]
        public void Iterator_Supports_Declaration()
        {
            var id = JS.Id("a");
            var collection = JS.Array();
            var iterator = new IteratorStatement(JS.Var(id), collection, JS.Empty());

            Assert.AreEqual("for(var a in []);", iterator.ToString());
        }

        [TestMethod]
        public void Iterator_Has_Helpers()
        {
            var statement1 = JS.For(JS.Id("a")).In(JS.Array()).With();
            var statement2 = JS.For(JS.Id("b")).In(JS.Id("c")).With(new List<Statement> { JS.Empty() });

            Assert.AreEqual("for(a in []);", statement1.ToString());
            Assert.AreEqual("for(b in c);", statement2.ToString());
        }

        [TestMethod]
        public void Iterator_Helpers_Requires_Iterator()
        {
            IteratorStatement iterator = null;
            Expect.Throw<ArgumentNullException>(() => iterator.With());
            Expect.Throw<ArgumentNullException>(() => iterator.With(new List<Statement>()));

            LoopStatement loop = null;
            Expect.Throw<ArgumentNullException>(() => loop.In(null));
        }
    }
}
