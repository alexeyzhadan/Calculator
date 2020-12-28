namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new ConsoleStringCalculator(
                    new ConsoleWrapper(), new StringCalculator());

            calculator.Run();
        }
    }
}