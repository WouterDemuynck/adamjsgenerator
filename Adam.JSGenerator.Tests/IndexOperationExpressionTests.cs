using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Adam.JSGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for IndexOperationExpressionTests
    /// </summary>
    [TestClass]
    public class IndexOperationExpressionTests
    {
        [TestMethod]
        public void IndexOperationExpression_Produces_Index_Operation()
        {
            var identifier = new IndexOperationExpression("a", 3);

            Assert.AreEqual("\"a\"[3]", identifier.ToString(false));
        }

        [TestMethod]
        public void IndexOperationExpression_Produces_Index_Operation_2()
        {
            var identifier = new IndexOperationExpression(null, null);
            identifier.OperandLeft = "a";
            identifier.OperandRight = 3;

            Assert.AreEqual("\"a\"[3]", identifier.ToString(false));
        }

        [TestMethod]
        public void IndexOperationExpression_Refuses_Any_Nulls_1()
        {
            Expect.Throw<InvalidOperationException>(() => JS.Id("a").Index(null).ToString());
            Expect.Throw<InvalidOperationException>(() => new IndexOperationExpression(null, 3).ToString());
        }

        [TestMethod]
        public void IndexOperationExpression_Helpers_Index_Needs_Expression()
        {
            Expression expression = null;

            Expect.Throw<ArgumentNullException>(() => expression.Index(null));
        }
    }
}
