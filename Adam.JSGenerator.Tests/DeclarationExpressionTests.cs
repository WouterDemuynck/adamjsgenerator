using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class DeclarationExpressionTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Expressions cannot be empty.")]
        public void DeclarationExpressionRequiresExpressions()
        {
            var d = new DeclarationExpression();

            d.ToString();
        }

        [TestMethod]
        public void DeclarationExpressionProducesDeclarationFromArray()
        {
            var d = new DeclarationExpression(JS.Id("a"), JS.Id("b"), JS.Id("c").AssignWith(10));

            Assert.AreEqual("var a,b,c=10;", d.ToString());
        }

        [TestMethod]
        public void DeclarationExpressionProducesDeclarationFromIEnumerable()
        {
            var l = new List<Expression> { JS.Id("a"), JS.Id("b"), JS.Id("c").AssignWith(10) };
            var d = new DeclarationExpression(l);

            Assert.AreEqual("var a,b,c=10;", d.ToString());
        }

        [TestMethod]
        public void DeclarationExpressionProducesDeclarationFromPropertySetter()
        {
            var l = new List<Expression> { JS.Id("a"), JS.Id("b"), JS.Id("c").AssignWith(10) };
            var d = new DeclarationExpression(l);

            Assert.AreEqual(3, d.Expressions.Count);
            Assert.AreEqual("var a,b,c=10;", d.ToString());
        }
    }
}
