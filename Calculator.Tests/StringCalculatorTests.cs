using Xunit;

namespace Calculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ZeroReturned()
        {
            // arrange
            StringCalculator calculator = new StringCalculator();

            // act
            var result = calculator.Add(string.Empty);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_OneNumber_TheSameNumberReturned()
        {
            // arrange
            StringCalculator calculator = new StringCalculator();

            // act
            var result = calculator.Add("1");

            // assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_TwoCommaSeparatedNumbers_SumOfNumbersReturned()
        {
            // arrange
            StringCalculator calculator = new StringCalculator();

            // act
            var result = calculator.Add("1,2");

            // assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_UnknownAmountOfNumbersSeparatedByCommas_SumOfNumbersReturned()
        {
            // arrange
            StringCalculator calculator = new StringCalculator();

            // act
            var result = calculator.Add("1,1,1,1,1,1,1,1,1,1");

            // assert
            Assert.Equal(10, result);
        }
    }
}