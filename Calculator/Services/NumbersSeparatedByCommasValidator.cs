using Calculator.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Calculator.Services
{
    public class NumbersSeparatedByCommasValidator : IValidator
    {
        public bool IsValid(string input)
        {
            string pattern = @"^([0-9]+,)*[0-9]+$";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                return true;
            }

            return false;
        }
    }
}