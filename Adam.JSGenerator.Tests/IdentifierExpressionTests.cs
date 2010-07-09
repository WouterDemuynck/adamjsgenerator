using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class IdentifierExpressionTests
    {
        [TestMethod]
        public void IdentifierExpressionProducesIdentifier()
        {
            var id = new IdentifierExpression("test");

            Assert.AreEqual("test", id.Name);
            Assert.AreEqual("test", id.ToString(false));
        }

        [TestMethod]
        public void IdentifierExpressionRefusesReservedWords()
        {
            Expect.Throw<ArgumentException>(() => new IdentifierExpression("var"));
        }

        [TestMethod]
        public void IdentifierExpressionRefusesInvalidIdentifiers()
        {
            var id = new IdentifierExpression("Classname");
            Assert.AreEqual("Classname", id.Name);
            
            id.Name = "Namespace";
            Assert.AreEqual("Namespace", id.Name);

            Expect.Throw<ArgumentException>(() => id.Name = "Namespace.Classname");
        }
    }
}
