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

            // Replace newline characters with commas to standardize the delimiter
            input = input.Replace("\n", ",");

            var numbers = input.Split(',');

            // List to store any negative numbers found
            List<int> negativeNumbers = new List<int>();

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
                    else
                    {
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
