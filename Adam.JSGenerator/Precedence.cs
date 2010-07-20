namespace Adam.JSGenerator
{
    /// <summary>
    /// Defines the precedence of an operation.
    /// </summary>
    public struct Precedence
    {
        /// <summary>
        /// Gets or sets the level of precedence of an operation. 
        /// </summary>
        /// <remarks>
        /// An operation with a higher value takes precedence over one with a lower value.
        /// </remarks>
        public int Level { get; set; }

        /// <summary>
        /// Indicates the association of precedence.
        /// </summary>
        /// <remarks>
        /// Operations with equal precedence use association to determine precedence.
        /// </remarks>
        public Association Association { get; set; }

        /// <summary>
        /// Indicates whether an expression with this precedence requires parentheses to protect its lower precedence level.
        /// </summary>
        /// <param name="against">The precedence to test against.</param>
        /// <param name="expected">The expected association.</param>
        /// <returns>True if parens are needed, otherwise false.</returns>
        public bool RequiresGrouping(Precedence against, Association expected)
        {
            return ((this.Level == against.Level) && (this.Association != expected)) ||
                (this.Level < against.Level);
        }

        /// <summary>
        /// Gets a precedence level that garuantees isolation in parentheses.
        /// </summary>
        public static Precedence Quarantine
        {
            get
            {
                return new Precedence
                {
                    Level = int.MaxValue,
                    Association = Association.LeftToRight
                };
            }
        }

        /// <summary>
        /// Determines whether the specified instances of <see cref="Precedence"/> are considered equal.
        /// </summary>
        public static bool Equals(Precedence left, Precedence right)
        {
            return int.Equals(left.Level, right.Level) && left.Association.Equals(right.Association);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified <see cref="Precedence" /> value.
        /// </summary>
        public bool Equals(Precedence other)
        {
            return Equals(this, other);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified object.
        /// </summary>
        public override bool Equals(object obj)
        {
            return (obj is Precedence) && Equals(this, (Precedence) obj);
        }

        /// <summary>
        /// Returns the hash code for this instance. 
        /// </summary>
        public override int GetHashCode()
        {
            return this.Level.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified instances of <see cref="Precedence"/> are considered equal.
        /// </summary>
        public static bool operator ==(Precedence left, Precedence right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Determines whether the specified instances of <see cref="Precedence"/> are considered not equal.
        /// </summary>
        public static bool operator !=(Precedence left, Precedence right)
        {
            return !Equals(left, right);
        }
    }
}
