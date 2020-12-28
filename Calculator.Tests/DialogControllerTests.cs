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
        public void GetMessage_ValidMessage_ShouldReturnTheSameMessage()
        {
            // arrange
            string input = "1,2,3,4";
            Mock<IConsole> console = new Mock<IConsole>();
            DialogController dialog = new DialogController(console.Object);
            Mock<IValidator> validator = new Mock<IValidator>();

            console.Setup(c => c.ReadLine()).Returns(input);
            validator.Setup(v => v.IsValid(input)).Returns(true);

            // act
            string result = dialog.GetMessage(validator.Object);

            // assert
            Assert.Equal(input, result);
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