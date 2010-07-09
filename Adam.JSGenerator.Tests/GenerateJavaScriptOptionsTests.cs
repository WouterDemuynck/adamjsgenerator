using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for GenerateJavaScriptOptionsTests
    /// </summary>
    [TestClass]
    public class GenerateJavaScriptOptionsTests
    {
        [TestMethod]
        public void GenerateJavaScriptOptions_Has_Defaults()
        {
            GenerateJavaScriptOptions options = new GenerateJavaScriptOptions();

            Assert.AreEqual('"', options.PreferredQuoteChar);
        }

        [TestMethod]
        public void GenerateJavaScriptOptions_Can_Be_Set()
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
