using Xunit;

namespace Calculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_0Returned()
        {
            // arrange
            StringCalculator calculator = new StringCalculator();
            int expected = 0;

            // act
            var result = calculator.Add(string.Empty);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_StringOf1_1Returned() 
        {
            // arrange
            StringCalculator calculator = new StringCalculator();
            string input = "1";
            int expected = 1;

            // act
            var result = calculator.Add(input);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_StringOf1and2_3Returned()
        {
            // arrange
            StringCalculator calculator = new StringCalculator();
            string input = "1,2";
            int expected = 3;

            // act
            var result = calculator.Add(input);

            // assert
            Assert.Equal(expected, result);
        }
    }
}