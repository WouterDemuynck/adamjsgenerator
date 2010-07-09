using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class LabelStatementTests
    {
        [TestMethod]
        public void LabelProducesLabel()
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
        public void LabelHasHelpers()
        {
            Statement statement = JS.Return();
            var label = statement.Labeled("exit");

            Assert.AreEqual("exit", label.Name);
            Assert.AreEqual("return;", label.Statement.ToString());
            Assert.AreEqual("exit:return;", label.ToString());
        }

        [TestMethod]
        public void LabelHelperRequiresStatement()
        {
            Statement statement = null;
            Expect.Throw<ArgumentNullException>(() => statement.Labeled(null));
        }
    }
}
