using Calculator.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Calculator.Tests
{
    public class ConsoleStringCalculatorTests
    {
        [Fact]
        void Run_CountOfIterationEqualsTen_CountOfCalculatingShouldNotBeMoreThanTen()
        {
            // arrange
            int countOfIteration = 10;
            var consoleMock = new Mock<IConsole>();
            var stringCalculator = new StringCalculator();
            var consoleCalculator = new ConsoleStringCalculator(consoleMock.Object, stringCalculator);
            var countOfCalledReadLineMethod = 0;

            consoleMock
                .Setup(c => c.ReadLine())
                .Callback(() => countOfCalledReadLineMethod++)
                .Returns("1,2");

            // act
            consoleCalculator.Run(countOfIteration);

            // assert
            Assert.True(countOfIteration >= countOfCalledReadLineMethod);
        }

        [Fact]
        void Run_InConsoleEnteredEmptyString_ShouldExitFromTheMethod()
        {
            // arrange
            var consoleMock = new Mock<IConsole>();
            var stringCalculator = new StringCalculator();
            var consoleCalculator = new ConsoleStringCalculator(consoleMock.Object, stringCalculator);

            consoleMock.Setup(c => c.ReadLine()).Returns(string.Empty);

            // act
            consoleCalculator.Run();

            // assert
            consoleMock.Verify(c => c.ReadLine(), Times.Once);
        }

        [Fact]
        void Run_ValueWasCalculatedFirstTime_TheIntroMessageShouldChange()
        {
            // arrange
            int countOfIteration = 2;
            var consoleMock = new Mock<IConsole>();
            var stringCalculator = new StringCalculator();
            var consoleCalculator = new ConsoleStringCalculator(consoleMock.Object, stringCalculator);
            var calledIntroMessages = new List<string>();

            consoleMock
                .Setup(c => c.WriteLine(It.IsAny<string>()))
                .Callback<string>(a => calledIntroMessages.Add(a));

            consoleMock.Setup(c => c.ReadLine()).Returns("1,2");

            // act
            consoleCalculator.Run(countOfIteration);

            // assert
            Assert.Contains(calledIntroMessages, m => m.StartsWith("Repeat"));
        }

        [Fact]
        void Run_InConsoleEnteredStringOfNumbers_ShouldDisplayCorrectlySumOnConsole()
        {
            // arrange
            int countOfIteration = 10;
            var consoleMock = new Mock<IConsole>();
            var stringCalculator = new StringCalculator();
            var consoleCalculator = new ConsoleStringCalculator(consoleMock.Object, stringCalculator);
            var calledResultMessage = new List<string>();

            consoleMock
                .Setup(c => c.WriteLine(
                    It.Is<string>(s => s.StartsWith("Sum"))))
                .Callback<string>(a => calledResultMessage.Add(a));

            consoleMock.Setup(c => c.ReadLine()).Returns("1,2");

            // act
            consoleCalculator.Run(countOfIteration);

            // assert
            Assert.All(calledResultMessage, m => m.Contains("3"));
        }
    }
}