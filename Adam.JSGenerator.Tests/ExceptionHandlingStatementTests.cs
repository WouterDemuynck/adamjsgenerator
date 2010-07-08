using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adam.JSGenerator;
using System;
using System.Collections.Generic;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for ExceptionHandlingStatement
    /// </summary>
    [TestClass]
    public class ExceptionHandlingStatementTests
    {
        private static readonly IdentifierExpression E = JS.Id("e");
        private static readonly IdentifierExpression Alert = JS.Id("alert");

        [TestMethod]
        public void ExceptionHandlingStatement_Requires_TryBlock()
        {
            var e = new ExceptionHandlingStatement();

            Expect.Throw<InvalidOperationException>("TryBlock cannot be null.",
                () => e.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "CatchVariable cannot be null.")]
        public void ExceptionHandlingStatement_Requires_CatchVariable()
        {
            var e = new ExceptionHandlingStatement
            {
                TryBlock = new CompoundStatement(),
                CatchBlock = new CompoundStatement()
            };

            e.ToString();
        }

        [TestMethod]
        public void ExceptionHandlingStatement_Produces_Try_Catch()
        {
            var t1 = JS.Try(JS.Return()).Catch(E, Alert.Call(E));

            Assert.AreEqual("try{return;}catch(e){alert(e);}", t1.ToString());
        }

        [TestMethod]
        public void ExceptionHandlingStatement_Produces_Try_Finally()
        {
            var t1 = JS.Try(JS.Return()).Finally(Alert.Call(E));

            Assert.AreEqual("try{return;}finally{alert(e);}", t1.ToString());
        }

        [TestMethod]
        public void ExceptionHandlingStatement_Produces_Try_Catch_Finally()
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
        public void ExceptionHandlingStatementHelpers_Require_Statement()
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
