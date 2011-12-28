using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming
namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class RegressionTests
    {
        [TestMethod]
        public void Item_10_StrangeOutputWithDoublesInArraysInSomeLocales()
        {
            var expression = JS.Var(JS.Id("blah")).AssignWith(new[] { 390.53466354643, 2.6 });

            Assert.AreEqual("var blah=[390.53466354643,2.6];", expression.ToString());
        }
    }
}
// ReSharper restore InconsistentNaming
