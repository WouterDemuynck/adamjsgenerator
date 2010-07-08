using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adam.JSGenerator;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for CollectionHelpersTests
    /// </summary>
    [TestClass]
    public class CollectionHelpersTests
    {
        [TestMethod]
        public void WithConvertedNulls_Requires_Expressions()
        {
            IEnumerable<Expression> enumerable = null;
            Expect.Throw<ArgumentNullException>(() => enumerable.WithConvertedNulls());
        }

        [TestMethod]
        public void WithConvertedNulls_Requires_Statements()
        {
            IEnumerable<Statement> enumerable = null;
            Expect.Throw<ArgumentNullException>(() => enumerable.WithConvertedNulls());
        }

        [TestMethod]
        public void WithConvertedNulls_Converts_Into_EmptyStatements()
        {
            IEnumerable<Statement> enumerable = new Statement[] { JS.Null(), null, JS.Return() };
            var converted = enumerable.WithConvertedNulls().ToArray();

            Assert.AreEqual(3, converted.Length);
            Assert.AreEqual("null;", converted[0].ToString());
            Assert.AreEqual(";", converted[1].ToString());
            Assert.AreEqual("return;", converted[2].ToString());
        }

        [TestMethod]
        public void WithConvertedNulls_Converts_Into_NullExpressions()
        {
            IEnumerable<Expression> enumerable = new Expression[] { JS.Id("a"), null, JS.Number(5) };
            var converted = enumerable.WithConvertedNulls().ToArray();

            Assert.AreEqual(3, converted.Length);
            Assert.AreEqual("a;", converted[0].ToString());
            Assert.AreEqual("null;", converted[1].ToString());
            Assert.AreEqual("5;", converted[2].ToString());
        }
    }
}
