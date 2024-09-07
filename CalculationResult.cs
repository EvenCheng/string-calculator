namespace StringCalculator
{
    public class CalculationResult
    {
        // Private fields
        private int _sum;
        private string _formula;

        // Constructor to initialize the fields
        public CalculationResult(int sum, string formula)
        {
            _sum = sum;
            _formula = formula;
        }

        // Override ToString() to display the formula and sum
        public override string ToString()
        {
            return $"{_formula} = {_sum}";
        }

        // Public method to return just the sum
        public int ToNumbers()
        {
            return _sum;
        }
    }
}
