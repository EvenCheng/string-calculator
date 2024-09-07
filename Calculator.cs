using System;
using System.Collections.Generic;
using System.Linq;

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

            // Check if the input starts with the custom delimiter format
            if (input.StartsWith("//"))
            {
                int delimiterEndIndex = input.IndexOf('\n');
                if (delimiterEndIndex != -1)
                {
                    delimiter = input.Substring(2, delimiterEndIndex - 2); // Get the custom delimiter
                    numberStr = input.Substring(delimiterEndIndex + 1); // Get the numbers part
                }
            }

            // List to store any negative numbers found
            List<int> negativeNumbers = new List<int>();
            // Replace newline characters with the custom delimiter
            numberStr = numberStr.Replace("\n", delimiter);

            var numbers = numberStr.Split(delimiter);

            int sum = 0;

            foreach (var number in numbers)
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
