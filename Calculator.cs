using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string delimiter = ",";
            string numberStr = input;

            // Check for custom delimiter
            if (input.StartsWith("//"))
            {
                int delimiterEndIndex = input.IndexOf('\n');
                if (delimiterEndIndex != -1)
                {
                    string delimiterPart = input.Substring(2, delimiterEndIndex - 2); // Get the custom delimiter part

                    // Check if the delimiter is enclosed in brackets (custom delimiter of any length)
                    if (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
                    {
                        delimiter = delimiterPart.Substring(1, delimiterPart.Length - 2); // Extract the delimiter between brackets
                    }
                    else
                    {
                        delimiter = delimiterPart; // Single character delimiter
                    }

                    numberStr = input.Substring(delimiterEndIndex + 1); // Get the numbers part
                }
            }

            // List to store any negative numbers found
            List<int> negativeNumbers = new List<int>();
            // Replace newline characters with the custom delimiter
            numberStr = numberStr.Replace("\n", delimiter);

            var numberArr = numberStr.Split(new string[] { delimiter }, StringSplitOptions.None);

            int sum = 0;

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
                        // Only add numbers that are 1000 or less
                        sum += result;
                    }
                }
                else
                {
                    sum += 0; // Invalid numbers are treated as 0
                }
            }

            // If there are negative numbers, throw an exception
            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return sum;
        }
    }
}
