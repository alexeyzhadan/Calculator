using Calculator.Interfaces;
using Moq;
using Xunit;

namespace Calculator.Tests
{
    public class ConsoleStringCalculatorTests
    {
        Mock<IConsole> consoleMock;
        Mock<StringCalculator> stringCalculatorMock;
        ConsoleStringCalculator consoleCalculator;

        public ConsoleStringCalculatorTests()
        {
            consoleMock = new Mock<IConsole>();
            stringCalculatorMock = new Mock<StringCalculator>();
            consoleCalculator = new ConsoleStringCalculator(consoleMock.Object, stringCalculatorMock.Object);
        }

        [Fact]
        public void Run_MethodRunned_ShouldDisplayIntroMessage()
        {
            // arrange
            consoleMock.Setup(c => c.ReadLine()).Returns(string.Empty);

            // act
            consoleCalculator.Run();

            // assert
            consoleMock.Verify(c => c.WriteLine("Enter numbers separated by commas:"));
        }

        [Fact]
        public void Run_EnteredStringOfNumbers_ShouldDisplayMessageWithSum()
        {
            // arrange
            consoleMock
                .SetupSequence(c => c.ReadLine())
                .Returns("1,2")
                .Returns(string.Empty);

            // act
            consoleCalculator.Run();

            // assert
            consoleMock.Verify(c => c.WriteLine("Sum of numbers equals 3"));
        }

        [Fact]
        public void Run_SumAlreadyCalculated_ShouldAllowToCalculateAgain()
        {
            // arrange
            consoleMock
                .SetupSequence(c => c.ReadLine())
                .Returns("1,2")
                .Returns("3,4")
                .Returns(string.Empty);

            // act
            consoleCalculator.Run();

            // assert
            consoleMock.Verify(c => c.WriteLine("Sum of numbers equals 3"));
            consoleMock.Verify(c => c.WriteLine("Sum of numbers equals 7"));
        }

        [Fact]
        public void Run_SumCalculatedFirstTime_IntroMessageShouldChange()
        {
            // arrange
            consoleMock
                .SetupSequence(c => c.ReadLine())
                .Returns("1,2")
                .Returns(string.Empty);

            // act
            consoleCalculator.Run();

            // assert
            consoleMock.Verify(c => c.WriteLine("Repeat or press Enter for exit:"));
        }

        [Fact]
        public void Run_EnteredEmptyString_ShouldStopAskingForNumbersAndExit()
        {
            // arrange
            consoleMock.Setup(c => c.ReadLine()).Returns(string.Empty);

            // act
            consoleCalculator.Run();

            // assert
            consoleMock.Verify(c => c.ReadLine(), Times.Once);
        }
    }
}