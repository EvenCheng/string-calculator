using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> delimiters = new List<string> { ",", "\n" };
            bool denyNegativeNumbers = true;
            int upperBound = 1000;

            // Parse command-line arguments
            foreach (var arg in args)
            {
                if (arg.StartsWith("--delimiter="))
                {
                    var delimiterArg = arg.Substring("--delimiter=".Length);
                    delimiters = ParseDelimiters(delimiterArg);
                }
                else if (arg == "--negatives-ok")
                {
                    denyNegativeNumbers = false;
                }
                else if (arg.StartsWith("--upper-bound="))
                {
                    if (int.TryParse(arg.Substring("--upper-bound=".Length), out int bound))
                    {
                        upperBound = bound;
                    }
                }
            }

            var calculator = new Calculator(delimiters, denyNegativeNumbers, upperBound);
            Console.WriteLine("Enter numbers to add. Press Ctrl+C to exit.");

            while (true)
            {
                Console.Write("Input: ");
                try
                {
                    var input = Console.ReadLine();
                    var result = calculator.Add(input);
                    Console.WriteLine($"Result: {result}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static List<string> ParseDelimiters(string delimiterArg)
        {
            List<string> delimiters = new List<string>();
            if (delimiterArg.StartsWith("[") && delimiterArg.EndsWith("]"))
            {
                string pattern = @"\[(.*?)\]";
                var matches = System.Text.RegularExpressions.Regex.Matches(delimiterArg, pattern);
                foreach (System.Text.RegularExpressions.Match match in matches)
                {
                    delimiters.Add(match.Groups[1].Value);
                }
            }
            else
            {
                delimiters.Add(delimiterArg);
            }
            return delimiters;
        }
    }
}
