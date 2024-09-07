using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        // Public method to parse the input and return the result and formula
        public CalculationResult Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new CalculationResult(0, "0");

            string numberStr = input;
            List<string> delimiters = new List<string> { ",", "\n" }; // Default delimiters

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
                        foreach (Match match in matches)
                        {
                            delimiters.Add(match.Groups[1].Value); // Add each custom delimiter to the list
                        }
                    }
                    else
                    {
                        delimiters.Add(delimiterPart); // Single character delimiter
                    }

                    numberStr = input.Substring(delimiterEndIndex + 1); // Get the numbers part
                }
            }

            // List to store any negative numbers found
            List<int> negativeNumbers = new List<int>();

            // Split the input by any of the delimiters
            var numberArr = numberStr.Split(delimiters.ToArray(), StringSplitOptions.None);

            int sum = 0;
            List<string> formulaParts = new List<string>(); // Store each part of the formula

            foreach (var number in numberArr)
            {
                if (int.TryParse(number, out int result))
                {
                    if (result < 0)
                    {
                        // Add negative number to the list
                        negativeNumbers.Add(result);
                    }
                    else if (result <= 1000)
                    {
                        // Add valid number to sum and formula
                        sum += result;
                        formulaParts.Add(result.ToString());
                    }
                    else
                    {
                        // Add 0 for ignored values greater than 1000
                        formulaParts.Add("0");
                    }
                }
                else
                {
                    // Invalid numbers are treated as 0
                    formulaParts.Add("0");
                }
            }

            // If there are negative numbers, throw an exception
            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            // Build the formula as a string
            string formula = string.Join("+", formulaParts);

            return new CalculationResult(sum, formula);
        }
    }
}
