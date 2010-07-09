using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ScriptTests
    {
        [TestMethod]
        public void Script_Produces_Statements()
        {
            var a = JS.Id("a");
            Script script1 = new Script
            {
                JS.Var(a),
                {
                    JS.For(a.AssignWith(3), a.IsGreaterThan(0), a.PreDecrement())
                        .With(JS.Alert(a)), 
                    JS.Return(a)
                }
            };

            Assert.AreEqual(3, script1.Statements.Count);
            Assert.AreEqual("var a;for(a=3;a>0;--a)alert(a);return a;", script1.ToString());

            Script script2 = new Script();


            script2.Add(script1);   

            Assert.AreEqual("var a;for(a=3;a>0;--a)alert(a);return a;", script2.ToString());
        }

        [TestMethod]
        public void Script_Implements_IEnumerable()
        {
            Script script = new Script();

            Assert.IsInstanceOfType(((IEnumerable<Statement>)script).GetEnumerator(), typeof(IEnumerator<Statement>));
            Assert.IsInstanceOfType(((IEnumerable)script).GetEnumerator(), typeof(IEnumerator));
        }
    }
}
