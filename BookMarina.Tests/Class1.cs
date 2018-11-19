using NUnit.Framework;

namespace BookMarina.Tests
{
    public class Class1
    {
        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            var result = true;

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}
