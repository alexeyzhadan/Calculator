using System;

namespace Calculator
{
    public class StringCalculator
    {
        private const string COMMA = ",";
        private const string NEW_LINE = "\n";

        public int Add(string numbers)
        {
            string[] arrayOfStringNumbers;
            int resultSum = 0;

            if (numbers == string.Empty)
            {
                return resultSum;
            }

            arrayOfStringNumbers = numbers.Split(
                new string[] { COMMA, NEW_LINE }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string number in arrayOfStringNumbers)
            {
                resultSum += int.Parse(number);
            }

            return resultSum;
        }
    }
}