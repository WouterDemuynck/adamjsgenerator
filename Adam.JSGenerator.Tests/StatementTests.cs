using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class StatementTests
    {
        [TestMethod]
        public void Statement_Supports_Equals()
        {
            var a = JS.Id("a");
            var b = JS.Id("a");
            var c = JS.Snippet("a");

            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
            Assert.IsFalse(a.Equals(null));
            Assert.IsTrue(a.Equals(a));
        }

        [TestMethod]
        public void Statement_Supports_Hashing()
        {
            var a = JS.Id("a");
            var b = JS.Snippet("a");
                    
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
    }
}
