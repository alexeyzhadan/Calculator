using Calculator.Controllers;
using Calculator.Services.Interfaces;
using Moq;
using Xunit;

namespace Calculator.Tests
{
    public class DialogControllerTests
    {
        [Fact]
        public void GetMessage_SomeMessage_ShouldGetTheSameMessage()
        {
            // arrange
            string excepted = "Test message";
            IConsole console = Mock.Of<IConsole>(c => c.ReadLine() == excepted);
            DialogController dialog = new DialogController(console);

            // act
            string result = dialog.GetMessage();

            // assert
            Assert.Equal(excepted, result);
        }

        [Fact]
        public void GetMessage_InvalidMessage_ShouldReturnEmptyString()
        {
            // arrange
            Mock<IConsole> console = new Mock<IConsole>();
            DialogController dialog = new DialogController(console.Object);
            IValidator validator = Mock.Of<IValidator>(v =>
                v.IsValid(It.IsAny<string>()) == false);

            // act
            string result = dialog.GetMessage(validator);

            // assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void SendMessage_SomeMessage_ShouldCallMethodWriteLineWithTheSameMessageOneTime()
        {
            // arrange
            string message = "Test message";
            Mock<IConsole> console = new Mock<IConsole>();
            DialogController dialog = new DialogController(console.Object);

            // act
            dialog.SendMessage(message);

            // assert
            console.Verify(c => c.WriteLine(message), Times.Once);
        }
    }
}