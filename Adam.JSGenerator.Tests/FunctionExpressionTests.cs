using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class FunctionExpressionTests
    {
        [TestMethod]
        public void FunctionExpressionProducesAnonymousFunction()
        {
            var f = new FunctionExpression();

            Assert.AreEqual("function(){};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpressionProducesAnonymousFunctionWithParameters()
        {
            var f = new FunctionExpression(null, new IdentifierExpression[] { "a", "b", "c" }, null);

            Assert.AreEqual("function(a,b,c){};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpressionProducesNamedFunction()
        {
            var f = new FunctionExpression("alert", null, null);

            Assert.AreEqual("function alert(){};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpressionProducesFunctionWithBody()
        {
            var f = new FunctionExpression()
                .Parameters(new List<IdentifierExpression>())
                .Do(new List<Statement> { JS.Return() });


            Assert.AreEqual("function(){return;};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpressionProducesFunctionWithNameParametersAndBodyUsingProperties()
        {
            var f = new FunctionExpression();
            f.Name = JS.Id("a");
            f.Parameters.Add("b");
            f.Parameters.Add("c");
            f.Body = new CompoundStatement(JS.Return());

            Assert.AreEqual("function a(b,c){return;};", f.ToString());
        }

        [TestMethod]
        public void FunctionExpressionHelpersNeedsExpression()
        {
            FunctionExpression expression = null;
            Expect.Throw<ArgumentNullException>(() => expression.Parameters());
            Expect.Throw<ArgumentNullException>(() => expression.Parameters(new List<IdentifierExpression>()));
            Expect.Throw<ArgumentNullException>(() => expression.Do());
            Expect.Throw<ArgumentNullException>(() => expression.Do(new List<Statement>()));
        }
    }
}
