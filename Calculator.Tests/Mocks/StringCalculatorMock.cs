namespace Calculator.Tests.Mocks
{
    class StringCalculatorMock : StringCalculator
    {
        public new int Add(string stringOfNumbers)
        {
            int sumOfNumbers = 0;
            string[] stringNumbers = stringOfNumbers.Split(",");

            foreach (var stringNumber in stringNumbers)
            {
                sumOfNumbers = int.Parse(stringNumber);
            }

            return sumOfNumbers;
        }
    }
}