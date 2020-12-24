using System;

namespace Calculator
{
    public class StringCalculator
    {
        private const string COMMA = ",";
        private const string NEW_LINE = "\n";
        private const string DOUBLE_SLASH = "//";

        private const int FIRST_ELEMENT = 0;
        private const int SECOND_ELEMENT = 1;

        private const int TWO = 2;

        public int Add(string numbers)
        {
            string[] arrayOfStringNumbers;
            int resultSum = 0;
            string delimiter;
            string[] stringLines;

            if (numbers == string.Empty)
            {
                return resultSum;
            }

            if (numbers.StartsWith(DOUBLE_SLASH))
            {
                stringLines = numbers.Split(NEW_LINE, StringSplitOptions.RemoveEmptyEntries);

                delimiter = stringLines[FIRST_ELEMENT].Substring(TWO);

                arrayOfStringNumbers = stringLines[SECOND_ELEMENT].Split(
                    delimiter, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                arrayOfStringNumbers = numbers.Split(
                    new string[] { COMMA, NEW_LINE }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach(string number in arrayOfStringNumbers)
            {
                resultSum += int.Parse(number);
            }

            return resultSum;
        }
    }
}