namespace Adam.JSGenerator
{
    /// <summary>
    /// Represents the unary operator to use in an unary operation.
    /// </summary>
    public enum UnaryOperator
    {
        /// <summary>
        /// Represents the unary number '+' operator.
        /// </summary>
        Number,

        /// <summary>
        /// Represents the unary negative '-' operator.
        /// </summary>
        Negative,

        /// <summary>
        /// Represents the bitwise not '~' operator.
        /// </summary>
        BitwiseNot,

        /// <summary>
        /// Represents the logical not '!' operator.
        /// </summary>
        LogicalNot,

        /// <summary>
        /// Represents the pre-increment '++' operator.
        /// </summary>
        PreIncrement,

        /// <summary>
        /// Represents the post-increment '++' operator.
        /// </summary>
        PostIncrement,

        /// <summary>
        /// Represents the pre-decremenet '--' operator.
        /// </summary>
        PreDecrement,

        /// <summary>
        /// Represents the post-decrement '--' operator.
        /// </summary>
        PostDecrement,

        /// <summary>
        /// Represents the typeof operator.
        /// </summary>
        Typeof,

        /// <summary>
        /// Represents the new operator.
        /// </summary>
        New,

        /// <summary>
        /// Represents the delete operator.
        /// </summary>
        Delete,

        /// <summary>
        /// Represents the group operator.
        /// </summary>
        Group
    }
}
