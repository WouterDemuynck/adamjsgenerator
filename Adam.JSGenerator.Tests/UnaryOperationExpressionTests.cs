﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Adam.JSGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class UnaryOperationExpressionTests
    {
        [TestMethod]
        public void UnaryOperationExpression_Produces_Unary_Operations()
        {
            var a = JS.Id("a");

            var expression1 = a.Number();
            var expression2 = a.Negative();
            var expression3 = a.BitwiseNot();
            var expression4 = a.LogicalNot();
            var expression5 = a.PreIncrement();
            var expression6 = a.PostIncrement();
            var expression7 = a.PreDecrement();
            var expression8 = a.PostDecrement();
            var expression9 = a.New();
            var expression10 = a.TypeOf();
            var expression11 = a.Delete();
            var expression12 = a.Group();

            Assert.AreEqual("+a;", expression1.ToString());
            Assert.AreEqual("-a;", expression2.ToString());
            Assert.AreEqual("~a;", expression3.ToString());
            Assert.AreEqual("!a;", expression4.ToString());
            Assert.AreEqual("++a;", expression5.ToString());
            Assert.AreEqual("a++;", expression6.ToString());
            Assert.AreEqual("--a;", expression7.ToString());
            Assert.AreEqual("a--;", expression8.ToString());
            Assert.AreEqual("new a();", expression9.ToString());
            Assert.AreEqual("typeof a;", expression10.ToString());
            Assert.AreEqual("delete a;", expression11.ToString());
            Assert.AreEqual("(a);", expression12.ToString());
        }

        [TestMethod]
        public void UnaryOperationExpression_Has_Properties()
        {
            var a = JS.Id("a");

            var expression = new UnaryOperationExpression(a, UnaryOperator.Number);

            Assert.AreEqual("+a;", expression.ToString());

            expression.Operator = UnaryOperator.New;

            Assert.AreEqual(UnaryOperator.New, expression.Operator);
            Assert.AreEqual("new a;", expression.ToString());

            expression.Operand = JS.ParseId("Sys.UI.Component");

            Assert.AreEqual("Sys.UI.Component;", expression.Operand.ToString());
            Assert.AreEqual("new Sys.UI.Component;", expression.ToString());
        }

        [TestMethod]
        public void UnaryOperationExpressions_Support_Precedence()
        {
            var expression = JS.Number(3).Group().AddWith(JS.Id("a").TypeOf().New());

            Assert.AreEqual("(3)+new typeof a();", expression.ToString());
        }

        [TestMethod]
        public void UnaryOperationExpression_Detects_Unknown_Enumeration()
        {
            var expression = new UnaryOperationExpression(1, (UnaryOperator) int.MaxValue);

            Expect.Throw<InvalidOperationException>(() => expression.ToString());
        }

        [TestMethod]
        public void UnaryOperationExpression_Helpers_Require_Expression()
        {
            Expression expression = null;

            Expect.Throw<ArgumentNullException>(() => expression.BitwiseNot());
            Expect.Throw<ArgumentNullException>(() => expression.Delete());
            Expect.Throw<ArgumentNullException>(() => expression.Group());
            Expect.Throw<ArgumentNullException>(() => expression.LogicalNot());
            Expect.Throw<ArgumentNullException>(() => expression.Negative());
            Expect.Throw<ArgumentNullException>(() => expression.New());
            Expect.Throw<ArgumentNullException>(() => expression.Number());
            Expect.Throw<ArgumentNullException>(() => expression.PostDecrement());
            Expect.Throw<ArgumentNullException>(() => expression.PostIncrement());
            Expect.Throw<ArgumentNullException>(() => expression.PreDecrement());
            Expect.Throw<ArgumentNullException>(() => expression.PreIncrement());
            Expect.Throw<ArgumentNullException>(() => expression.TypeOf());
        }
    }
}
