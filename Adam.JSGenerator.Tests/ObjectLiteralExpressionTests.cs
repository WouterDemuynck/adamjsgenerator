using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ObjectLiteralExpressionTests
    {
        [TestMethod]
        public void ObjectLiteralExpressionProducesEmptyObject()
        {
            var expression = new ObjectLiteralExpression();

            Assert.AreEqual("{};", expression.ToString());
        }

        [TestMethod]
        public void ObjectLiteralExpressionProducesObjectLiteralFromDictionary()
        {
            var expression = new ObjectLiteralExpression(new Dictionary<Expression, Expression>
            {
                {JS.Id("a"), JS.Number(12)},
                {JS.Id("b"), JS.String("Wrong!")},
                {JS.Id("c"), null}
            });

            Assert.AreEqual(3, expression.Properties.Count);
            Assert.AreEqual("{a:12,b:\"Wrong!\",c:null};", expression.ToString());
        }

        [TestMethod]
        public void ObjectLiteralExpressionProducesObjectLiteralFromObject()
        {
            var expression = new ObjectLiteralExpression(
                new
                {
                    a = JS.Number(12),
                    b = JS.String("Wrong!"),
                    c = (Expression) null
                });

            Assert.AreEqual(3, expression.Properties.Count);
            Assert.AreEqual("{a:12,b:\"Wrong!\",c:null};", expression.ToString());
        }

        [TestMethod]
        public void ObjectLiteralExpressionHasHelpers()
        {
            var expression = new ObjectLiteralExpression();

            Assert.AreEqual("{};", expression.ToString());

            expression = expression.WithProperty(JS.Id("name"), "value");

            Assert.AreEqual("{name:\"value\"};", expression.ToString());

            expression = expression.WithProperties(new Dictionary<Expression, Expression>
            {
                {JS.Id("key"), "value"},
                {JS.Id("price"), 1200}
            });

            Assert.AreEqual("{name:\"value\",key:\"value\",price:1200};", expression.ToString());
        }

        [TestMethod]
        public void ObjectLiteralExpressionHelpersRequireExpression()
        {
            ObjectLiteralExpression expression = null;
            Expect.Throw<ArgumentNullException>(() => expression.WithProperty("name", "value"));
            Expect.Throw<ArgumentNullException>(() => expression.WithProperties(new Dictionary<Expression, Expression>()));
        }
    }
}
