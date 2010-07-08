using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adam.JSGenerator;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class SnippetExpressionTests
    {
        [TestMethod]
        public void SnippetExpression_Produces_Snippet()
        {
            SnippetExpression expression = new SnippetExpression("yay!");

            Assert.AreEqual("yay!;", expression.ToString());
        }

        [TestMethod]
        public void SnippetExpresson_Has_Property()
        {
            SnippetExpression expression = new SnippetExpression("");

            expression.Value = "3";

            Assert.AreEqual("3", expression.Value);
        }
    }
}
