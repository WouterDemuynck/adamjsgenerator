namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to create new instances of <see cref="ConditionalOperationExpression" />.
    /// </summary>
    public static class ConditionalOperationExpressionHelpers
    {
        /// <summary>
        /// Creates a new instance of <see cref="ConditionalOperationExpression" /> for the specified arguments.
        /// </summary>
        /// <param name="condition">The expression that serves as the condition.</param>
        /// <param name="ifTrue">The expression returned if the condition evaluates to true.</param>
        /// <param name="ifFalse">The expression returned if the condition does not evaluate to true.</param>
        /// <returns>The new instance of <see cref="ConditionalOperationExpression" />.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Iif")]
        public static ConditionalOperationExpression Iif(this object condition, object ifTrue, object ifFalse)
        {
            return new ConditionalOperationExpression(condition, ifTrue, ifFalse);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConditionalOperationExpression" /> for the specified arguments.
        /// </summary>
        /// <param name="condition">The expression that serves as the condition.</param>
        /// <param name="ifTrue">The expression returned if the condition evaluates to true.</param>
        /// <param name="ifFalse">The expression returned if the condition does not evaluate to true.</param>
        /// <returns>The new instance of <see cref="ConditionalOperationExpression" />.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Iif")]
        public static ConditionalOperationExpression Iif(this Expression condition, Expression ifTrue, Expression ifFalse)
        {
            return new ConditionalOperationExpression(condition, ifTrue, ifFalse);
        }
    }
}
