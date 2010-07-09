using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ReturnStatementTests
    {
        [TestMethod]
        public void ReturnStatement_Produces_Return_Without_Value()
        {
            var statement = new ReturnStatement();

            Assert.AreEqual("return;", statement.ToString());
        }

        [TestMethod]
        public void ReturnStatement_Produces_Return_With_Value()
        {
            var statement = new ReturnStatement(3);

            Assert.AreEqual(3, statement.Value);
            Assert.AreEqual("return 3;", statement.ToString());

            statement.Value = "Yes!";

            Assert.AreEqual("return \"Yes!\";", statement.ToString());
        }
    }
}
