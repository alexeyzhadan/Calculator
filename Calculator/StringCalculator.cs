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
            int countOfNumbers;

            if (numbers == string.Empty)
            {
                return resultSum;
            }

            arrayOfStringNumbers = numbers.Split(COMMA, StringSplitOptions.RemoveEmptyEntries);
            countOfNumbers = arrayOfStringNumbers.Length;

            if (countOfNumbers > 2)
            { 
                countOfNumbers = 2;
            }

            for(int i = 0; i < countOfNumbers; i++)
            {
                resultSum += int.Parse(arrayOfStringNumbers[i]);
            }

            return resultSum;
        }
    }
}