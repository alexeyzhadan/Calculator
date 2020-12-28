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
        private const string START_SQUARE_BRACKET = "[";
        private const string END_SQUARE_BRACKET = "]";

        private const int FIRST_ELEMENT = 0;
        private const int SECOND_ELEMENT = 1;

        private const int ZERO = 0;
        private const int TWO = 2;
        private const int THOUSAND = 1000;

        public int Add(string numbers)
        {
            string[] arrayOfStringNumbers;
            int resultSum = ZERO;
            List<string> negativeNumbers;
            int tempNumber;

            if (numbers == string.Empty)
            {
                return resultSum;
            }

            if (numbers.StartsWith(DOUBLE_SLASH))
            {
                arrayOfStringNumbers = 
                    GetNumbersFromStringWithCustomDelimiters(numbers);
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
                tempNumber = int.Parse(number);
                if (tempNumber > THOUSAND)
                {
                    continue;
                }

                resultSum += tempNumber;
            }

            return resultSum;
        }

        private string[] GetNumbersFromStringWithCustomDelimiters(string stringOfNumbers)
        {
            string[] stringLines;
            string[] numbers;
            string[] delimiters;

            stringLines = stringOfNumbers.Split(NEW_LINE, StringSplitOptions.RemoveEmptyEntries);

            delimiters = stringLines[FIRST_ELEMENT].Split(
                new string[] { START_SQUARE_BRACKET, END_SQUARE_BRACKET }, StringSplitOptions.RemoveEmptyEntries);

            if (delimiters.Length == 1)
            {
                delimiters[FIRST_ELEMENT] = stringLines[FIRST_ELEMENT].Substring(TWO);
            }

            numbers = stringLines[SECOND_ELEMENT].Split(
                delimiters, StringSplitOptions.RemoveEmptyEntries);

            return numbers;
        }
    }
}