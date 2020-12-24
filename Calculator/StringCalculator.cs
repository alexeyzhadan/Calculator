using System;

namespace Calculator
{
    public class StringCalculator
    {
        private const string COMMA = ",";

        public int Add(string numbers)
        {
            string[] arrayOfStringNumbers;
            int resultSum = 0;

            if (numbers == string.Empty)
            {
                return resultSum;
            }

            arrayOfStringNumbers = numbers.Split(COMMA, StringSplitOptions.RemoveEmptyEntries);

            foreach(string number in arrayOfStringNumbers)
            {
                resultSum += int.Parse(number);
            }

            return resultSum;
        }
    }
}