using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ExceptionHandlingStatementTests
    {
        private static readonly IdentifierExpression E = JS.Id("e");
        private static readonly IdentifierExpression Alert = JS.Id("alert");

        [TestMethod]
        public void ExceptionHandlingStatementRequiresTryBlock()
        {
            var e = new ExceptionHandlingStatement();

            Expect.Throw<InvalidOperationException>(() => e.ToString());
        }

        [TestMethod]        
        public void ExceptionHandlingStatementRequiresCatchVariable()
        {
            var e = new ExceptionHandlingStatement
            {
                TryBlock = new CompoundStatement(),
                CatchBlock = new CompoundStatement()
            };

            Expect.Throw<InvalidOperationException>(() => e.ToString());
        }

        [TestMethod]
        public void ExceptionHandlingStatementProducesTryCatch()
        {
            var t1 = JS.Try(JS.Return()).Catch(E, Alert.Call(E));

            Assert.AreEqual("try{return;}catch(e){alert(e);}", t1.ToString());
        }

        [TestMethod]
        public void ExceptionHandlingStatementProducesTryFinally()
        {
            var t1 = JS.Try(JS.Return()).Finally(Alert.Call(E));

            Assert.AreEqual("try{return;}finally{alert(e);}", t1.ToString());
        }

        [TestMethod]
        public void ExceptionHandlingStatementProducesTryCatchFinally()
        {
            var t1 = JS
                .Try(JS.Return())
                .Catch(E, new List<Statement> { Alert.Call(E) })
                .Finally(new List<Statement> { JS.Null() });

            var t2 = new ExceptionHandlingStatement
            {
                TryBlock = new CompoundStatement(JS.Return()),
                CatchVariable = E,
                CatchBlock = new CompoundStatement(Alert.Call(E)),
                FinallyBlock = new CompoundStatement(JS.Null())
            };

            Assert.AreEqual("try{return;}catch(e){alert(e);}finally{null;}", t1.ToString());
            Assert.AreEqual("try{return;}catch(e){alert(e);}finally{null;}", t2.ToString());
        }

        [TestMethod]
        public void ExceptionHandlingStatementHelpersRequireStatement()
        {
            ExceptionHandlingStatement e = null;
            Expect.Throw<ArgumentNullException>(() => e.Catch(E));
            Expect.Throw<ArgumentNullException>(() => e.Catch(E, new List<Statement>()));
            Expect.Throw<ArgumentNullException>(() => e.Catch(E, new CompoundStatement()));
            Expect.Throw<ArgumentNullException>(() => e.Finally());
            Expect.Throw<ArgumentNullException>(() => e.Finally(new List<Statement>()));
            Expect.Throw<ArgumentNullException>(() => e.Finally(new CompoundStatement()));            
        }
    }
}
