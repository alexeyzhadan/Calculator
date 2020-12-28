using Calculator.Services;
using Xunit;

namespace Calculator.Tests
{
    public class NumbersSeparatedByCommasValidatorTests
    {
        [Fact]
        public void IsValid_EmptyString_ShouldBeUnsuccessful()
        {
            // arrange
            var validator = new NumbersSeparatedByCommasValidator();

            // act
            var result = validator.IsValid(string.Empty);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_OneNumber_ShouldBeSuccessful()
        {
            // arrange
            var validator = new NumbersSeparatedByCommasValidator();

            // act
            var result = validator.IsValid("1");

            // assert
            Assert.True(result);
        }

        [Fact]
        public void IsValid_TwoNumbersSeparatedByComma_ShouldBeSuccessful()
        {
            // arrange
            var validator = new NumbersSeparatedByCommasValidator();

            // act
            var result = validator.IsValid("1,20");

            // assert
            Assert.True(result);
        }

        [Fact]
        public void IsValid_InputWithoutNumbers_ShouldBeUnsuccessful()
        {
            // arrange
            var validator = new NumbersSeparatedByCommasValidator();

            // act
            var result = validator.IsValid("asd,asdjuahf, asd");

            // assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_NumbersSeparatedByDifferentFromCommaDelimiter_ShouldBeUnsuccessful()
        {
            // arrange
            var validator = new NumbersSeparatedByCommasValidator();

            // act
            var result = validator.IsValid("1&2&3");

            // assert
            Assert.False(result);
        }
    }
}