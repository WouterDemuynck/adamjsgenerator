using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adam.JSGenerator;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class StringExpressionTests
    {
        [TestMethod]
        public void StringExpression_Produces_Empty_String()
        {
            var s = new StringExpression();

            Assert.AreEqual("\"\";", s.ToString());
        }

        [TestMethod]
        public void StringExpression_Produces_String_Through_Constructor()
        {
            string[] strings = new [] { "one", "two", "three" };

            StringExpression expression;

            foreach (var s in strings)
            {
                expression = new StringExpression(s);

                Assert.AreEqual("\"" + s + "\";", expression.ToString());
            }

            expression = new StringExpression();

            foreach (var s in strings)
            {
                expression.Value = s;

                Assert.AreEqual(s, expression.Value);
            }
        }
    }
}
