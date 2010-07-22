using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class BinaryOperationExpressionTests
    {
        private static readonly Expression A = JS.Id("a");
        private static readonly Expression B = JS.Id("b");
        
        [TestMethod]
        public void BinaryOperationExpressionSupportsAssign()
        {
            var b = A.AssignWith(B);

            Assert.AreEqual("a=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionAssignAndAssignIsStillAssign()
        {
            var b = A.AssignWith(B).AndAssign();

            Assert.AreEqual("a=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsAdd()
        {
            var a = 3.AddWith(4);
            var b = A.AddWith(B);

            Assert.AreEqual("3+4;", a.ToString());
            Assert.AreEqual("a+b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsAddAndAssign()
        {
            var b = A.AddWith(B).AndAssign();

            Assert.AreEqual("a+=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsSubtract()
        {
            var a = 3.SubtractWith(4);
            var b = A.SubtractWith(B);

            Assert.AreEqual("3-4;", a.ToString());
            Assert.AreEqual("a-b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsSubtractAndAssign()
        {
            var b = A.SubtractWith(B).AndAssign();

            Assert.AreEqual("a-=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsMultiply()
        {
            var a = 3.MultiplyBy(4);
            var b = A.MultiplyBy(B);

            Assert.AreEqual("3*4;", a.ToString());
            Assert.AreEqual("a*b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsMultiplyAndAssign()
        {
            var b = A.MultiplyBy(B).AndAssign();

            Assert.AreEqual("a*=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsDivide()
        {
            var a = 3.DivideBy(4);
            var b = A.DivideBy(B);

            Assert.AreEqual("3/4;", a.ToString());
            Assert.AreEqual("a/b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsDivideAndAssign()
        {
            var b = A.DivideBy(B).AndAssign();

            Assert.AreEqual("a/=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsRemain()
        {
            var a = 3.RemainderBy(4);
            var b = A.RemainderBy(B);

            Assert.AreEqual("3%4;", a.ToString());
            Assert.AreEqual("a%b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsRemainAndAssign()
        {
            var b = A.RemainderBy(B).AndAssign();

            Assert.AreEqual("a%=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseAnd()
        {
            var a = 3.BitwiseAndWith(4);
            var b = A.BitwiseAndWith(B);

            Assert.AreEqual("3&4;", a.ToString());
            Assert.AreEqual("a&b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseAndAndAssign()
        {
            var b = A.BitwiseAndWith(B).AndAssign();

            Assert.AreEqual("a&=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseOr()
        {
            var a = 3.BitwiseOrWith(4);
            var b = A.BitwiseOrWith(B);

            Assert.AreEqual("3|4;", a.ToString());
            Assert.AreEqual("a|b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseOrAndAssign()
        {
            var b = A.BitwiseOrWith(B).AndAssign();

            Assert.AreEqual("a|=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseXor()
        {
            var a = 3.BitwiseXorWith(4);
            var b = A.BitwiseXorWith(B);

            Assert.AreEqual("3^4;", a.ToString());
            Assert.AreEqual("a^b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseXorAndAssign()
        {
            var b = A.BitwiseXorWith(B).AndAssign();

            Assert.AreEqual("a^=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsShiftLeft()
        {
            var a = 3.ShiftLeftWith(4);
            var b = A.ShiftLeftWith(B);

            Assert.AreEqual("3<<4;", a.ToString());
            Assert.AreEqual("a<<b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsShiftLeftAndAssign()
        {
            var b = A.ShiftLeftWith(B).AndAssign();

            Assert.AreEqual("a<<=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsShiftRight()
        {
            var a = 3.ShiftRightWith(4);
            var b = A.ShiftRightWith(B);

            Assert.AreEqual("3>>4;", a.ToString());
            Assert.AreEqual("a>>b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsShiftRightAndAssign()
        {
            var b = A.ShiftRightWith(B).AndAssign();

            Assert.AreEqual("a>>=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsEquals()
        {
            var a = 3.IsEqualTo(4);
            var b = A.IsEqualTo(B);

            Assert.AreEqual("3==4;", a.ToString());
            Assert.AreEqual("a==b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsIdentical()
        {
            var a = 3.IsIdenticalTo(4);
            var b = A.IsIdenticalTo(B);

            Assert.AreEqual("3===4;", a.ToString());
            Assert.AreEqual("a===b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsNotEqual()
        {
            var a = 3.IsNotEqualTo(4);
            var b = A.IsNotEqualTo(B);

            Assert.AreEqual("3!=4;", a.ToString());
            Assert.AreEqual("a!=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsNotIdentical()
        {
            var a = 3.IsNotIdenticalTo(4);
            var b = A.IsNotIdenticalTo(B);

            Assert.AreEqual("3!==4;", a.ToString());
            Assert.AreEqual("a!==b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsGreaterThan()
        {
            var a = 3.IsGreaterThan(4);
            var b = A.IsGreaterThan(B);

            Assert.AreEqual("3>4;", a.ToString());
            Assert.AreEqual("a>b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsGreaterThanOrEqualTo()
        {
            var a = 3.IsGreaterThanOrEqualTo(4);
            var b = A.IsGreaterThanOrEqualTo(B);

            Assert.AreEqual("3>=4;", a.ToString());
            Assert.AreEqual("a>=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsLessThan()
        {
            var a = 3.IsLessThan(4);
            var b = A.IsLessThan(B);

            Assert.AreEqual("3<4;", a.ToString());
            Assert.AreEqual("a<b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsLessThanOrEqualTo()
        {
            var a = 3.IsLessThanOrEqualTo(4);
            var b = A.IsLessThanOrEqualTo(B);

            Assert.AreEqual("3<=4;", a.ToString());
            Assert.AreEqual("a<=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsLogicalAnd()
        {
            var a = true.LogicalAndWith(true);
            var b = A.LogicalAndWith(B);

            Assert.AreEqual("true&&true;", a.ToString()); 
            Assert.AreEqual("a&&b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsLogicalOr()
        {
            var a = false.LogicalOrWith(false);
            var b = A.LogicalOrWith(B);

            Assert.AreEqual("false||false;", a.ToString());
            Assert.AreEqual("a||b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsInstanceOf()
        {
            var a = 3.IsInstanceOf(JS.Id("Integer"));
            var b = A.IsInstanceOf(B);

            Assert.AreEqual("3 instanceof Integer;", a.ToString());
            Assert.AreEqual("a instanceof b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsIn()
        {
            var a = 3.IsIn(new[] {1, 2, 3});
            var b = A.IsIn(B);

            Assert.AreEqual("3 in [1,2,3];", a.ToString());
            Assert.AreEqual("a in b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsMultipleEvaluation()
        {
            var a = new BinaryOperationExpression(3, 4, BinaryOperator.MultipleEvaluation);
            var b = new BinaryOperationExpression(A, B, BinaryOperator.MultipleEvaluation);

            Assert.AreEqual("3,4;", a.ToString());
            Assert.AreEqual("a,b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsPrecedence()
        {
            var t1 = A.MultiplyBy(3).AddWith(B.MultiplyBy(2));
            var t2 = 3.AddWith(3).MultiplyBy(B.AddWith(2));
            var t3 = A.ShiftLeftWith(3).AddWith(B).MultiplyBy(2);

            Assert.AreEqual("a*3+b*2;", t1.ToString());
            Assert.AreEqual("(3+3)*(b+2);", t2.ToString());
            Assert.AreEqual("((a<<3)+b)*2;", t3.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsCompare()
        {
            var t1 = JS.Id("a").MultiplyBy(B.MultiplyBy(3));
            var t2 = A.MultiplyBy(B.MultiplyBy(3));

            Assert.AreEqual(t1, t2);
        }

        [TestMethod]
        public void BinaryOperationExpressionHandlesNulls()
        {
            var b1 = JS.Id("a").AssignWith(null);
            var b2 = JS.Id("b").IsNotEqualTo(null);

            Assert.AreEqual("a=null;", b1.ToString());
            Assert.AreEqual("b!=null;", b2.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionCombinesSequences()
        {
            var a = new object[] { 1, 2, null, "Hello", JS.Function().Call() };
            var c = a.Combined(BinaryOperator.Add);

            Assert.AreEqual("1+2+null+\"Hello\"+(function(){})();", c.ToString());
        }

        [TestMethod]
        public void CanAddTwoNulls()
        {
            var a = new BinaryOperationExpression(null, null, BinaryOperator.Add);

            Assert.AreEqual("null+null;", a.ToString());
        }

        [TestMethod]
        public void CanUsePropertyAccessors()
        {
            var a = new BinaryOperationExpression();

            a.OperandLeft = 1;
            a.OperandRight = 2;
            a.Operator = BinaryOperator.Add;

            Assert.AreEqual("1+2;", a.ToString());
        }

        [TestMethod]
        public void AssignWithThrowsOnNull()
        {
            BinaryOperationExpression none = null;
            Expect.Throw<ArgumentNullException>(() => none.AndAssign());
        }

        [TestMethod]
        public void BinaryOperationExpressionRefusesUnknownEnum()
        {
            var a = new BinaryOperationExpression(null, null, (BinaryOperator)int.MaxValue);

            Expect.Throw < InvalidOperationException>(() => a.ToString());
        }

        [TestMethod]
        public void JustACrazyThought()
        {
            var a = 3.AddWith(5);

            Assert.AreEqual("3+5;", a.ToString());
        }

    }
}
