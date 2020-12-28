using Calculator.Controllers;
using Calculator.Services.Interfaces;
using Moq;
using Xunit;

namespace Calculator.Tests
{
    public class DialogControllerTests
    {
        [Fact]
        public void GetMessage_SomeMessage_ShouldToGetTheSameMessage()
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
        public void SendMessage_SomeMessage_ShouldToCallMethodWriteLineWithTheSameMessageOneTime()
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