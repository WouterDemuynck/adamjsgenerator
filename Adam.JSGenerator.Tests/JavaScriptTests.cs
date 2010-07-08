using System;
using System.Collections.Generic;
using System.Linq;
using Adam.JSGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests different aspects of the JavaScript utility class.
    /// </summary>
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
        public void FindsMostSuitableQuoteChar_Finds_Most_Suitable_Character()
        {
            var s = '\'';
            var d = '"';
            var def = s;

            Assert.IsTrue(JS.FindMostSuitableQuoteChar("abcde") == def);        // No quotes means default.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a'bcde") == d);         // Single quote means double.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("abcd\"e") == s);        // Double quote means single.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a'bcd\"e") == def);     // Both means default.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a''bcd\"e") == d);      // More single than double means double.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a'bcd\"\"e") == s);     // More double than single means single.
            Assert.IsTrue(JS.FindMostSuitableQuoteChar("a''bcd\"\"e") == def);  // Equal count means default.
        }

        [TestMethod]
        public void FindsMostSuitableQuoteChar_Requires_Sequence()
        {
            Expect.Throw<ArgumentNullException>(() => JS.FindMostSuitableQuoteChar(null));
        }

        [TestMethod]
        public void QuoteString_Returns_QuotedStrings()
        {
            Assert.AreEqual("'hey there!'", JS.QuoteString("hey there!"));
            Assert.AreEqual("\"'It's \\\"time\\\"!', she said.\"", JS.QuoteString("'It's \"time\"!', she said."));
            Assert.AreEqual(@"'\b\t\n\f\r\u0007'", JS.QuoteString("\b\t\n\f\r\a"));
            Assert.AreEqual(@"'one\\ntwo'", JS.QuoteString(@"one\ntwo"));
            Assert.AreEqual(@"'\u003chtml\u003e'", JS.QuoteString("<html>"));
        }

        [TestMethod]
        public void QuoteString_Requires_Source()
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
        public void GetValues_Gets_Values_From_Null()
        {
            var result = JS.GetValues(null);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetValues_Gets_Values_From_Empty_Object()
        {
            var result = JS.GetValues(new object());

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetValues_Gets_Values_From_Anonymous_Object()
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
        public void GetValues_Gets_Values_From_Normal_Object()
        {
            TestObject o = new TestObject() { Value = 1, Display = "One", Test = null };

            var result = JS.GetValues(o);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IDictionary<Expression, Expression>));

            Assert.IsTrue(result.ContainsKey(JS.Id("Value")));
            Assert.AreEqual(result[JS.Id("Value")], JS.Number(1));
            Assert.IsTrue(result.ContainsKey(JS.Id("Display")));
            Assert.AreEqual(result[JS.Id("Display")], JS.String("One"));
            Assert.IsTrue(result.ContainsKey(JS.Id("Test")));
            Assert.AreEqual(result[JS.Id("Test")], JS.Null());
        }

        [TestMethod]
        public void Object_Gets_Complicated_Object()
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
        public void Multiple_Gets_Null()
        {
            var o = JS.Multiple();

            Assert.IsNull(o);
        }

        [TestMethod]
        public void Multiple_Gets_Single()
        {
            var a = JS.Id("a");
            var o = JS.Multiple(a);

            Assert.AreEqual("a;", o.ToString());
        }

        [TestMethod]
        public void Multiple_Gets_Multiple()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var c = JS.Id("c");

            var o = JS.Multiple(a, b, c);

            Assert.AreEqual("a,b,c;", o.ToString());
        }

        [TestMethod]
        public void BlockOrStatement_Returns_Empty()
        {
            var block = JS.BlockOrStatement();

            Assert.AreEqual(";", block.ToString());
        }

        [TestMethod]
        public void BlockOrStatement_Returns_Statement()
        {            
            var block = JS.BlockOrStatement(JS.Return());

            Assert.AreEqual("return;", block.ToString());
        }

        [TestMethod]
        public void BlockOrStatement_Returns_Block()
        {
            var block = JS.BlockOrStatement(JS.Null(), JS.Return());

            Assert.AreEqual("{null;return;}", block.ToString());
        }

        [TestMethod]
        public void ParseId_Parses_Simple_Id()
        {
            var id = JS.ParseId("Adam");

            Assert.AreEqual("Adam;", id.ToString());
        }

        [TestMethod]
        public void ParseId_Parses_Multiple_Ids()
        {
            var id = JS.ParseId("Adam.Controls");

            Assert.AreEqual("Adam.Controls;", id.ToString());
        }

        [TestMethod]
        public void ParseId_Rejects_Wrong_Ids()
        {
            Expect.Throw<ArgumentException>(() => JS.ParseId("Adam.Controls@"));
        }

        [TestMethod]
        public void Array_Returns_Empty_Array()
        {
            var arr = JS.Array();

            Assert.AreEqual("[];", arr.ToString());
        }

        [TestMethod]
        public void Array_Returns_Array_With_Ints()
        {
            var arr = JS.Array(1, 2, 3);

            Assert.AreEqual("[1,2,3];", arr.ToString());
        }

        [TestMethod]
        public void Array_Returns_Array_With_Strings()
        {
            var arr = JS.Array(new List<Expression> { "One", "Two", "Three" } );

            Assert.AreEqual("[\"One\",\"Two\",\"Three\"];", arr.ToString());
        }

        [TestMethod]
        public void Array_Returns_Array_With_Nested_Arrays()
        {
            var arr = JS.Array(1, 2, JS.Array(3, 4));

            Assert.AreEqual("[1,2,[3,4]];", arr.ToString());
        }

        [TestMethod]
        public void Block_Returns_Empty_Block()
        {
            var block = JS.Block();

            Assert.AreEqual("{}", block.ToString());
        }

        [TestMethod]
        public void Block_Returns_Block_1()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var c = JS.Id("c");
            var block = JS.Block(a, b, c);

            Assert.AreEqual("{a;b;c;}", block.ToString());
        }

        [TestMethod]
        public void Block_Returns_Block_2()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var c = JS.Id("c");
            var block = JS.Block(new List<Statement> { a, b, c });

            Assert.AreEqual("{a;b;c;}", block.ToString());
        }

        [TestMethod]
        public void Break_Returns_Break()
        {
            var b = JS.Break();

            Assert.AreEqual("break;", b.ToString());
        }

        [TestMethod]
        public void Break_Returns_Break_With_Label()
        {
            var b = JS.Break("a");

            Assert.AreEqual("break a;", b.ToString());
        }

        [TestMethod]
        public void Continue_Returns_Continue()
        {
            var c = JS.Continue();

            Assert.AreEqual("continue;", c.ToString());
        }

        [TestMethod]
        public void Continue_Returns_Continue_With_Label()
        {
            var c = JS.Continue("c");

            Assert.AreEqual("continue c;", c.ToString());
        }

        [TestMethod]
        public void Delete_Returns_Delete()
        {
            var d = JS.Delete(JS.Id("a"));

            Assert.AreEqual("delete a;", d.ToString());
        }

        [TestMethod]
        public void Do_Returns_Do_While_With_Single_Statement()
        {
            var dw = JS.Do(JS.Null()).While(JS.Null());

            Assert.AreEqual("do null;while(null);", dw.ToString());
        }

        [TestMethod]
        public void Do_Returns_Do_While_With_Multiple_Statement()
        {
            var dw = JS.Do(new List<Statement> { JS.Null(), JS.Null() }).While(JS.Null());

            Assert.AreEqual("do {null;null;}while(null);", dw.ToString());
        }

        [TestMethod]
        public void Empty_Returns_Empty_Statement()
        {
            var e = JS.Empty();

            Assert.AreEqual(";", e.ToString());
        }

        [TestMethod]
        public void Find_Returns_Find()
        {
            var f = JS.Find("a");

            Assert.AreEqual("$find(\"a\");", f.ToString());
        }

        [TestMethod]
        public void For_Returns_For_In()
        {
            var f = JS.For(JS.Var(JS.Id("a"))).In(JS.Array());

            Assert.AreEqual("for(var a in []);", f.ToString());
        }

        [TestMethod]
        public void For_Returns_Eternal_Loop()
        {
            var f = JS.For();

            Assert.AreEqual("for(;;);", f.ToString());
        }

        [TestMethod]
        public void For_Returns_For_With_Iteration()
        {
            var f = JS.For(JS.Id("a").PreIncrement());

            Assert.AreEqual("for(;;++a);", f.ToString());
        }

        [TestMethod]
        public void For_Returns_For_With_Condition_And_Iteration()
        {
            var a = JS.Id("a");
            var f = JS.For(a.IsGreaterThan(0), a.PreDecrement());

            Assert.AreEqual("for(;a>0;--a);", f.ToString());
        }

        [TestMethod]
        public void For_Returns_For_With_Initialization_Condition_And_Iteration()
        {
            var a = JS.Id("a");
            var f = JS.For(JS.Var(a.AssignWith(10)), a.IsGreaterThan(0), a.PreDecrement());

            Assert.AreEqual("for(var a=10;a>0;--a);", f.ToString());
        }

        [TestMethod]
        public void Function_Returns_Empty_Anonymous_Function()
        {
            var f = JS.Function();

            Assert.AreEqual("function(){};", f.ToString());
        }

        [TestMethod]
        public void Function_Returns_Function_With_Name()
        {
            var f = JS.Function("a");

            Assert.AreEqual("function a(){};", f.ToString());
        }

        [TestMethod]
        public void Function_Returns_Function_With_Body()
        {
            var f = JS.Function().Do(JS.Null());

            Assert.AreEqual("function(){null;};", f.ToString());
        }

        [TestMethod]
        public void Function_Returns_Function_With_Parameters()
        {
            var a = JS.Id("a");
            var f = JS.Function().Parameters(a).Do(a.Call());

            Assert.AreEqual("function(a){a();};", f.ToString());
        }

        [TestMethod]
        public void Get_Returns_Get()
        {
            var g = JS.Get("a");

            Assert.AreEqual("$get(\"a\");", g.ToString());
        }

        [TestMethod]
        public void Group_Returns_Group()
        {
            var g = JS.Group("a");

            Assert.AreEqual("(\"a\");", g.ToString());
        }

        [TestMethod]
        public void Id_Returns_Identifier()
        {
            var i = JS.Id("a");

            Assert.AreEqual("a;", i.ToString());
        }

        [TestMethod]
        public void Id_Rejects_Bad_Identifiers()
        {
            Expect.Throw<ArgumentException>(() => JS.Id("nO!"));
        }

        [TestMethod]
        public void If_Returns_If()
        {
            var i = JS.If(JS.Null());

            Assert.AreEqual("if(null);", i.ToString());
        }

        [TestMethod]
        public void If_Returns_If_Then()
        {
            var i = JS.If(JS.Null()).Then(JS.Null());

            Assert.AreEqual("if(null)null;", i.ToString());
        }

        [TestMethod]
        public void If_Returns_If_Else()
        {
            var i = JS.If(JS.Null()).Else(JS.Null());

            Assert.AreEqual("if(null); else null;", i.ToString());
        }

        [TestMethod]
        public void If_Returns_If_Then_Else()
        {
            var i = JS.If(JS.Null()).Then(JS.Null()).Else(JS.Null());

            Assert.AreEqual("if(null)null; else null;", i.ToString());
        }

        [TestMethod]
        public void Label_Returns_Label()
        {
            var l = JS.Label("l", JS.Empty());

            Assert.AreEqual("l:;", l.ToString());
        }

        [TestMethod]
        public void Number_Returns_Integer()
        {
            var i = JS.Number(10);

            Assert.AreEqual("10;", i.ToString());
        }

        [TestMethod]
        public void Number_Returns_Double()
        {
            var d = JS.Number(3.14);

            Assert.AreEqual("3.14;", d.ToString());
        }

        [TestMethod]
        public void String_Returns_String()
        {
            var s = JS.String("test");

            Assert.AreEqual("\"test\";", s.ToString());
        }

        [TestMethod]
        public void Boolean_Returns_Boolean()
        {
            var t = JS.Boolean(true);
            var f = JS.Boolean(false);

            Assert.AreEqual("true;", t.ToString());
            Assert.AreEqual("false;", f.ToString());
        }

        [TestMethod]
        public void Multiple_Returns_Multiple_Evaluation()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var c = JS.Id("c");

            var m = JS.Multiple(a.PostIncrement(), b.IsGreaterThan(10), c.AddWith(5).AndAssign());
            
            Assert.AreEqual("a++,b>10,c+=5;", m.ToString());
        }

        [TestMethod]
        public void New_Returns_New_Object()
        {
            var n = JS.New(JS.Id("Class"));

            Assert.AreEqual("new Class();", n.ToString());
        }

        [TestMethod]
        public void New_Returns_New_Object_With_Parameters()
        {
            var n1 = JS.New(JS.Id("Class"), new List<Expression> { "div", "p", 2 });
            var n2 = JS.New(JS.Id("Class"), "div", "p", 2);

            Assert.AreEqual("new Class(\"div\",\"p\",2);", n1.ToString());
            Assert.AreEqual("new Class(\"div\",\"p\",2);", n2.ToString());
        }

        [TestMethod]
        public void Not_Returns_Logical_Not()
        {
            var n = JS.Not(true);

            Assert.AreEqual("!true;", n.ToString());
        }

        [TestMethod]
        public void Null_Returns_Null()
        {
            var n = JS.Null();

            Assert.AreEqual("null;", n.ToString());
        }

        [TestMethod]
        public void Object_Returns_Empty_Object()
        {
            var o = JS.Object();

            Assert.AreEqual("{};", o.ToString());
        }

        [TestMethod]
        public void Object_Returns_Object_From_Anonymous_Object()
        {
            var o = JS.Object(new { mother = 1, judge = "mother", speed = JS.Array(1, 2, 3) });

            Assert.AreEqual("{mother:1,judge:\"mother\",speed:[1,2,3]};", o.ToString());
        }

        [TestMethod]
        public void Object_Returns_Object_From_Dictionary()
        {
            var dictionary = new Dictionary<Expression, Expression>();
            dictionary["a"] = "b";

            var o = JS.Object(dictionary);

            Assert.AreEqual("{\"a\":\"b\"};", o.ToString());
        }

        [TestMethod]
        public void Object_Returns_Object_From_Anonymous_Object_With_Nested_Anonymous_Object()
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
        public void Object_Returns_Object_From_Anonymous_Object_With_Nested_Anonymous_Object_Array()
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
        public void Object_Returns_Object_From_Anonymous_Object_With_Nested_Array()
        {
            var o = JS.Object(new
            {
                signals = JS.Array(1, 2, 3)
            });

            Assert.AreEqual("{signals:[1,2,3]};", o.ToString());
        }

        [TestMethod]
        public void Regex_Returns_LiteralExpression()
        {
            var r = JS.Regex(@"/\d+/g");

            Assert.AreEqual(@"/\d+/g;", r.ToString());
        }

        [TestMethod]
        public void Return_Returns_ReturnStatement()
        {
            var r = JS.Return();

            Assert.AreEqual("return;", r.ToString());
        }

        [TestMethod]
        public void Return_Returns_ReturnStatement_With_Value()
        {
            var r = JS.Return("a");

            Assert.AreEqual("return \"a\";", r.ToString());
        }

        [TestMethod]
        public void Script_Returns_Empty_Script()
        {
            var s = JS.Script();

            Assert.AreEqual("", s.ToString());
        }

        [TestMethod]
        public void Script_Returns_Script_With_Statements()
        {
            var s = JS.Script(new List<Statement> { JS.Empty(), JS.Return(JS.Null()) });

            Assert.AreEqual(";return null;", s.ToString());
        }

        [TestMethod]
        public void Snippet_Returns_Literal()
        {
            var s = JS.Snippet("blah blah blah");

            Assert.AreEqual("blah blah blah;", s.ToString());
        }

        [TestMethod]
        public void Switch_Returns_Empty_Switch()
        {
            var s = JS.Switch(JS.Id("a"));

            Assert.AreEqual("switch(a){}", s.ToString());
        }

        [TestMethod]
        public void Switch_Returns_Switch_With_Default()
        {
            var s = JS.Switch(JS.Id("a"))
                .Default().Do(JS.Return());

            Assert.AreEqual("switch(a){default:return;}", s.ToString());
        }

        [TestMethod]
        public void Switch_Returns_Switch_With_Cases()
        {
            var s = JS.Switch(JS.Id("a"))
                .Case(1).Do(JS.Id("alert").Call("moo!")).Break()
                .Case(2, 3, 4).Do(JS.Id("alert").Call("cow!")).Break();

            Assert.AreEqual("switch(a){case 1:alert(\"moo!\");break;case 2:case 3:case 4:alert(\"cow!\");break;}", s.ToString());
        }

        [TestMethod]
        public void Throw_Returns_ThrowStatement()
        {
            var t = JS.Throw("error");

            Assert.AreEqual("throw \"error\";", t.ToString());
        }

        [TestMethod]
        public void Try_Returns_ExceptionHandlingStatement()
        {
            var a = JS.Id("a");
            var alert = JS.Id("alert");

            var t = JS.Try(JS.Return()).Catch(a, alert.Call(a)).Finally(alert.Call("done!"));

            Assert.AreEqual("try{return;}catch(a){alert(a);}finally{alert(\"done!\");}", t.ToString());
        }

        [TestMethod]
        public void Try_Returns_ExceptionHandlingStatement2()
        {
            var a = JS.Id("a");
            var alert = JS.Id("alert");

            var t = JS.Try(new List<Statement> { JS.Return() }).Catch(a, alert.Call(a)).Finally(alert.Call("done!"));

            Assert.AreEqual("try{return;}catch(a){alert(a);}finally{alert(\"done!\");}", t.ToString());
        }

        [TestMethod]
        public void Var_Returns_DeclarationExpression()
        {
            var a = JS.Id("a");
            var v = JS.Var(a);

            Assert.AreEqual("var a;", v.ToString());
        }

        [TestMethod]
        public void Var_Returns_DeclarationExpression_With_Multiple_Expressions()
        {
            var a = JS.Id("a");
            var b = JS.Id("b");
            var v = JS.Var(new List<Expression> { a.AssignWith(5), b.AssignWith(6) });

            Assert.AreEqual("var a=5,b=6;", v.ToString());
        }


        [TestMethod]
        public void Var_Returns_DeclarationExpression_With_Initialization()
        {
            var a = JS.Id("a");
            var v = JS.Var(a.AssignWith(10));

            Assert.AreEqual("var a=10;", v.ToString());
        }

        [TestMethod]
        public void While_Returns_WhileStatement()
        {
            var a = JS.Id("a");
            var w = JS.While(a.IsGreaterThan(0)).Do(a.PostDecrement());

            Assert.AreEqual("while(a>0)a--;", w.ToString());
        }

        [TestMethod]
        public void With_Returns_WithStatement()
        {
            var a = JS.Id("a");
            var w = JS.With(a).Do(a.Call(), JS.Return());

            Assert.AreEqual("with(a){a();return;}", w.ToString());
        }
    }
}
