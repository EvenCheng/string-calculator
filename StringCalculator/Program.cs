using System;
using StringCalculator;

namespace StringCalculatorApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var calculator = new Calculator();
            Console.WriteLine("Enter numbers to add. Press Ctrl+C to exit.");

            while (true)
            {
                Console.Write("Input: ");
                string input = Console.ReadLine();
                try
                {
                    var result = calculator.Add(input);
                    Console.WriteLine(result.ToString());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
