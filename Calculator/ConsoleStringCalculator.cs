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

        public void Run(int countOfIteration = int.MaxValue)
        {
            string stringOfNumbers;
            string introMessage = "Enter numbers separated by commas:";
            bool introMessageWasChanged = false;

            for(int i = 0; i < countOfIteration; i++)
            {
                _console.WriteLine(introMessage);

                stringOfNumbers = _console.ReadLine();

                if (stringOfNumbers == string.Empty)
                {
                    break;
                }

                _console.WriteLine($"Sum of numbers equals {_calculator.Add(stringOfNumbers)}\n");

                if (!introMessageWasChanged)
                {
                    introMessage = "Repeat or press Enter for exit:";
                    introMessageWasChanged = true;
                }
            }
        }
    }
}