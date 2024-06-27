namespace MultiplesOf3or5
{
    public class MultiplesOf3or5TestTemplate1
    {
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(4, 3)]
        [InlineData(10, 23)]
        [InlineData(20, 78)]
        [InlineData(200, 9168)]
        public void GivenInput_ReturnExpectedSum(int input, int expectedSum)
        {
            var multiplesOf3or5 = new MultiplesOf3or5(input);
            Assert.Equal(expectedSum, multiplesOf3or5.Sum());
        }
    }
}
