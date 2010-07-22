using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ArrayExpressionTests
    {
        [TestMethod]
        public void ArrayExpressionCreatesEmptyArrayExpression()
        {
            var a = new ArrayExpression();

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(0, a.Elements.Count);
            Assert.AreEqual("[];", a.ToString());
        }

        [TestMethod]
        public void CanCreateArrayExpressionWithParams()
        {
            var a = new ArrayExpression(1, 2, 3);

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(3, a.Elements.Count);
            Assert.AreEqual("[1,2,3];", a.ToString());
        }

        [TestMethod]
        public void CanCreateArrayExpressionWithAnyIEnumerable()
        {
            var list = new List<int> { 1, 2, 3 };
            var a = new ArrayExpression(list);

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(3, a.Elements.Count);
            Assert.AreEqual("[1,2,3];", a.ToString());
        }

        [TestMethod]
        public void CanCreateArrayExpressionWithIEnumerableOfExpression()
        {
            var list = new List<Expression> { 1, 2, 3 };
            var a = new ArrayExpression(list);

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(3, a.Elements.Count);
            Assert.AreEqual("[1,2,3];", a.ToString());
        }

        [TestMethod]
        public void CanAddExpressionsToArrayExpression()
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
        public void CanSetExpressionsListOfArrayExpression()
        {
            var list = new List<Expression> { 1, 2, 3 };
            var a = new ArrayExpression(list);

            Assert.IsNotNull(a);
            Assert.IsNotNull(a.Elements);
            Assert.AreEqual(3, a.Elements.Count);
            Assert.AreEqual("[1,2,3];", a.ToString());
        }

        [TestMethod]
        public void ArrayExpressionHandlesNulls()
        {
            var a = JS.Array(1, 2, 3, null);
            Expression b = new object[] {3, 2, 1, null};

            Assert.AreEqual("[1,2,3,null];", a.ToString());
            Assert.AreEqual("[3,2,1,null];", b.ToString());
        }

        [TestMethod]
        public void CanCompareArrayExpressions()
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
        public void ArrayExpressionHasHashCode()
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
