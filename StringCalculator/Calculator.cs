using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly List<string> _delimiters;
        private readonly bool _denyNegativeNumbers;
        private readonly int _upperBound;

        public Calculator(List<string> delimiters = null, bool denyNegativeNumbers = true, int upperBound = 1000)
        {
            _delimiters = delimiters ?? new List<string> { ",", "\n" }; // Default delimiters
            _denyNegativeNumbers = denyNegativeNumbers;
            _upperBound = upperBound;
        }

        public CalculationResult Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new CalculationResult(0, "0");

            string numberStr = input;

            // Check for custom delimiter
            if (input.StartsWith("//"))
            {
                int delimiterEndIndex = input.IndexOf('\n');
                if (delimiterEndIndex != -1)
                {
                    string delimiterPart = input.Substring(2, delimiterEndIndex - 2); // Get the custom delimiter part

                    // Check if multiple delimiters are enclosed in brackets
                    if (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
                    {
                        // Match all delimiters enclosed in brackets
                        var matches = Regex.Matches(delimiterPart, @"\[(.*?)\]");
                        _delimiters.Clear();
                        foreach (Match match in matches)
                        {
                            _delimiters.Add(match.Groups[1].Value); // Add each custom delimiter to the list
                        }
                    }
                    else
                    {
                        _delimiters.Clear();
                        _delimiters.Add(delimiterPart); // Single character delimiter
                    }

                    numberStr = input.Substring(delimiterEndIndex + 1); // Get the numbers part
                }
            }

            // List to store any negative numbers found
            List<int> negativeNumbers = new List<int>();

            // Split the input by any of the delimiters
            var numberArr = numberStr.Split(_delimiters.ToArray(), StringSplitOptions.None);

            int sum = 0;
            List<string> formulaParts = new List<string>(); // Store each part of the formula

            foreach (var number in numberArr)
            {
                if (int.TryParse(number, out int result))
                {
                    if (_denyNegativeNumbers && result < 0)
                    {
                        // Add negative number to the list
                        negativeNumbers.Add(result);
                    }
                    else if (result <= _upperBound)
                    {
                        // Add valid number to sum and formula
                        sum += result;
                        formulaParts.Add(result.ToString());
                    }
                    else
                    {
                        // Add 0 for ignored values greater than upper bound
                        formulaParts.Add("0");
                    }
                }
                else
                {
                    // Invalid numbers are treated as 0
                    formulaParts.Add("0");
                }
            }

            // If there are negative numbers and denial is enabled, throw an exception
            if (_denyNegativeNumbers && negativeNumbers.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            // Build the formula as a string
            string formula = string.Join("+", formulaParts);

            return new CalculationResult(sum, formula);
        }
    }
}
