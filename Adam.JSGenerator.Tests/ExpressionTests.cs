using System.Collections.Generic;
using System.Linq;
using Adam.JSGenerator.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void ExpressionProducesLiterals()
        {
            var l = (IEnumerable<Expression>)new List<Expression> { 1, 2, 3.14, "Test", true, null };
            var s = new Script(l);

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
            Expression arr = new[] {1, 2, 3};

            Assert.AreEqual("true;", t.ToString());
            Assert.AreEqual("false;", f.ToString());
            Assert.AreEqual("5;", i.ToString());
            Assert.AreEqual("3.14;", d.ToString());
            Assert.AreEqual("\"Hello, World!\";", s.ToString());
            Assert.AreEqual("[1,2,3];", arr.ToString());
        }

        [TestMethod]
        public void ExpressionHasExplicitConversion()
        {
            Expression t = Expression.FromBoolean(true);
            Expression f = Expression.FromBoolean(false);
            Expression i = Expression.FromInteger(5);
            Expression d = Expression.FromDouble(3.14);
            Expression s = Expression.FromString("Hello, World!");
            Expression arr = Expression.FromArray(new[] { 1, 2, 3 });

            Assert.AreEqual("true;", t.ToString());
            Assert.AreEqual("false;", f.ToString());
            Assert.AreEqual("5;", i.ToString());
            Assert.AreEqual("3.14;", d.ToString());
            Assert.AreEqual("\"Hello, World!\";", s.ToString());
            Assert.AreEqual("[1,2,3];", arr.ToString());
        }

        [TestMethod]
        public void ExpressionSupportsConversionOfDictionariesIntoObjectLiterals()
        {
            var dictionary = new Dictionary<string, int>
                {{"One", 1}, {"Two", 2}};
            var expression1 = Expression.FromObject(dictionary);

            Assert.AreEqual("{One:1,Two:2};", expression1.ToString());

            const string text = "The brown for jumps over the lazy dog.";
            Dictionary<string, int> words = text.Split(' ').ToDictionary(
                item => item,
                item => item.Length);
            var expression2 = Expression.FromObject(words);

            Assert.AreEqual("{The:3,brown:5,for:3,jumps:5,over:4,the:3,lazy:4,\"dog.\":4};", expression2.ToString());

            FakeDictionary<string, bool> fake = new FakeDictionary<string, bool>
            {
                { "yes", true },
                { "no", false }
            };

            var expression3 = Expression.FromObject(fake);
            Assert.AreEqual("{yes:true,no:false};", expression3.ToString());
        }

        [TestMethod]
        public void ExpressionSupportsWrappingInScriptBlock()
        {
            var expression = JS.Var(JS.Id("pi").AssignWith(3.1415));

            Assert.AreEqual("var pi=3.1415;", expression.ToString());
            Assert.AreEqual("<script type=\"text/javascript\">var pi=3.1415;</script>", 
                expression.ToString(true, new ScriptOptions { WrapInScriptBlock = true }, false));            
        }
    }
}
