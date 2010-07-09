using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for LabelStatementTests
    /// </summary>
    [TestClass]
    public class LabelStatementTests
    {
        [TestMethod]
        public void Label_Produces_Label()
        {
            var label = new LabelStatement("exit", JS.Return());

            Assert.AreEqual("exit", label.Name);
            Assert.AreEqual("return;", label.Statement.ToString());
            Assert.AreEqual("exit:return;", label.ToString());

            label.Name = "loop";
            label.Statement = JS.For();

            Assert.AreEqual("loop", label.Name);
            Assert.AreEqual("for(;;);", label.Statement.ToString());
            Assert.AreEqual("loop:for(;;);", label.ToString());
        }

        [TestMethod]
        public void Label_Has_Helpers()
        {
            Statement statement = JS.Return();
            var label = statement.Labeled("exit");

            Assert.AreEqual("exit", label.Name);
            Assert.AreEqual("return;", label.Statement.ToString());
            Assert.AreEqual("exit:return;", label.ToString());
        }

        [TestMethod]
        public void Label_Helper_Requires_Statement()
        {
            Statement statement = null;
            Expect.Throw<ArgumentNullException>(() => statement.Labeled(null));
        }
    }
}
