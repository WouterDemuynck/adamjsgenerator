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
            var b = A.AddWith(B);
            Assert.AreEqual("a+b;", b.ToString());

            b = A + B;
            Assert.AreEqual("a+b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsAddAndAssign()
        {
            var b = A.AddWith(B).AndAssign();
            Assert.AreEqual("a+=b;", b.ToString());

            b = (A + B).AndAssign();
            Assert.AreEqual("a+=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsSubtract()
        {
            var b = A.SubtractWith(B);
            Assert.AreEqual("a-b;", b.ToString());

            b = A - B;
            Assert.AreEqual("a-b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsSubtractAndAssign()
        {
            var b = A.SubtractWith(B).AndAssign();
            Assert.AreEqual("a-=b;", b.ToString());

            b = (A - B).AndAssign();
            Assert.AreEqual("a-=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsMultiply()
        {
            var b = A.MultiplyBy(B);
            Assert.AreEqual("a*b;", b.ToString());

            b = A*B;
            Assert.AreEqual("a*b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsMultiplyAndAssign()
        {
            var b = A.MultiplyBy(B).AndAssign();
            Assert.AreEqual("a*=b;", b.ToString());

            b = (A*B).AndAssign();
            Assert.AreEqual("a*=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsDivide()
        {
            var b = A.DivideBy(B);
            Assert.AreEqual("a/b;", b.ToString());

            b = A/B;
            Assert.AreEqual("a/b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsDivideAndAssign()
        {
            var b = A.DivideBy(B).AndAssign();
            Assert.AreEqual("a/=b;", b.ToString());

            b = (A/B).AndAssign();
            Assert.AreEqual("a/=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsRemain()
        {
            var b = A.RemainderBy(B);
            Assert.AreEqual("a%b;", b.ToString());

            b = A%B;
            Assert.AreEqual("a%b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsRemainAndAssign()
        {
            var b = A.RemainderBy(B).AndAssign();
            Assert.AreEqual("a%=b;", b.ToString());

            b = (A%B).AndAssign();
            Assert.AreEqual("a%=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseAnd()
        {
            var b = A.BitwiseAndWith(B);
            Assert.AreEqual("a&b;", b.ToString());

            b = A & B;
            Assert.AreEqual("a&b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseAndAndAssign()
        {
            var b = A.BitwiseAndWith(B).AndAssign();
            Assert.AreEqual("a&=b;", b.ToString());

            b = (A & B).AndAssign();
            Assert.AreEqual("a&=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseOr()
        {
            var b = A.BitwiseOrWith(B);
            Assert.AreEqual("a|b;", b.ToString());

            b = A | B;
            Assert.AreEqual("a|b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseOrAndAssign()
        {
            var b = A.BitwiseOrWith(B).AndAssign();
            Assert.AreEqual("a|=b;", b.ToString());

            b = (A | B).AndAssign();
            Assert.AreEqual("a|=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseXor()
        {
            var b = A.BitwiseXorWith(B);
            Assert.AreEqual("a^b;", b.ToString());

            b = A ^ B;
            Assert.AreEqual("a^b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsBitwiseXorAndAssign()
        {
            var b = A.BitwiseXorWith(B).AndAssign();
            Assert.AreEqual("a^=b;", b.ToString());

            b = (A ^ B).AndAssign();
            Assert.AreEqual("a^=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsShiftLeft()
        {
            var b = A.ShiftLeftWith(B);

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
            var b = A.ShiftRightWith(B);

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
            var b = A.IsEqualTo(B);

            Assert.AreEqual("a==b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsIdentical()
        {
            var b = A.IsIdenticalTo(B);

            Assert.AreEqual("a===b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsNotEqual()
        {
            var b = A.IsNotEqualTo(B);

            Assert.AreEqual("a!=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsNotIdentical()
        {
            var b = A.IsNotIdenticalTo(B);

            Assert.AreEqual("a!==b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsGreaterThan()
        {
            var b = A.IsGreaterThan(B);
            Assert.AreEqual("a>b;", b.ToString());

            b = A > B;
            Assert.AreEqual("a>b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsGreaterThanOrEqualTo()
        {
            var b = A.IsGreaterThanOrEqualTo(B);
            Assert.AreEqual("a>=b;", b.ToString());

            b = A >= B;
            Assert.AreEqual("a>=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsLessThan()
        {
            var b = A.IsLessThan(B);
            Assert.AreEqual("a<b;", b.ToString());

            b = A < B;
            Assert.AreEqual("a<b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsLessThanOrEqualTo()
        {
            var b = A.IsLessThanOrEqualTo(B);
            Assert.AreEqual("a<=b;", b.ToString());

            b = A <= B;
            Assert.AreEqual("a<=b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsLogicalAnd()
        {
            var b = A.LogicalAndWith(B);

            Assert.AreEqual("a&&b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsLogicalOr()
        {
            var b = A.LogicalOrWith(B);

            Assert.AreEqual("a||b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsInstanceOf()
        {
            var b = A.IsInstanceOf(B);

            Assert.AreEqual("a instanceof b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsIn()
        {
            var b = A.IsIn(B);

            Assert.AreEqual("a in b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsMultipleEvaluation()
        {
            var b = new BinaryOperationExpression(A, B, BinaryOperator.MultipleEvaluation);

            Assert.AreEqual("a,b;", b.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsPrecedence()
        {
            var t1 = A.MultiplyBy(3).AddWith(B.MultiplyBy(2));
            var t2 = A.AddWith(3).MultiplyBy(B.AddWith(2));
            var t3 = A.ShiftLeftWith(3).AddWith(B).MultiplyBy(2);

            Assert.AreEqual("a*3+b*2;", t1.ToString());
            Assert.AreEqual("(a+3)*(b+2);", t2.ToString());
            Assert.AreEqual("((a<<3)+b)*2;", t3.ToString());
        }

        [TestMethod]
        public void BinaryOperationExpressionSupportsCompare()
        {
            var t1 = A.MultiplyBy(B.MultiplyBy(3));
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
            var a = new Expression[] { 1, 2, null, "Hello", JS.Function().Call() };
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

    }
}
