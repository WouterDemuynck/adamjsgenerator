using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void ExpressionProducesLiterals()
        {
            var l = new List<Expression> { 1, 2, 3.14, "Test", true, null };
            var s = new Script(l.Cast<Statement>());

            Assert.AreEqual("1;2;3.14;\"Test\";true;;", s.ToString());
        }

        [TestMethod]
        public void ExpressionAllowsNullInVariousPlaces()
        {
            var v = JS.Id("v").AssignWith(null);
            var d = JS.Var(v);
            var c = JS.If(JS.Id("v").IsNotEqualTo(null)).Then(v);
            var u = JS.Not(null);

            Assert.AreEqual("var v=null;", d.ToString());
            Assert.AreEqual("if(v!=null)v=null;", c.ToString());
            Assert.AreEqual("!null;", u.ToString());
        }

        [TestMethod]
        public void ExpressionHasImplicitConversion()
        {
            Expression t = true;
            Expression f = false;
            Expression i = 5;
            Expression d = 3.14;
            Expression s = "Hello, World!";

            Assert.AreEqual("true;", t.ToString());
            Assert.AreEqual("false;", f.ToString());
            Assert.AreEqual("5;", i.ToString());
            Assert.AreEqual("3.14;", d.ToString());
            Assert.AreEqual("\"Hello, World!\";", s.ToString());
        }

        [TestMethod]
        public void ExpressionHasExplicitConversion()
        {
            Expression t = Expression.FromBoolean(true);
            Expression f = Expression.FromBoolean(false);
            Expression i = Expression.FromInteger(5);
            Expression d = Expression.FromDouble(3.14);
            Expression s = Expression.FromString("Hello, World!");

            Assert.AreEqual("true;", t.ToString());
            Assert.AreEqual("false;", f.ToString());
            Assert.AreEqual("5;", i.ToString());
            Assert.AreEqual("3.14;", d.ToString());
            Assert.AreEqual("\"Hello, World!\";", s.ToString());            
        }
    }
}
