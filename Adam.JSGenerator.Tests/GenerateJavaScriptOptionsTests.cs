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
            GenerateJavaScriptOptions options = new GenerateJavaScriptOptions();

            Assert.AreEqual('"', options.PreferredQuoteChar);
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
    }
}
