namespace MultiplesOf3or5
{
    public class MultiplesOf3or5TestTemplate1
    {
        [Fact]
        public void GivenNegativeInput_Return0()
        {
            var multiplesOf3or5 = new MultiplesOf3or5(-1);
            Assert.Equal(0, multiplesOf3or5.Sum());
        }

        [Fact]
        public void Given0_Return0()
        {
            var multiplesOf3or5 = new MultiplesOf3or5(0);
            Assert.Equal(0, multiplesOf3or5.Sum());
        }

        [Fact]
        public void Given4_Return3()
        {
            var multiplesOf3or5 = new MultiplesOf3or5(4);
            Assert.Equal(3, multiplesOf3or5.Sum());
        }

        [Fact]
        public void Given10_Return23()
        {
            var multiplesOf3or5 = new MultiplesOf3or5(10);
            Assert.Equal(23, multiplesOf3or5.Sum());
        }

        [Fact]
        public void Given20_Return78()
        {
            var multiplesOf3or5 = new MultiplesOf3or5(20);
            Assert.Equal(78, multiplesOf3or5.Sum());
        }

        [Fact]
        public void Given200_Return9168()
        {
            var multiplesOf3or5 = new MultiplesOf3or5(200);
            Assert.Equal(9168, multiplesOf3or5.Sum());
        }
    }
}
