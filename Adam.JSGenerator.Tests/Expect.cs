using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
    public static class Expect
    {
        public static void Throw<T>(Action action) where T : Exception
        {
            Throw<T>(null, action);
        }

        public static void Throw<T>(string message, Action action) where T : Exception
        {
            try
            {
                action();

                throw new AssertFailedException("Action did not throw the expected exception.");
            }
            catch (T e)
            {
                if (message != null && e.Message != message)
                {
                    string error = string.Format(
                        "The thrown exception did not contain the required message. Expected: {0}, Actual: {1}",
                        message, e.Message);
                    throw new AssertFailedException(error, e);
                }                
            }
            catch (Exception e)
            {
                string error = string.Format(
                    "Action did not throw the required exception. Expected: {0}, Actual: {1}",
                    typeof(T).Name, e.GetType().Name);
                throw new AssertFailedException(error, e);
            }
        }
    }
}
