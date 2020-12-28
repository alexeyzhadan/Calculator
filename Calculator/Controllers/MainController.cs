using Calculator.Services.Interfaces;
using Calculator.Services;

namespace Calculator.Controllers
{
    public class MainController
    {
        public void Run()
        {
            IConsole console = new ConsoleWrapper();
            StringCalculator calculator = new StringCalculator();
            DialogController dialog = new DialogController(console);
            IValidator validator = new NumbersSeparatedByCommasValidator();

            string stringOfNumbers;

            while (true)
            {
                dialog.SendMessage("Enter numbers separated by commas:");

                stringOfNumbers = dialog.GetMessage(validator);

                if (stringOfNumbers == string.Empty)
                {
                    break;
                }

                dialog.SendMessage($"Sum of numbers equal {calculator.Add(stringOfNumbers)}\n");
            }
        }
    }
}