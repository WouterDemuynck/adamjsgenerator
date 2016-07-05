using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class UnaryOperationExpressionTests
    {
        [TestMethod]
        public void UnaryOperationExpressionProducesUnaryOperations()
        {
            var a = JS.Id("a");

            Assert.AreEqual("+a;", a.Number().ToString());
            Assert.AreEqual("+a;", (+a).ToString());
            Assert.AreEqual("-a;", a.Negative().ToString());
            Assert.AreEqual("-a;", (-a).ToString());
            Assert.AreEqual("~a;", a.BitwiseNot().ToString());
            Assert.AreEqual("~a;", (~a).ToString());
            Assert.AreEqual("!a;", a.LogicalNot().ToString());
            Assert.AreEqual("!a;", (!a).ToString());
            Assert.AreEqual("++a;", a.PreIncrement().ToString());
            Assert.AreEqual("a++;", a.PostIncrement().ToString());
            Assert.AreEqual("--a;", a.PreDecrement().ToString());
            Assert.AreEqual("a--;", a.PostDecrement().ToString());
            Assert.AreEqual("new a();", a.New().ToString());
            Assert.AreEqual("typeof a;", a.TypeOf().ToString());
            Assert.AreEqual("delete a;", a.Delete().ToString());
            Assert.AreEqual("(a);", a.Group().ToString());
        }

        [TestMethod]
        public void UnaryOperationExpressionHasProperties()
        {
            var a = JS.Id("a");

            var expression = new UnaryOperationExpression(a, UnaryOperator.Number);

            Assert.AreEqual("+a;", expression.ToString());

            expression.Operator = UnaryOperator.New;

            Assert.AreEqual(UnaryOperator.New, expression.Operator);
            Assert.AreEqual("new a;", expression.ToString());

            expression.Operand = JS.ParseId("Sys.UI.Component");

            Assert.AreEqual("Sys.UI.Component;", expression.Operand.ToString());
            Assert.AreEqual("new Sys.UI.Component;", expression.ToString());
        }

        [TestMethod]
        public void UnaryOperationExpressionsSupportPrecedence()
        {
            var expression = JS.Number(3).Group().AddWith(JS.Id("a").TypeOf().New());

            Assert.AreEqual("(3)+new (typeof a)();", expression.ToString());
        }

        [TestMethod]
        public void UnaryOperationExpressionDetectsUnknownEnumeration()
        {
            var expression = new UnaryOperationExpression(1, (UnaryOperator) int.MaxValue);

            Expect.Throw<InvalidOperationException>(() => expression.ToString());
        }

        [TestMethod]
        public void UnaryOperationExpressionHelpersRequireExpression()
        {
            Expression expression = null;

            Expect.Throw<ArgumentNullException>(() => expression.BitwiseNot());
            Expect.Throw<ArgumentNullException>(() => expression.Delete());
            Expect.Throw<ArgumentNullException>(() => expression.Group());
            Expect.Throw<ArgumentNullException>(() => expression.LogicalNot());
            Expect.Throw<ArgumentNullException>(() => expression.Negative());
            Expect.Throw<ArgumentNullException>(() => expression.New());
            Expect.Throw<ArgumentNullException>(() => expression.Number());
            Expect.Throw<ArgumentNullException>(() => expression.PostDecrement());
            Expect.Throw<ArgumentNullException>(() => expression.PostIncrement());
            Expect.Throw<ArgumentNullException>(() => expression.PreDecrement());
            Expect.Throw<ArgumentNullException>(() => expression.PreIncrement());
            Expect.Throw<ArgumentNullException>(() => expression.TypeOf());
        }
    }
}
