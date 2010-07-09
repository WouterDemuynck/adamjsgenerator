using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    [TestClass]
    public class ExpectTests
    {
        [TestMethod]
        public void ThrowExpectsException()
        {
            Expect.Throw<Exception>(() =>
                {
                    throw new Exception();
                });

            Expect.Throw<ApplicationException>("Ha!",
                () => { throw new ApplicationException("Ha!"); });
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ThrowsRequiresException()
        {
            Expect.Throw<InvalidOperationException>(() => { });
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ThrowsRequiresExceptionWithMessage()
        {
            Expect.Throw<InvalidOperationException>("Needs a message.",
                () => { throw new InvalidOperationException(); });
        }
    }
}
