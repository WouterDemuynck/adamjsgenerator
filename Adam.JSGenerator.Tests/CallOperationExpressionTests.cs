using System.Collections.Generic;
using System.Linq;
using Adam.JSGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for CallOperationExpression
    /// </summary>
    [TestClass]
    public class CallOperationExpressionTests
    {
        // ReSharper disable InconsistentNaming
        private static readonly Expression fn = JS.Id("fn");
        // ReSharper restore InconsistentNaming

        [TestMethod]
        public void CallOperationExpression_Produces_Call()
        {
            var c = fn.Call();

            Assert.AreEqual("fn();", c.ToString());
        }

        [TestMethod]
        public void CallOperationExpression_Produces_Call_With_Parameters()
        {
            var c1 = fn.Call(1, 2, "Hello!");
            var p = new List<Expression> { 1, 2, 3 };
            var c2 = fn.Call(p);
            var p2 = c2.Arguments.AsEnumerable().Reverse().ToList();
            var c3 = new CallOperationExpression(null);
            c3.Operand = c2.Operand;
            c3.Arguments = p2;

            Assert.AreEqual("fn(1,2,\"Hello!\");", c1.ToString());
            Assert.AreEqual("fn(1,2,3);", c2.ToString());
            Assert.AreEqual("fn(3,2,1);", c3.ToString());
        }

        [TestMethod]
        public void CallOperationExpressionHelpers_Requires_Expression1()
        {
            Expression expression = null;
            Expect.Throw <ArgumentNullException>(() => expression.Call());
        }

        [TestMethod]
        public void CallOperationExpressionHelpers_Requires_Expression2()
        {
            Expression expression = null;
            IEnumerable<Expression> arguments = null;
            Expect.Throw<ArgumentNullException>(() => expression.Call(arguments));
        }

    }
}
