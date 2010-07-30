namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents the binary operator used in a binary operation.
    /// </summary>
    public enum BinaryOperator
    {
        /// <summary>
        /// Represents the assignment '=' operator.
        /// </summary>
        Assign,

        /// <summary>
        /// Represents the addition '+' operator.
        /// </summary>
        Add,

        /// <summary>
        /// Represents the add-and-asign '+=' operator.
        /// </summary>
        AddAndAssign,

        /// <summary>
        /// Represents the subtraction '-' operator.
        /// </summary>
        Subtract,

        /// <summary>
        /// Represents the subtract-and-assign '-=' operator.
        /// </summary>
        SubtractAndAssign,

        /// <summary>
        /// Represents the multiplication '*' operator.
        /// </summary>
        Multiply,

        /// <summary>
        /// Represents the multiply-and-assign '*=' operator.
        /// </summary>
        MultiplyAndAssign,

        /// <summary>
        /// Represents the division '/' operator.
        /// </summary>
        Divide,

        /// <summary>
        /// Represents the divide-and-assign '/=' operator.
        /// </summary>
        DivideAndAssign,

        /// <summary>
        /// Represents the remainder '%' operator.
        /// </summary>
        Remain,

        /// <summary>
        /// Represents the remain-and-assign '%=' operator.
        /// </summary>
        RemainAndAssign,

        /// <summary>
        /// Represents the bitwise and '&amp;' operator.
        /// </summary>
        BitwiseAnd,

        /// <summary>
        /// Represents the bitwise and-and-assign '&amp;=' operator.
        /// </summary>
        BitwiseAndAndAssign,

        /// <summary>
        /// Represents the bitwise or '|' operator.
        /// </summary>
        BitwiseOr,

        /// <summary>
        /// Represents the bitwise or-and-assign '|=' operator.
        /// </summary>
        BitwiseOrAndAssign,

        /// <summary>
        /// Represents the bitwise exclusive-or '^' operator.
        /// </summary>
        BitwiseXor,

        /// <summary>
        /// Represents the bitwise exclusive-or-and-assign '^=' operator.
        /// </summary>
        BitwiseXorAndAssign,

        /// <summary>
        /// Represents the bitwise shift-left '&lt;&lt;' operator.
        /// </summary>
        ShiftLeft,

        /// <summary>
        /// Represents the bitwise shift-left-and-assign '&lt;&lt;=' operator.
        /// </summary>
        ShiftLeftAndAssign,

        /// <summary>
        /// Represents the bitwise shift-right '&gt;&gt;' operator.
        /// </summary>
        ShiftRight,

        /// <summary>
        /// Represents the bitwise shift-right-and-assign '&gt;&gt;=' operator.
        /// </summary>
        ShiftRightAndAssign,

        /// <summary>
        /// Represents the equals '==' operator.
        /// </summary>
        Equals,

        /// <summary>
        /// Represents the identical '===' operator.
        /// </summary>
        Identical,

        /// <summary>
        /// Represents the not-equal '!=' operator.
        /// </summary>
        NotEqual,

        /// <summary>
        /// Represents the not-identical '!==' operator.
        /// </summary>
        NotIdentical,

        /// <summary>
        /// Represents the greater-than '&gt;' operator.
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Represents the greater-than-or-equals-to '&gt;=' operator.
        /// </summary>
        GreaterThanOrEqualTo,

        /// <summary>
        /// Represents the less-than '&lt;' operator.
        /// </summary>
        LessThan,

        /// <summary>
        /// Represents the less-than-or-equals-to '&lt;=' operator.
        /// </summary>
        LessThanOrEqualTo,

        /// <summary>
        /// Represents the logical and '&amp;&amp;' operator.
        /// </summary>
        LogicalAnd,

        /// <summary>
        /// Represents the logical or '||' operator.
        /// </summary>
        LogicalOr,

        /// <summary>
        /// Represents the instance-of operator.
        /// </summary>
        InstanceOf,

        /// <summary>
        /// Represents the in operator.
        /// </summary>
        In,

        /// <summary>
        /// Represents the multiple evaluation ',' operator.
        /// </summary>
        MultipleEvaluation,
    }
}
