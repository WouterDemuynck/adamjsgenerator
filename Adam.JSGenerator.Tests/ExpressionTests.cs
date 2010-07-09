using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for Expression.
    /// </summary>
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void Expression_Produces_Literals()
        {
            var l = new List<Expression> { 1, 2, 3.14, "Test", true, null };
            var s = new Script(l.Cast<Statement>());

            Assert.AreEqual("1;2;3.14;\"Test\";true;;", s.ToString());
        }

        [TestMethod]
        public void Expression_Allows_Null_In_Various_Places()
        {
            var v = JS.Id("v").AssignWith(null);
            var d = JS.Var(v);
            var c = JS.If(JS.Id("v").IsNotEqualTo(null)).Then(v);
            var u = JS.Not(null);

            Assert.AreEqual("var v=null;", d.ToString());
            Assert.AreEqual("if(v!=null)v=null;", c.ToString());
            Assert.AreEqual("!null;", u.ToString());
        }
    }
}
