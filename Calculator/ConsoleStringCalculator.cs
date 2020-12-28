using Calculator.Interfaces;

namespace Calculator
{
    public class ConsoleStringCalculator
    {
        private readonly IConsole _console;
        private readonly StringCalculator _calculator;

        public ConsoleStringCalculator(IConsole console, StringCalculator calculator)
        {
            _console = console;
            _calculator = calculator;
        }

        public void Run()
        {
            string stringOfNumbers;
            string outputString = "Enter numbers separated by commas:";
            bool outputWasChanged = false;

            while (true)
            {
                _console.WriteLine(outputString);

                stringOfNumbers = _console.ReadLine();

                if (stringOfNumbers == string.Empty)
                {
                    break;
                }

                _console.WriteLine($"Sum of numbers equals {_calculator.Add(stringOfNumbers)}\n");

                if (!outputWasChanged)
                {
                    outputString = "Repeat or press Enter for exit:";
                }
            }
        }

    }
}