using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class GenerateJavaScriptOptionsTests
    {
        [TestMethod]
        public void GenerateJavaScriptOptionsHasDefaults()
        {
            GenerateJavaScriptOptions options = GenerateJavaScriptOptions.Default;

            Assert.AreEqual('"', options.PreferredQuoteChar);
            Assert.IsFalse(options.AlwaysQuoteObjectLiteralKeys);
        }

        [TestMethod]
        public void GenerateJavaScriptOptionsCanBeSet()
        {
            GenerateJavaScriptOptions options = new GenerateJavaScriptOptions();

            options.PreferredQuoteChar = '\'';

            Assert.AreEqual('\'', options.PreferredQuoteChar);

            Expect.Throw<ArgumentException>(
                "The preferred quote char can only be one of the allowed quote chars.\r\nParameter name: value",
                () => options.PreferredQuoteChar = '@');
        }

        [TestMethod]
        public void GenerateJavaScriptOptionsHasJson()
        {
            GenerateJavaScriptOptions options = GenerateJavaScriptOptions.Json;

            Assert.AreEqual('"', options.PreferredQuoteChar);
            Assert.IsTrue(options.AlwaysQuoteObjectLiteralKeys);
        }

        [TestMethod]
        public void GenerateJavaScriptOptionsDoesAlwaysQuotingObjecLiteralKeys()
        {
            var literal = JS.Object(new {name = "Dave", function = "Developer"});

            var without = new GenerateJavaScriptOptions {AlwaysQuoteObjectLiteralKeys = false, PreferredQuoteChar = '"'};
            var with = new GenerateJavaScriptOptions {AlwaysQuoteObjectLiteralKeys = true, PreferredQuoteChar = '"'};

            Assert.AreEqual("{name:\"Dave\",\"function\":\"Developer\"};", literal.ToString(true, without));
            Assert.AreEqual("{\"name\":\"Dave\",\"function\":\"Developer\"};", literal.ToString(true, with));
        }
    }
}
