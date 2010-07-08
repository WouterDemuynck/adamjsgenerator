using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adam.JSGenerator;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for NullExpressionTests
    /// </summary>
    [TestClass]
    public class NullExpressionTests
    {
        [TestMethod]
        public void NullExpression_Produces_Null()
        {
            var expression = new NullExpression();

            Assert.AreEqual("null;", expression.ToString());
        }
    }
}
