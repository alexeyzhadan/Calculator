using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class StringCalculator
    {
        private const string COMMA = ",";
        private const string NEW_LINE = "\n";
        private const string DOUBLE_SLASH = "//";
        private const string MINUS = "-";

        private const int FIRST_ELEMENT = 0;
        private const int SECOND_ELEMENT = 1;

        private const int ZERO = 0;
        private const int TWO = 2;

        public int Add(string numbers)
        {
            string[] arrayOfStringNumbers;
            int resultSum = ZERO;
            string delimiter;
            string[] stringLines;
            List<string> negativeNumbers;

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

            negativeNumbers = arrayOfStringNumbers.Where(n => n.Contains(MINUS)).ToList();

            if (negativeNumbers.Count > ZERO)
            {
                throw new Exception(
                    string.Format(
                        "Negatives not allowed! Wrong numbers - [{0}]",
                        string.Join(COMMA, negativeNumbers)
                        ));
            }

            foreach(string number in arrayOfStringNumbers)
            {
                resultSum += int.Parse(number);
            }

            return resultSum;
        }
    }
}