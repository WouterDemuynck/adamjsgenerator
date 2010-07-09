using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class PropertyOperationExpressionTests
    {
        [TestMethod]
        public void PropertyOperationExpression_Produces_A_Dot()
        {
            var expression = new PropertyOperationExpression(JS.Id("a"), JS.Id("b"));

            Assert.AreEqual("a;", expression.OperandLeft.ToString());
            Assert.AreEqual("b;", expression.OperandRight.ToString());
            Assert.AreEqual("a.b;", expression.ToString());
        }

        [TestMethod]
        public void PropertyOperationExpression_Requires_Left_And_Right_Operands()
        {
            var expression1 = new PropertyOperationExpression(JS.Id("a"), JS.Id("b"));
            expression1.OperandLeft = null;

            Expect.Throw<InvalidOperationException>(() => expression1.ToString());
            
            var expression2 = new PropertyOperationExpression(JS.Id("a"), JS.Id("b"));
            expression2.OperandRight = null;

            Expect.Throw<InvalidOperationException>(() => expression2.ToString());
        }

        [TestMethod]
        public void PropertyOperationExpression_Has_Helpers()
        {
            var expression = JS.Id("a").Dot("b");

            Assert.AreEqual("a;", expression.OperandLeft.ToString());
            Assert.AreEqual("b;", expression.OperandRight.ToString());
            Assert.AreEqual("a.b;", expression.ToString());
        }

        [TestMethod]
        public void PropertyOperationExpression_Helpers_Require_Expression()
        {
            Expression expression = null;

            Expect.Throw<ArgumentNullException>(() => expression.Dot("a"));
        }
    }
}
