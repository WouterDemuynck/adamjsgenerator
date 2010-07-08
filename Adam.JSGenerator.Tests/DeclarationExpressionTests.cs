using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adam.JSGenerator;
using System;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for DeclarationExpression
    /// </summary>
    [TestClass]
    public class DeclarationExpressionTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Expressions cannot be empty.")]
        public void DeclarationExpression_Requires_Expressions()
        {
            var d = new DeclarationExpression();

            d.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Expressions cannot be null.")]
        public void DeclarationExpression_Requires_Expressions_2()
        {
            var d = new DeclarationExpression();
            d.Expressions = null;

            d.ToString();
        }

        [TestMethod]
        public void DeclarationExpression_Produces_Declaration_From_Array()
        {
            var d = new DeclarationExpression(JS.Id("a"), JS.Id("b"), JS.Id("c").AssignWith(10));

            Assert.AreEqual("var a,b,c=10;", d.ToString());
        }

        [TestMethod]
        public void DeclarationExpression_Produces_Declaration_From_IEnumerable()
        {
            var l = new List<Expression> { JS.Id("a"), JS.Id("b"), JS.Id("c").AssignWith(10) };
            var d = new DeclarationExpression(l);

            Assert.AreEqual("var a,b,c=10;", d.ToString());
        }

        [TestMethod]
        public void DeclarationExpression_Produces_Declaration_From_PropertySetter()
        {
            var l = new List<Expression> { JS.Id("a"), JS.Id("b"), JS.Id("c").AssignWith(10) };
            var d = new DeclarationExpression();
            d.Expressions = l;

            Assert.AreEqual(3, d.Expressions.Count);
            Assert.AreEqual("var a,b,c=10;", d.ToString());
        }
    }
}
