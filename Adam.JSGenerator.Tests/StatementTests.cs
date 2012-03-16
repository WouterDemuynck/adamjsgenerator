using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class StatementTests
    {
        // ReSharper disable EqualExpressionComparison
        [TestMethod]
        public void StatementSupportsEquals()
        {
            var a = JS.Id("a");
            var b = JS.Id("a");
            var c = JS.Expression("a");

            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
            Assert.IsFalse(a.Equals(null));
            Assert.IsTrue(a.Equals(a));
        }
        // ReSharper restore EqualExpressionComparison

        [TestMethod]
        public void StatementSupportsHashing()
        {
            var a = JS.Id("a");
            var b = JS.Snippet("a");
                    
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
    }
}
