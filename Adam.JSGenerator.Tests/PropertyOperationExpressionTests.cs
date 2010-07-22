using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class PropertyOperationExpressionTests
    {
        [TestMethod]
        public void PropertyOperationExpressionProducesADot()
        {
            var expression = new PropertyOperationExpression(JS.Id("a"), "b");

            Assert.AreEqual("a;", expression.OperandLeft.ToString());
            Assert.AreEqual("b;", expression.OperandRight.ToString());
            Assert.AreEqual("a.b;", expression.ToString());
        }

        [TestMethod]
        public void PropertyOperationExpressionRequiresLeftAndRightOperands()
        {
            var expression1 = new PropertyOperationExpression(JS.Id("a"), "b");
            expression1.OperandLeft = null;

            Expect.Throw<InvalidOperationException>(() => expression1.ToString());
            
            var expression2 = new PropertyOperationExpression(JS.Id("a"), JS.Id("b"));
            expression2.OperandRight = null;

            Expect.Throw<InvalidOperationException>(() => expression2.ToString());
        }

        [TestMethod]
        public void PropertyOperationExpressionHasHelpers()
        {
            var expression = JS.Id("a").Dot("b");

            Assert.AreEqual("a;", expression.OperandLeft.ToString());
            Assert.AreEqual("b;", expression.OperandRight.ToString());
            Assert.AreEqual("a.b;", expression.ToString());
        }

        [TestMethod]
        public void PropertyOperationExpressionHasCrazyIdea()
        {
            var expression = new {id = "test"}.Dot("id");

            Assert.AreEqual("{id:\"test\"}.id;", expression.ToString());
        }

        [TestMethod]
        public void PropertyOperationExpressionHelpersRequireExpression()
        {
            Expression expression = null;

            Expect.Throw<ArgumentNullException>(() => expression.Dot("a"));
        }
    }
}
