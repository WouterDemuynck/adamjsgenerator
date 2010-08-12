using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class IndexOperationExpressionTests
    {
        [TestMethod]
        public void IndexOperationExpressionProducesIndexOperation()
        {
            var identifier = new IndexOperationExpression("a", 3);

            Assert.AreEqual("\"a\"[3];", identifier.ToString());
        }

        [TestMethod]
        public void IndexOperationExpressionProducesIndexOperation2()
        {
            var identifier = new IndexOperationExpression(null, null);
            identifier.OperandLeft = "a";
            identifier.OperandRight = 3;

            Assert.AreEqual("\"a\"[3];", identifier.ToString());
        }

        [TestMethod]
        public void IndexOperationExpressionHasHelpers()
        {
            var expression = JS.String("Hello, World!").Index(2);

            Assert.AreEqual("\"Hello, World!\"[2];", expression.ToString());
        }

        [TestMethod]
        public void IndexOperationExpressionRefusesAnyNulls1()
        {
            Expect.Throw<InvalidOperationException>(() => JS.Id("a").Index(null).ToString());
            Expect.Throw<InvalidOperationException>(() => new IndexOperationExpression(null, 3).ToString());
        }

        [TestMethod]
        public void IndexOperationExpressionHelpersIndexNeedsExpression()
        {
            Expression expression = null;

            Expect.Throw<ArgumentNullException>(() => expression.Index(null));
        }
    }
}
