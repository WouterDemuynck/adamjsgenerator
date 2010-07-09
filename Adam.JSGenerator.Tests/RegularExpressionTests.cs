using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class RegularExpressionTests
    {
        [TestMethod]
        public void RegularExpressionProducesRegularExpression()
        {
            var expression = new RegularExpression("/regularexpression/i");

            Assert.AreEqual("/regularexpression/i", expression.Value);
            Assert.AreEqual("/regularexpression/i;", expression.ToString());

            expression.Value = "/reg/";

            Assert.AreEqual("/reg/;", expression.ToString());
        }

        [TestMethod]
        public void RegularExpressionRequiresExpression()
        {
            var expression = new RegularExpression(null);

            Expect.Throw<InvalidOperationException>(() => expression.ToString());
        }

    }
}
