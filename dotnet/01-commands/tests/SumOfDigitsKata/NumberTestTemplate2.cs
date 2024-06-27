using Xunit;

namespace SumOfDigitsKata
{
    public class NumberTestTemplate2
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 1)]
        public void DigitalRoot_ShouldReturnExpectedResult(long num, int expectedRes)
        {
            Number number = new Number(num);

            long res = number.DigitalRoot();

            Assert.Equal(expectedRes, res);
        }
    }
}
