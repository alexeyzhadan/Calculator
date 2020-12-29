using System;
using Xunit;

namespace Calculator.Tests
{
    public class StringCalculatorTests
    {
        StringCalculator calculator;

        public StringCalculatorTests()
        {
            calculator = new StringCalculator();
        }

        [Fact]
        public void Add_EmptyString_ShouldReturnZero()
        {
            // arrange

            // act
            var result = calculator.Add(string.Empty);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_OneNumber_ShouldReturnTheSameNumber()
        {
            // arrange

            // act
            var result = calculator.Add("1");

            // assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_TwoCommaSeparatedNumbers_ShouldReturnSumOfNumbers()
        {
            // arrange

            // act
            var result = calculator.Add("1,2");

            // assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_UnknownAmountOfNumbers_ShouldReturnSumOfNumbers()
        {
            // arrange

            // act
            var result = calculator.Add("1,1,1,1,1,1,1,1,1,1");

            // assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Add_NumbersSeparatedByCommaAndNewLine_ShouldAllowUsingNewLineAsDelimiter()
        {
            // arrange

            // act
            var result = calculator.Add("1\n2,3");

            // assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_NumbersSeparatedBySingleCustomDelimiter_ShouldAllowUsingAnyDilimiter()
        {
            // arrange

            // act
            var result = calculator.Add("//;\n1;2");

            // assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_PositiveAndNegativeNumbers_ShouldThrowExceptionWhenNegative()
        {
            // arrange

            // act
            Action act = () => calculator.Add("1,2,-2,-3");

            // assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Contains("Negatives not allowed!", exception.Message);
        }

        [Fact]
        public void Add_SmallAndBigNumbers_ShouldIgnoreNumbersGreaterThan1000()
        {
            // arrange

            // act
            var result = calculator.Add("1001,2");

            // assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_NumbersSeparatedByDelimiterWithLengthGreaterThanOne_ShouldAllowUsingDelimiterWithAnyLength()
        {
            // arrange

            // act
            var result = calculator.Add("//[***]\n1***2***3");

            // assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_NumbersSeparatedByMultipleDelimiters_ShouldAllowUsingAnyCountOfDelimiters()
        {
            // arrange

            // act
            var result = calculator.Add("//[*][%]\n1*2%3");

            // assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_NumbersSeparatedByMultipleDelimitersWithAnyLength_ShouldAllowToSupportAnyDelimiters()
        {
            // arrange

            // act
            var result = calculator.Add("//[*][%][***]\n1***2***1*2%3");

            // assert
            Assert.Equal(9, result);
        }
    }
}