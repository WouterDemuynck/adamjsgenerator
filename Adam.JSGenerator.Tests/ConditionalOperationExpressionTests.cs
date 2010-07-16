using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ConditionalOperationExpressionTests
    {
        [TestMethod]
        public void ConditionalOperationExpressionProducesConditionalOperation()
        {
            Expression condition = JS.Id("a").IsGreaterThan(0);
            Expression ifTrue = JS.String("Yes!");
            Expression ifFalse = JS.String("No!");

            var expression = new ConditionalOperationExpression(condition, ifTrue, ifFalse);

            Assert.AreEqual("a>0?\"Yes!\":\"No!\";", expression.ToString());
        }

        [TestMethod]
        public void ConditionalOperationExpressionRequiresConditionThenAndElse()
        {
            Expression condition = JS.Id("a").IsGreaterThan(0);
            Expression ifTrue = JS.String("Yes!");
            Expression ifFalse = JS.String("No!");

            var expression1 = new ConditionalOperationExpression(null, ifTrue, ifFalse);
            var expression2 = new ConditionalOperationExpression(condition, null, ifFalse);
            var expression3 = new ConditionalOperationExpression(condition, ifTrue, null);

            Expect.Throw<InvalidOperationException>(() => expression1.ToString());
            Expect.Throw<InvalidOperationException>(() => expression2.ToString());
            Expect.Throw<InvalidOperationException>(() => expression3.ToString());
        }
    }
}
