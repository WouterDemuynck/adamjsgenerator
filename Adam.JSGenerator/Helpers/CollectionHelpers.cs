using System;
using System.Collections.Generic;
using System.Linq;

namespace Adam.JSGenerator
{
    /// <summary>
    /// Provides extension methods to work with sequences.
    /// </summary>
    public static class CollectionHelpers
    {
        /// <summary>
        /// Returns an <see cref="IEnumerable{Statement}" /> that replaces null elements in the specified sequence with instances of <see cref="EmptyStatement" />.
        /// </summary>
        /// <param name="qry">The sequence to filter.</param>
        /// <returns>A sequence of statements.</returns>
        public static IEnumerable<Statement> WithConvertedNulls(this IEnumerable<Statement> qry)
        {
            if (qry == null)
            {
                throw new ArgumentNullException("qry");
            }

            return qry.Select(obj => obj ?? new EmptyStatement());
        }

        /// <summary>
        /// Return an <see cref="IEnumerable{Expression}" /> that replaces null elements in the specified sequence with instances of <see cref="NullExpression" />. 
        /// </summary>
        /// <param name="qry">The sequence to filter.</param>
        /// <returns>A sequence of expressions.</returns>
        public static IEnumerable<Expression> WithConvertedNulls(this IEnumerable<Expression> qry)
        {
            if (qry == null)
            {
                throw new ArgumentNullException("qry");
            }

            return qry.Select(obj => obj ?? new NullExpression());
        }
    }
}
