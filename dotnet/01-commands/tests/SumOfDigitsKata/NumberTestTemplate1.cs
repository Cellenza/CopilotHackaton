using Xunit;

namespace SumOfDigitsKata
{
    public class NumberTestTemplate1
    {
        [Fact]
        public void Given0_ResultShouldBe0()
        {
            long num = 0;
            int expectedRes = 0;
            Number number = new Number(num);

            long res = number.DigitalRoot();

            Assert.Equal(expectedRes, res);
        }

        [Fact]
        public void Given10_ResultShouldBe1()
        {
            long num = 10;
            int expectedRes = 1;
            Number number = new Number(num);

            long res = number.DigitalRoot();

            Assert.Equal(expectedRes, res);
        }
    }
}