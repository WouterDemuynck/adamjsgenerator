using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class JavaScriptTests
    {
        private class TestObject
        {
            public int Value { get; set; }
            public string Display { get; set; }
            public object Test { get; set; }
        }

        [TestMethod]
        public void CharactersAreConvertedToUnicodeSequences()
        {
            Assert.AreEqual(@"\u0009", JS.CharToUnicode('\t'));
            Assert.AreEqual(@"\u0020", JS.CharToUnicode(' '));
            Assert.AreEqual(@"\u000d", JS.CharToUnicode('\r'));
            Assert.AreEqual(@"\u000a", JS.CharToUnicode('\n'));
            Assert.AreEqual(@"\u005c", JS.CharToUnicode('\\'));
        }

        [TestMethod]
        public void FindsMostSuitableQuoteCharFindsMostSuitableCharacter()
        {
            const char s = '\'';
            const char d = '"';
            const char def = s;

            Assert.IsTrue(JS.FindMostSuitableQuoteChar("abcde") == def);        // No quotes means default.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a'bcde") == d);         // Single quote means double.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("abcd\"e") == s);        // Double quote means single.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a'bcd\"e") == def);     // Both means default.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a''bcd\"e") == d);      // More single than double means double.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a'bcd\"\"e") == s);     // More double than single means single.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a''bcd\"\"e") == def);  // Equal count means default.
        }

        [TestMethod]
        public void FindsMostSuitableQuoteCharRequiresSequence()
        {
            Expect.Throw<ArgumentNullException>(() => JS.FindMostSuitableQuoteChar(null));
        }

        [TestMethod]
        public void QuoteStringReturnsQuotedStrings()
        {
            Assert.AreEqual("'hey there!'", JS.QuoteString("hey there!"));
            Assert.AreEqual("\"'It's \\\"time\\\"!', she said.\"", JS.QuoteString("'It's \"time\"!', she said."));
            Assert.AreEqual(@"'\b\t\n\f\r\u0007'", JS.QuoteString("\b\t\n\f\r\a"));
            Assert.AreEqual(@"'one\\ntwo'", JS.QuoteString(@"one\ntwo"));
            Assert.AreEqual(@"'\u003chtml\u003e'", JS.QuoteString("<html>"));
        }

        [TestMethod]
        public void QuoteStringRequiresSource()
        {
            Expect.Throw<ArgumentNullException>(() => JS.QuoteString(null, '"'));
        }

        [TestMethod]
        public void SomeIdentifiersAreValid()
        {
            Assert.IsTrue(JS.IsValidIdentifier("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ$_0123456789"));
        }

        [TestMethod]
        public void SomeIdentifiersAreInvalid()
        {
            Assert.IsFalse(JS.IsValidIdentifier("0foo")); // Identifiers cannot start with a number.
            Assert.IsFalse(JS.IsValidIdentifier("")); // Identifiers cannot be empty.
            Assert.IsFalse(JS.IsValidIdentifier("&")); // Identifiers cannot contain all characters.
            Assert.IsFalse(JS.IsValidIdentifier("break"));
            Assert.IsFalse(JS.IsValidIdentifier("debugger")); // Identifiers cannot be a reserved word.
        }

        [TestMethod]
        public void GetValuesGetsValuesFromNull()
        {
            var result = JS.GetValues(null);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetValuesGetsValuesFromEmptyObject()
        {
            var result = JS.GetValues(new object());

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetValuesGetsValuesFromAnonymousObject()
        {
            object o = new { value = 1, @var = "One" };

            var result = JS.GetValues(o);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IDictionary<Expression, Expression>));

            Assert.IsTrue(result.ContainsKey(JS.Id("value")));
            Assert.AreEqual(JS.Number(1), result[JS.Id("value")]);
            Assert.IsTrue(result.ContainsKey(JS.String("var")));
            Assert.AreEqual(JS.String("One"), result[JS.String("var")]);
        }

        [TestMethod]
        public void GetValuesGetsValuesFromNormalObject()
        {
            TestObject o = new TestObject { Value = 1, Display = "One", Test = null };

            var result = JS.GetValues(o);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IDictionary<Expression, Expression>));

            Assert.IsTrue(result.ContainsKey(JS.Id("Value")));
            Assert.AreEqual(result[JS.Id("Value")], Expression.FromInteger(o.Value));
            Assert.IsTrue(result.ContainsKey(JS.Id("Display")));
            Assert.AreEqual(result[JS.Id("Display")], Expression.FromString(o.Display));
            Assert.IsTrue(result.ContainsKey(JS.Id("Test")));
            Assert.AreEqual(result[JS.Id("Test")], JS.Null());
        }

        [TestMethod]
        public void ObjectGetsComplicatedObject()
        {
            var obj = new
            {
                First = "1",
                Second = JS.Function(),
                Third = new[] { new[] { 1, 2, 3 } },
                Fourth = new TestObject()
            };

            var literal = JS.Object(obj);

            Assert.AreEqual("{First:\"1\",Second:function(){},Third:[[1,2,3]],Fourth:{Value:0,Display:null,Test:null}};",
                literal.ToString());
        }

        [TestMethod]
        public void MultipleGetsNull()
        {
            var o = JS.Multiple();

            Assert.IsNull(o);
        }

        [TestMethod]
        public void MultipleGetsSingle()
        {
            var a = JS.Id("a");
            var o = JS.Multiple(a);

            Assert.AreEqual("a;", o.ToString());
        }

        [TestMethod]
        public void MultipleGetsMultiple()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var c = JS.Id("c");

            var o = JS.Multiple(a, b, c);

            Assert.AreEqual("a,b,c;", o.ToString());
        }

        [TestMethod]
        public void BlockOrStatementReturnsEmpty()
        {
            var block = JS.BlockOrStatement();

            Assert.AreEqual(";", block.ToString());
        }

        [TestMethod]
        public void BlockOrStatementReturnsStatement()
        {            
            var block = JS.BlockOrStatement(JS.Return());

            Assert.AreEqual("return;", block.ToString());
        }

        [TestMethod]
        public void BlockOrStatementReturnsBlock()
        {
            var block = JS.BlockOrStatement(JS.Null(), JS.Return());

            Assert.AreEqual("{null;return;}", block.ToString());
        }

        [TestMethod]
        public void ParseIdParsesSimpleId()
        {
            var id = JS.ParseId("Adam");

            Assert.AreEqual("Adam;", id.ToString());
        }

        [TestMethod]
        public void ParseIdParsesMultipleIds()
        {
            var id = JS.ParseId("Adam.Controls");

            Assert.AreEqual("Adam.Controls;", id.ToString());
        }

        [TestMethod]
        public void ParseIdRejectsWrongIds()
        {
            Expect.Throw<ArgumentException>(() => JS.ParseId("Adam.Controls@"));
        }

        [TestMethod]
        public void ArrayReturnsEmptyArray()
        {
            var arr = JS.Array();

            Assert.AreEqual("[];", arr.ToString());
        }

        [TestMethod]
        public void ArrayReturnsArrayWithInts()
        {
            var arr = JS.Array(1, 2, 3);

            Assert.AreEqual("[1,2,3];", arr.ToString());
        }

        [TestMethod]
        public void ArrayReturnsArrayWithStrings()
        {
            var arr = JS.Array(new List<Expression> { "One", "Two", "Three" } );

            Assert.AreEqual("[\"One\",\"Two\",\"Three\"];", arr.ToString());
        }

        [TestMethod]
        public void ArrayReturnsArrayWithNestedArrays()
        {
            var arr = JS.Array(1, 2, JS.Array(3, 4));

            Assert.AreEqual("[1,2,[3,4]];", arr.ToString());
        }

        [TestMethod]
        public void BlockReturnsEmptyBlock()
        {
            var block = JS.Block();

            Assert.AreEqual("{}", block.ToString());
        }

        [TestMethod]
        public void BlockReturnsBlock1()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var c = JS.Id("c");
            var block = JS.Block(a, b, c);

            Assert.AreEqual("{a;b;c;}", block.ToString());
        }

        [TestMethod]
        public void BlockReturnsBlock2()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var c = JS.Id("c");
            var block = JS.Block(new List<Statement> { a, b, c });

            Assert.AreEqual("{a;b;c;}", block.ToString());
        }

        [TestMethod]
        public void BreakReturnsBreak()
        {
            var b = JS.Break();

            Assert.AreEqual("break;", b.ToString());
        }

        [TestMethod]
        public void BreakReturnsBreakWithLabel()
        {
            var b = JS.Break("a");

            Assert.AreEqual("break a;", b.ToString());
        }

        [TestMethod]
        public void ContinueReturnsContinue()
        {
            var c = JS.Continue();

            Assert.AreEqual("continue;", c.ToString());
        }

        [TestMethod]
        public void ContinueReturnsContinueWithLabel()
        {
            var c = JS.Continue("c");

            Assert.AreEqual("continue c;", c.ToString());
        }

        [TestMethod]
        public void DeleteReturnsDelete()
        {
            var d = JS.Delete(JS.Id("a"));

            Assert.AreEqual("delete a;", d.ToString());
        }

        [TestMethod]
        public void DoReturnsDoWhileWithSingleStatement()
        {
            var dw = JS.Do(JS.Null()).While(JS.Null());

            Assert.AreEqual("do null;while(null);", dw.ToString());
        }

        [TestMethod]
        public void DoReturnsDoWhileWithMultipleStatement()
        {
            var dw = JS.Do(new List<Statement> { JS.Null(), JS.Null() }).While(JS.Null());

            Assert.AreEqual("do {null;null;}while(null);", dw.ToString());
        }

        [TestMethod]
        public void EmptyReturnsEmptyStatement()
        {
            var e = JS.Empty();

            Assert.AreEqual(";", e.ToString());
        }

        [TestMethod]
        public void FindReturnsFind()
        {
            var f = JS.Find("a");

            Assert.AreEqual("$find(\"a\");", f.ToString());
        }

        [TestMethod]
        public void ForReturnsForIn()
        {
            var f = JS.For(JS.Var(JS.Id("a"))).In(JS.Array());

            Assert.AreEqual("for(var a in []);", f.ToString());
        }

        [TestMethod]
        public void ForReturnsEternalLoop()
        {
            var f = JS.For();

            Assert.AreEqual("for(;;);", f.ToString());
        }

        [TestMethod]
        public void ForReturnsForWithIteration()
        {
            var f = JS.For(JS.Id("a").PreIncrement());

            Assert.AreEqual("for(;;++a);", f.ToString());
        }

        [TestMethod]
        public void ForReturnsForWithConditionAndIteration()
        {
            var a = JS.Id("a");
            var f = JS.For(a.IsGreaterThan(0), a.PreDecrement());

            Assert.AreEqual("for(;a>0;--a);", f.ToString());
        }

        [TestMethod]
        public void ForReturnsForWithInitializationConditionAndIteration()
        {
            var a = JS.Id("a");
            var f = JS.For(JS.Var(a.AssignWith(10)), a.IsGreaterThan(0), a.PreDecrement());

            Assert.AreEqual("for(var a=10;a>0;--a);", f.ToString());
        }

        [TestMethod]
        public void FunctionReturnsEmptyAnonymousFunction()
        {
            var f = JS.Function();

            Assert.AreEqual("function(){};", f.ToString());
        }

        [TestMethod]
        public void FunctionReturnsFunctionWithName()
        {
            var f = JS.Function("a");

            Assert.AreEqual("function a(){};", f.ToString());
        }

        [TestMethod]
        public void FunctionReturnsFunctionWithBody()
        {
            var f = JS.Function().Do(JS.Null());

            Assert.AreEqual("function(){null;};", f.ToString());
        }

        [TestMethod]
        public void FunctionReturnsFunctionWithParameters()
        {
            var a = JS.Id("a");
            var f = JS.Function().Parameters(a).Do(a.Call());

            Assert.AreEqual("function(a){a();};", f.ToString());
        }

        [TestMethod]
        public void GetReturnsGet()
        {
            var g = JS.Get("a");

            Assert.AreEqual("$get(\"a\");", g.ToString());
        }

        [TestMethod]
        public void GroupReturnsGroup()
        {
            var g = JS.Group("a");

            Assert.AreEqual("(\"a\");", g.ToString());
        }

        [TestMethod]
        public void IdReturnsIdentifier()
        {
            var i = JS.Id("a");

            Assert.AreEqual("a;", i.ToString());
        }

        [TestMethod]
        public void IdRejectsBadIdentifiers()
        {
            Expect.Throw<ArgumentException>(() => JS.Id("nO!"));
        }

        [TestMethod]
        public void IfReturnsIf()
        {
            var i = JS.If(JS.Null());

            Assert.AreEqual("if(null);", i.ToString());
        }

        [TestMethod]
        public void IfReturnsIfThen()
        {
            var i = JS.If(JS.Null()).Then(JS.Null());

            Assert.AreEqual("if(null)null;", i.ToString());
        }

        [TestMethod]
        public void IfReturnsIfElse()
        {
            var i = JS.If(JS.Null()).Else(JS.Null());

            Assert.AreEqual("if(null); else null;", i.ToString());
        }

        [TestMethod]
        public void IfReturnsIfThenElse()
        {
            var i = JS.If(JS.Null()).Then(JS.Null()).Else(JS.Null());

            Assert.AreEqual("if(null)null; else null;", i.ToString());
        }

        [TestMethod]
        public void LabelReturnsLabel()
        {
            var l = JS.Label("l", JS.Empty());

            Assert.AreEqual("l:;", l.ToString());
        }

        [TestMethod]
        public void NumberReturnsInteger()
        {
            var i = JS.Number(10);

            Assert.AreEqual("10;", i.ToString());
        }

        [TestMethod]
        public void NumberReturnsDouble()
        {
            var d = JS.Number(3.14);

            Assert.AreEqual("3.14;", d.ToString());
        }

        [TestMethod]
        public void StringReturnsString()
        {
            var s = JS.String("test");

            Assert.AreEqual("\"test\";", s.ToString());
        }

        [TestMethod]
        public void BooleanReturnsBoolean()
        {
            var t = JS.Boolean(true);
            var f = JS.Boolean(false);

            Assert.AreEqual("true;", t.ToString());
            Assert.AreEqual("false;", f.ToString());
        }

        [TestMethod]
        public void MultipleReturnsMultipleEvaluation()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var c = JS.Id("c");

            var m = JS.Multiple(a.PostIncrement(), b.IsGreaterThan(10), c.AddWith(5).AndAssign());
            
            Assert.AreEqual("a++,b>10,c+=5;", m.ToString());
        }

        [TestMethod]
        public void NewReturnsNewObject()
        {
            var n = JS.New(JS.Id("Class"));

            Assert.AreEqual("new Class();", n.ToString());
        }

        [TestMethod]
        public void NewReturnsNewObjectWithParameters()
        {
            var n1 = JS.New(JS.Id("Class"), new List<Expression> { "div", "p", 2 });
            var n2 = JS.New(JS.Id("Class"), "div", "p", 2);

            Assert.AreEqual("new Class(\"div\",\"p\",2);", n1.ToString());
            Assert.AreEqual("new Class(\"div\",\"p\",2);", n2.ToString());
        }

        [TestMethod]
        public void NotReturnsLogicalNot()
        {
            var n = JS.Not(true);

            Assert.AreEqual("!true;", n.ToString());
        }

        [TestMethod]
        public void NullReturnsNull()
        {
            var n = JS.Null();

            Assert.AreEqual("null;", n.ToString());
        }

        [TestMethod]
        public void ObjectReturnsEmptyObject()
        {
            var o = JS.Object();

            Assert.AreEqual("{};", o.ToString());
        }

        [TestMethod]
        public void ObjectReturnsObjectFromAnonymousObject()
        {
            var o = JS.Object(new { mother = 1, judge = "mother", speed = JS.Array(1, 2, 3) });

            Assert.AreEqual("{mother:1,judge:\"mother\",speed:[1,2,3]};", o.ToString());
        }

        [TestMethod]
        public void ObjectReturnsObjectFromDictionary()
        {
            var dictionary = new Dictionary<Expression, Expression>();
            dictionary["a"] = "b";

            var o = JS.Object(dictionary);

            Assert.AreEqual("{\"a\":\"b\"};", o.ToString());
        }

        [TestMethod]
        public void ObjectReturnsObjectFromAnonymousObjectWithNestedAnonymousObject()
        {
            var o = JS.Object(new
            {
                mother = 1, 
                judge = "mother", 
                speed = new
                {
                    first = "gear", 
                    second = Guid.Empty, 
                    third = false
                }
            });

            Assert.AreEqual("{mother:1,judge:\"mother\",speed:{first:\"gear\",second:\"00000000-0000-0000-0000-000000000000\",third:false}};", o.ToString());            
        }

        [TestMethod]
        public void ObjectReturnsObjectFromAnonymousObjectWithNestedAnonymousObjectArray()
        {
            var o = JS.Object(new
            {
                signals = new[]
                {
                    new { type = 1, message = "a" },
                    new { type = 2, message = "b" }
                }
            });

            Assert.AreEqual("{signals:[{type:1,message:\"a\"},{type:2,message:\"b\"}]};", o.ToString());
        }

        [TestMethod]
        public void ObjectReturnsObjectFromAnonymousObjectWithNestedArray()
        {
            var o = JS.Object(new
            {
                signals = JS.Array(1, 2, 3)
            });

            Assert.AreEqual("{signals:[1,2,3]};", o.ToString());
        }

        [TestMethod]
        public void RegexReturnsLiteralExpression()
        {
            var r = JS.Regex(@"/\d+/g");

            Assert.AreEqual(@"/\d+/g;", r.ToString());
        }

        [TestMethod]
        public void ReturnReturnsReturnStatement()
        {
            var r = JS.Return();

            Assert.AreEqual("return;", r.ToString());
        }

        [TestMethod]
        public void ReturnReturnsReturnStatementWithValue()
        {
            var r = JS.Return("a");

            Assert.AreEqual("return \"a\";", r.ToString());
        }

        [TestMethod]
        public void ScriptReturnsEmptyScript()
        {
            var s = JS.Script();

            Assert.AreEqual("", s.ToString());
        }

        [TestMethod]
        public void ScriptReturnsScriptWithStatements()
        {
            var s = JS.Script(new List<Statement> { JS.Empty(), JS.Return(JS.Null()) });

            Assert.AreEqual(";return null;", s.ToString());
        }

        [TestMethod]
        public void SnippetReturnsLiteral()
        {
            var s = JS.Snippet("blah blah blah");

            Assert.AreEqual("blah blah blah;", s.ToString());
        }

        [TestMethod]
        public void SwitchReturnsEmptySwitch()
        {
            var s = JS.Switch(JS.Id("a"));

            Assert.AreEqual("switch(a){}", s.ToString());
        }

        [TestMethod]
        public void SwitchReturnsSwitchWithDefault()
        {
            var s = JS.Switch(JS.Id("a"))
                .Default().Do(
                    JS.Return());

            Assert.AreEqual("switch(a){default:return;}", s.ToString());
        }

        [TestMethod]
        public void SwitchReturnsSwitchWithCases()
        {
            var s = JS.Switch(JS.Id("a"))
                .Case(1).Do(
                    JS.Id("alert").Call("moo!"),
                    JS.Break())
                .Case(2, 3, 4).Do(
                    JS.Id("alert").Call("cow!"),
                    JS.Break());

            Assert.AreEqual("switch(a){case 1:alert(\"moo!\");break;case 2:case 3:case 4:alert(\"cow!\");break;}", s.ToString());
        }

        [TestMethod]
        public void ThrowReturnsThrowStatement()
        {
            var t = JS.Throw("error");

            Assert.AreEqual("throw \"error\";", t.ToString());
        }

        [TestMethod]
        public void TryReturnsExceptionHandlingStatement()
        {
            var a = JS.Id("a");
            var alert = JS.Id("alert");

            var t = JS.Try(JS.Return()).Catch(a, alert.Call(a)).Finally(alert.Call("done!"));

            Assert.AreEqual("try{return;}catch(a){alert(a);}finally{alert(\"done!\");}", t.ToString());
        }

        [TestMethod]
        public void TryReturnsExceptionHandlingStatement2()
        {
            var a = JS.Id("a");
            var alert = JS.Id("alert");

            var t = JS.Try(new List<Statement> { JS.Return() }).Catch(a, alert.Call(a)).Finally(alert.Call("done!"));

            Assert.AreEqual("try{return;}catch(a){alert(a);}finally{alert(\"done!\");}", t.ToString());
        }

        [TestMethod]
        public void VarReturnsDeclarationExpression()
        {
            var a = JS.Id("a");
            var v = JS.Var(a);

            Assert.AreEqual("var a;", v.ToString());
        }

        [TestMethod]
        public void VarReturnsDeclarationExpressionWithMultipleExpressions()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var v = JS.Var(new List<Expression> { a.AssignWith(5), b.AssignWith(6) });

            Assert.AreEqual("var a=5,b=6;", v.ToString());
        }


        [TestMethod]
        public void VarReturnsDeclarationExpressionWithInitialization()
        {
            var a = JS.Id("a");
            var v = JS.Var(a.AssignWith(10));

            Assert.AreEqual("var a=10;", v.ToString());
        }

        [TestMethod]
        public void WhileReturnsWhileStatement()
        {
            var a = JS.Id("a");
            var w = JS.While(a.IsGreaterThan(0)).Do(a.PostDecrement());

            Assert.AreEqual("while(a>0)a--;", w.ToString());
        }

        [TestMethod]
        public void WithReturnsWithStatement()
        {
            var a = JS.Id("a");
            var w = JS.With(a).Do(a.Call(), JS.Return());

            Assert.AreEqual("with(a){a();return;}", w.ToString());
        }
    }
}
