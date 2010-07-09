using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for IdentifierExpressionTests
    /// </summary>
    [TestClass]
    public class IdentifierExpressionTests
    {
        [TestMethod]
        public void IdentifierExpression_Produces_Identifier()
        {
            var id = new IdentifierExpression("test");

            Assert.AreEqual("test", id.Name);
            Assert.AreEqual("test", id.ToString(false));
        }

        [TestMethod]
        public void IdentifierExpression_Refuses_Reserved_Words()
        {
            Expect.Throw<ArgumentException>(() => new IdentifierExpression("var"));
        }

        [TestMethod]
        public void IdentifierExpression_Refuses_Invalid_Identifiers()
        {
            var id = new IdentifierExpression("Classname");
            Assert.AreEqual("Classname", id.Name);
            
            id.Name = "Namespace";
            Assert.AreEqual("Namespace", id.Name);

            Expect.Throw<ArgumentException>(() => id.Name = "Namespace.Classname");
        }
    }
}
