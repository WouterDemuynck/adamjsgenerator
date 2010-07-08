using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adam.JSGenerator;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for NumberExpressionTests
    /// </summary>
    [TestClass]
    public class NumberExpressionTests
    {
        [TestMethod]
        public void NumberExpression_Produces_Numbers()
        {
            NumberExpression n1 = new NumberExpression(1.0);
            NumberExpression n2 = new NumberExpression(12);
            NumberExpression n3 = new NumberExpression(0.5);
            NumberExpression n4 = new NumberExpression(-58);

            Assert.AreEqual("1;", n1.ToString());
            Assert.AreEqual("12;", n2.ToString());
            Assert.AreEqual("0.5;", n3.ToString());
            Assert.AreEqual("-58;", n4.ToString());

            n4.Value = n4.Value + 1;

            Assert.AreEqual("-57;", n4.ToString());
        }
    }
}
