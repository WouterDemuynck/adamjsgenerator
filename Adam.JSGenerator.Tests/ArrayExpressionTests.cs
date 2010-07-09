using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for ArrayExpression
    /// </summary>
    [TestClass]
    public class ArrayExpressionTests
    {
        [TestMethod]
        public void ArrayExpression_Creates_Empty_ArrayExpression()
        {
            var a = new ArrayExpression();

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(0, a.Elements.Count);
            Assert.AreEqual("[];", a.ToString());
        }

        [TestMethod]
        public void Can_Create_ArrayExpression_With_Params()
        {
            var a = new ArrayExpression(1, 2, 3);

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(3, a.Elements.Count);
            Assert.AreEqual("[1,2,3];", a.ToString());
        }

        [TestMethod]
        public void Can_Create_ArrayExpression_With_IEnumerable()
        {
            var list = new List<Expression> { 1, 2, 3 };
            var a = new ArrayExpression(list);

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(3, a.Elements.Count);
            Assert.AreEqual("[1,2,3];", a.ToString());
        }

        [TestMethod]
        public void Can_Add_Expressions_To_ArrayExpression()
        {
            var a = new ArrayExpression();
            a.Elements.Add(1);
            a.Elements.Add(2);
            a.Elements.Add(3);

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(3, a.Elements.Count);
            Assert.AreEqual("[1,2,3];", a.ToString());
        }

        [TestMethod]
        public void Can_Set_ExpressionsList_Of_ArrayExpression()
        {
            var list = new List<Expression> { 1, 2, 3 };
            var a = new ArrayExpression(list);

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(3, a.Elements.Count);
            Assert.AreEqual("[1,2,3];", a.ToString());
        }

        [TestMethod]
        public void ArrayExpression_Handles_Nulls()
        {
            var a = JS.Array(1, 2, 3, null);

            Assert.AreEqual("[1,2,3,null];", a.ToString());
        }

        [TestMethod]
        public void Can_Compare_ArrayExpressions()
        {
            var a = new ArrayExpression(1, 2, 3);
            var b = new ArrayExpression(1, 2, 3);
            var c = new ArrayExpression(4, 5, 6);

            Assert.IsNotNull(a);
            Assert.IsNotNull(b);
            Assert.IsNotNull(c);
            Assert.IsTrue(Equals(a,b));
            Assert.IsFalse(Equals(a, c));
        }
        
        [TestMethod]
        public void ArrayExpression_Has_HashCode()
        {
            var a = new ArrayExpression(1, 2, 3);
            var b = new ArrayExpression(1, 2, 3);
            var c = new ArrayExpression(4, 5, 6);

            Assert.IsNotNull(a);
            Assert.IsNotNull(b);
            Assert.IsNotNull(c);
            Assert.IsTrue(Equals(a.GetHashCode(), b.GetHashCode()));
            Assert.IsFalse(Equals(a.GetHashCode(), c.GetHashCode()));
        }
    }
}
