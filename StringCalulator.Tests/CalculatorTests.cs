using System;
using Xunit;
using StringCalculator;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            var input = "";
            var result = _calculator.Add(input);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_SingleNumber_ReturnsThatNumber()
        {
            var input = "20";
            var result = _calculator.Add(input);
            Assert.Equal(20, result);
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsTheirSum()
        {
            var input = "1,1000";
            var result = _calculator.Add(input);
            Assert.Equal(1001, result);
        }

        [Fact]
        public void Add_NegativeNumber_ThrowsException()
        {
            var input = "4,-3";
            
            var exception = Assert.Throws<ArgumentException>(() => _calculator.Add(input));

            Assert.Equal("Negatives not allowed: -3", exception.Message);
        }

        [Fact]
        public void Add_MultipleNegativeNumbers_ThrowsExceptionWithAllNegatives()
        {
            var input = "1,-2,3,-4,5";
            
            var exception = Assert.Throws<ArgumentException>(() => _calculator.Add(input));

            Assert.Equal("Negatives not allowed: -2, -4", exception.Message);
        }

        [Fact]
        public void Add_MultipleNumbers_ReturnsTheirSum()
        {
            var input = "1,2,3,4,5,6,7,8,9,10,11,12";
            var result = _calculator.Add(input);
            Assert.Equal(78, result);
        }

        [Fact]
        public void Add_NumberGreaterThan1000_IgnoredInSum()
        {
            var input = "2,1001,6";
            var result = _calculator.Add(input);
            Assert.Equal(8, result); // 1001 is ignored
        }

        [Fact]
        public void Add_MultipleNumbersWithValuesOver1000_ReturnsSumIgnoringLargeValues()
        {
            var input = "1,1002,1003,4,5000,10";
            var result = _calculator.Add(input);
            Assert.Equal(15, result); // Only 1, 4, and 10 are summed
        }

        [Fact]
        public void Add_InvalidNumber_TreatsAsZero()
        {
            var input = "5,tytyt";
            var result = _calculator.Add(input);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_NewlineAsDelimiter_ReturnsSum()
        {
            var input = "1\n2,3";
            var result = _calculator.Add(input);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_MultipleNewlineAndCommaDelimiters_ReturnsSum()
        {
            var input = "1\n2\n3\n4,\n5";
            var result = _calculator.Add(input);
            Assert.Equal(15, result);
        }

        [Fact]
        public void Add_OneValidAndOneEmptyNumber_ReturnsValidNumber()
        {
            var input = "4,";
            var result = _calculator.Add(input);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Add_AllInvalidNumbers_ReturnsZero()
        {
            var input = "abc,xyz";
            var result = _calculator.Add(input);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_CustomDelimiter_ReturnsSum()
        {
            var input = "//#\n2#5";
            var result = _calculator.Add(input);
            Assert.Equal(7, result); // Custom delimiter is #
        }

        [Fact]
        public void Add_CustomDelimiterWithMultipleValues_ReturnsSum()
        {
            var input = "//;\n2;5;100";
            var result = _calculator.Add(input);
            Assert.Equal(107, result); // Custom delimiter is ;
        }

        [Fact]
        public void Add_CustomDelimiterWithLargeValues_ReturnsSumIgnoringLargeValues()
        {
            var input = "//;\n2;1001;6";
            var result = _calculator.Add(input);
            Assert.Equal(8, result); // 1001 is ignored
        }

        [Fact]
        public void Add_CustomDelimiterInvalidNumber_ReturnsSumIgnoringInvalidNumber()
        {
            var input = "//,\n2,ff,100";
            var result = _calculator.Add(input);
            Assert.Equal(102, result); // ff is ignored
        }
        
    }
}
