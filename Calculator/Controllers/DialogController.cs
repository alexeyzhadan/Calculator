using Calculator.Services.Interfaces;

namespace Calculator.Controllers
{
    public class DialogController
    {
        private readonly IConsole _console;

        public DialogController(IConsole console)
        {
            _console = console;
        }

        public void SendMessage(string message)
        {
            _console.WriteLine(message);
        }

        public string GetMessage()
        {
            return _console.ReadLine();
        }
    }
}