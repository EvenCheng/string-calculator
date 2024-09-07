using System;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var numbers = input.Split(',');

            int sum = 0;

            foreach (var number in numbers)
            {
                if (int.TryParse(number, out int result))
                {
                    sum += result;
                }
                else
                {
                    sum += 0; // Invalid numbers are treated as 0
                }
            }

            return sum;
        }
    }
}
