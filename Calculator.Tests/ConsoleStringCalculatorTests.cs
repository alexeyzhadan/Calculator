using Calculator.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Calculator.Tests
{
    public class ConsoleStringCalculatorTests
    {
        Mock<IConsole> consoleMock;
        StringCalculator stringCalculator;
        ConsoleStringCalculator consoleCalculator;

        public ConsoleStringCalculatorTests()
        {
            consoleMock = new Mock<IConsole>();
            stringCalculator = new StringCalculator();
            consoleCalculator = new ConsoleStringCalculator(consoleMock.Object, stringCalculator);
        }

        [Fact]
        public void Run_CountOfIterationEqualsTen_CountOfCalculatingShouldNotBeMoreThanTen()
        {
            // arrange
            int countOfIteration = 10;
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
        public void Run_InConsoleEnteredEmptyString_ShouldStopAskingForNumbers()
        {
            // arrange
            consoleMock.Setup(c => c.ReadLine()).Returns(string.Empty);

            // act
            consoleCalculator.Run(10);

            // assert
            consoleMock.Verify(c => c.ReadLine(), Times.Once);
        }

        [Fact]
        public void Run_ValueWasCalculatedFirstTime_IntroMessageShouldChange()
        {
            // arrange
            var calledIntroMessages = new List<string>();

            consoleMock
                .Setup(c => c.WriteLine(It.IsAny<string>()))
                .Callback<string>(a => calledIntroMessages.Add(a));

            consoleMock.Setup(c => c.ReadLine()).Returns("1,2");

            // act
            consoleCalculator.Run(2);

            // assert
            Assert.Contains(calledIntroMessages, m => m.StartsWith("Repeat"));
        }

        [Fact]
        public void Run_InConsoleEnteredStringOfNumbers_ShouldDisplayCorrectlySumOnConsole()
        {
            // arrange
            var calledResultMessage = new List<string>();

            consoleMock
                .Setup(c => c.WriteLine(
                    It.Is<string>(s => s.StartsWith("Sum"))))
                .Callback<string>(a => calledResultMessage.Add(a));

            consoleMock.Setup(c => c.ReadLine()).Returns("1,2");

            // act
            consoleCalculator.Run(10);

            // assert
            Assert.All(calledResultMessage, m => m.Contains("3"));
        }

        [Fact]
        public void Run_CountOfIterationIsNegative_ShouldExitFromMethod()
        {
            // arrange

            // act
            consoleCalculator.Run(-10);

            // assert
            consoleMock.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Never);
        }

    }
}