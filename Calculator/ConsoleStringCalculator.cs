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
            int sumOfNumbers;

            _console.WriteLine("Enter numbers separated by commas:");

            while(true)
            {
                stringOfNumbers = _console.ReadLine();

                if (stringOfNumbers == string.Empty)
                {
                    break;
                }

                sumOfNumbers = _calculator.Add(stringOfNumbers);

                _console.WriteLine($"Sum of numbers equals {sumOfNumbers}\n\nRepeat or press Enter for exit:");
            }
        }
    }
}