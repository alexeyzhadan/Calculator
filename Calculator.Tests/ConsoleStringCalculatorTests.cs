using Calculator.Interfaces;
using Calculator.Tests.Mocks;
using Moq;
using Xunit;

namespace Calculator.Tests
{
    public class ConsoleStringCalculatorTests
    {
        Mock<IConsole> consoleMock;
        StringCalculatorMock stringCalculatorMock;
        ConsoleStringCalculator consoleCalculator;

        public ConsoleStringCalculatorTests()
        {
            consoleMock = new Mock<IConsole>();
            stringCalculatorMock = new StringCalculatorMock();
            consoleCalculator = new ConsoleStringCalculator(consoleMock.Object, stringCalculatorMock);
        }

        [Fact]
        public void Run_MethodRunned_ShouldDisplayIntroMessageOnConsole()
        {
            // arrange
            consoleMock.Setup(c => c.ReadLine()).Returns(string.Empty);

            // act
            consoleCalculator.Run();

            // assert
            consoleMock.Verify(c => c.WriteLine("Enter numbers separated by commas:"));
        }

        [Fact]
        public void Run_SumCalculatedFirstTime_IntroMessageShouldChange()
        {
            // arrange
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1,2")
                .Returns(string.Empty);

            // act
            consoleCalculator.Run();

            // assert
            consoleMock.Verify(
                c => c.WriteLine(It.Is<string>(
                    s => s.Contains("Repeat or press Enter for exit:"))),
                Times.Once);
        }

        [Fact]
        public void Run_InConsoleEnteredStringOfNumbers_ShouldDisplayMessageWithSumOnConsole()
        {
            // arrange
            consoleMock
                .SetupSequence(c => c.ReadLine())
                .Returns("1,2")
                .Returns(string.Empty);

            // act
            consoleCalculator.Run();

            // assert
            consoleMock.Verify(
                c => c.WriteLine(It.Is<string>(
                    s => s.Contains("Sum of numbers equals 3"))));
        }

        [Fact]
        public void Run_InConsoleEnteredEmptyString_ShouldStopAskingForNumbersAndExit()
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