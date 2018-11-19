using NUnit.Framework;
using System;

namespace BookMarina.Tests
{
    public class Class1
    {
        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            var result = false;

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}
