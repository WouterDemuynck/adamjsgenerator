using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    /// <summary>
    /// Summary description for ExpectTests
    /// </summary>
    [TestClass]
    public class ExpectTests
    {
        [TestMethod]
        public void Throw_Expects_Exception()
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
        public void Throws_Requires_Exception()
        {
            Expect.Throw<InvalidOperationException>(() => { });
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Throws_Requires_Exception_With_Message()
        {
            Expect.Throw<InvalidOperationException>("Needs a message.",
                () => { throw new InvalidOperationException(); });
        }
    }
}
