using System;
using Adam.JSGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Tests for BinaryOperationExpression
    /// </summary>
    [TestClass]
    public class BinaryOperationExpressionTests
    {
        private static readonly Expression A = JS.Id("a");
        private static readonly Expression B = JS.Id("b");
        
        [TestMethod]
        public void BinaryOperationExpression_Supports_Assign()
        {
            var b = A.AssignWith(B);

            Assert.AreEqual("a=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Assign_And_Assign_Is_Still_Assign()
        {
            var b = A.AssignWith(B).AndAssign();

            Assert.AreEqual("a=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_Add()
        {
            var b = A.AddWith(B);

            Assert.AreEqual("a+b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_AddAndAssign()
        {
            var b = A.AddWith(B).AndAssign();

            Assert.AreEqual("a+=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_Subtract()
        {
            var b = A.SubtractWith(B);

            Assert.AreEqual("a-b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_SubtractAndAssign()
        {
            var b = A.SubtractWith(B).AndAssign();

            Assert.AreEqual("a-=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_Multiply()
        {
            var b = A.MultiplyBy(B);

            Assert.AreEqual("a*b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_MultiplyAndAssign()
        {
            var b = A.MultiplyBy(B).AndAssign();

            Assert.AreEqual("a*=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_Divide()
        {
            var b = A.DivideBy(B);

            Assert.AreEqual("a/b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_DivideAndAssign()
        {
            var b = A.DivideBy(B).AndAssign();

            Assert.AreEqual("a/=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_Remain()
        {
            var b = A.RemainderBy(B);

            Assert.AreEqual("a%b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_RemainAndAssign()
        {
            var b = A.RemainderBy(B).AndAssign();

            Assert.AreEqual("a%=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_BitwiseAnd()
        {
            var b = A.BitwiseAndWith(B);

            Assert.AreEqual("a&b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_BitwiseAndAndAssign()
        {
            var b = A.BitwiseAndWith(B).AndAssign();

            Assert.AreEqual("a&=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_BitwiseOr()
        {
            var b = A.BitwiseOrWith(B);

            Assert.AreEqual("a|b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_BitwiseOrAndAssign()
        {
            var b = A.BitwiseOrWith(B).AndAssign();

            Assert.AreEqual("a|=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_BitwiseXor()
        {
            var b = A.BitwiseXorWith(B);

            Assert.AreEqual("a^b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_BitwiseXorAndAssign()
        {
            var b = A.BitwiseXorWith(B).AndAssign();

            Assert.AreEqual("a^=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_ShiftLeft()
        {
            var b = A.ShiftLeftWith(B);

            Assert.AreEqual("a<<b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_ShiftLeftAndAssign()
        {
            var b = A.ShiftLeftWith(B).AndAssign();

            Assert.AreEqual("a<<=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_ShiftRight()
        {
            var b = A.ShiftRightWith(B);

            Assert.AreEqual("a>>b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_ShiftRightAndAssign()
        {
            var b = A.ShiftRightWith(B).AndAssign();

            Assert.AreEqual("a>>=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_Equals()
        {
            var b = A.IsEqualTo(B);

            Assert.AreEqual("a==b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_Identical()
        {
            var b = A.IsIdenticalTo(B);

            Assert.AreEqual("a===b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_NotEqual()
        {
            var b = A.IsNotEqualTo(B);

            Assert.AreEqual("a!=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_NotIdentical()
        {
            var b = A.IsNotIdenticalTo(B);

            Assert.AreEqual("a!==b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_GreaterThan()
        {
            var b = A.IsGreaterThan(B);

            Assert.AreEqual("a>b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_GreaterThanOrEqualTo()
        {
            var b = A.IsGreaterThanOrEqualTo(B);

            Assert.AreEqual("a>=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_LessThan()
        {
            var b = A.IsLessThan(B);

            Assert.AreEqual("a<b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_LessThanOrEqualTo()
        {
            var b = A.IsLessThanOrEqualTo(B);

            Assert.AreEqual("a<=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_LogicalAnd()
        {
            var b = A.LogicalAndWith(B);

            Assert.AreEqual("a&&b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_LogicalOr()
        {
            var b = A.LogicalOrWith(B);

            Assert.AreEqual("a||b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_InstanceOf()
        {
            var b = A.IsInstanceOf(B);

            Assert.AreEqual("a instanceof b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_In()
        {
            var b = A.IsIn(B);

            Assert.AreEqual("a in b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_MultipleEvaluation()
        {
            var b = new BinaryOperationExpression(A, B, BinaryOperator.MultipleEvaluation);

            Assert.AreEqual("a,b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_Precedence()
        {
            var t1 = A.MultiplyBy(3).AddWith(B.MultiplyBy(2));
            var t2 = A.AddWith(3).MultiplyBy(B.AddWith(2));
            var t3 = A.ShiftLeftWith(3).AddWith(B).MultiplyBy(2);

            Assert.AreEqual("a*3+b*2;", t1.ToString());
            Assert.AreEqual("(a+3)*(b+2);", t2.ToString());
            Assert.AreEqual("((a<<3)+b)*2;", t3.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Supports_Compare()
        {
            var t1 = A.MultiplyBy(B.MultiplyBy(3));
            var t2 = A.MultiplyBy(B.MultiplyBy(3));

            Assert.AreEqual(t1, t2);
        }

        [TestMethod]
        public void BinaryOperationExpression_Handles_Nulls()
        {
            var b1 = JS.Id("a").AssignWith(null);
            var b2 = JS.Id("b").IsNotEqualTo(null);

            Assert.AreEqual("a=null;", b1.ToString());
            Assert.AreEqual("b!=null;", b2.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpression_Combines_Sequences()
        {
            var a = new Expression[] { 1, 2, null, "Hello", JS.Function().Call() };
            var c = a.Combined(BinaryOperator.Add);

            Assert.AreEqual("1+2+null+\"Hello\"+function(){}();", c.ToString());
        }

        [TestMethod]
        public void Can_Add_Two_Nulls()
        {
            var a = new BinaryOperationExpression(null, null, BinaryOperator.Add);

            Assert.AreEqual("null+null;", a.ToString());
        }

        [TestMethod]
        public void Can_Use_Property_Accessors()
        {
            var a = new BinaryOperationExpression();

            a.OperandLeft = 1;
            a.OperandRight = 2;
            a.Operator = BinaryOperator.Add;

            Assert.AreEqual("1+2;", a.ToString());
        }

        [TestMethod]
        public void AssignWith_Throws_On_Null()
        {
            BinaryOperationExpression none = null;
            Expect.Throw<ArgumentNullException>(() => none.AndAssign());
        }

        [TestMethod]
        public void BinaryOperationExpression_Refuses_Unknown_Enum()
        {
            var a = new BinaryOperationExpression(null, null, (BinaryOperator)int.MaxValue);

            Expect.Throw < InvalidOperationException>(() => a.ToString());
        }

    }
}
