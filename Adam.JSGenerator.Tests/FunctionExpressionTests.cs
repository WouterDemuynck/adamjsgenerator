using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for FunctionExpression
    /// </summary>
    [TestClass]
    public class FunctionExpressionTests
    {
        [TestMethod]
        public void FunctionExpression_Produces_Anonymous_Function()
        {
            var f = new FunctionExpression();

            Assert.AreEqual("function(){};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpression_Produces_Anonymous_Function_With_Parameters()
        {
            var f = new FunctionExpression(null, new IdentifierExpression[] { "a", "b", "c" }, null);

            Assert.AreEqual("function(a,b,c){};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpression_Produces_Named_Function()
        {
            var f = new FunctionExpression("alert", null, null);

            Assert.AreEqual("function alert(){};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpression_Produces_Function_With_Body()
        {
            var f = new FunctionExpression()
                .Parameters(new List<IdentifierExpression>())
                .Do(new List<Statement> { JS.Return() });


            Assert.AreEqual("function(){return;};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpression_Produces_Function_With_Name_Parameters_And_Body_Using_Properties()
        {
            var f = new FunctionExpression();
            f.Name = JS.Id("a");
            f.Parameters.Add("b");
            f.Parameters.Add("c");
            f.Body = new CompoundStatement(JS.Return());

            Assert.AreEqual("function a(b,c){return;};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpression_Helpers_Needs_Expression()
        {
            FunctionExpression expression = null;
            Expect.Throw<ArgumentNullException>(() => expression.Parameters());
            Expect.Throw<ArgumentNullException>(() => expression.Parameters(new List<IdentifierExpression>()));
            Expect.Throw<ArgumentNullException>(() => expression.Do());
            Expect.Throw<ArgumentNullException>(() => expression.Do(new List<Statement>()));
        }
    }
}
