using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for LoopStatementTests
    /// </summary>
    [TestClass]
    public class LoopStatementTests
    {
        [TestMethod]
        public void LoopStatement_Requires_Statement()
        {
            var statement = new LoopStatement();

            Expect.Throw<InvalidOperationException>(() => statement.ToString());
        }

        [TestMethod]
        public void LoopStatement_Produces_Infinite_Loop()
        {
            var statement = new LoopStatement(null, null, null, JS.Empty());

            Assert.AreEqual("for(;;);", statement.ToString());
        }

        [TestMethod]
        public void LoopStatement_Produces_Loop_With_All_The_Bells_And_Whistles()
        {
            var a = JS.Id("a");
            var initialization = JS.Var(a.AssignWith(0));
            var condition = a.IsLessThan(10);
            var iteration = a.PostIncrement();
            var alert = JS.Alert(a);
            var statement = new LoopStatement(initialization, condition, iteration, alert);

            Assert.AreEqual("var a=0;", statement.Initialization.ToString());
            Assert.AreEqual("a++;", statement.Iteration.ToString());
            Assert.AreEqual("a<10;", statement.Condition.ToString());
            Assert.AreEqual("alert(a);", statement.Statement.ToString());
            Assert.AreEqual("for(var a=0;a<10;a++)alert(a);", statement.ToString());
        }

        [TestMethod]
        public void LoopStatement_Produces_Loop_With_All_The_Bells_And_Whistles_Through_Properties()
        {
            var a = JS.Id("a");
            var initialization = JS.Var(a.AssignWith(0));
            var condition = a.IsLessThan(10);
            var iteration = a.PostIncrement();
            var alert = JS.Alert(a);
            var statement = new LoopStatement();
            statement.Initialization = initialization;
            statement.Condition = condition;
            statement.Iteration = iteration;
            statement.Statement = alert;

            Assert.AreEqual("for(var a=0;a<10;a++)alert(a);", statement.ToString());
        }

        [TestMethod]
        public void LoopStatement_Has_With_Helpers()
        {
            LoopStatement statement1 = JS.For().With(JS.Return());
            LoopStatement statement2 = JS.For().With(new List<Statement> { JS.Return() });

            Assert.AreEqual(JS.Return(), statement1.Statement);
            Assert.AreEqual(JS.Return(), statement2.Statement);
        }

        [TestMethod]
        public void LoopStatement_With_Requires_Statement()
        {
            LoopStatement statement = null;

            Expect.Throw<ArgumentNullException>(() => statement.With(new Statement[0]));
            Expect.Throw<ArgumentNullException>(() => statement.With(new List<Statement>()));
        }

    }
}
