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
            var input = "1,5000";
            var result = _calculator.Add(input);
            Assert.Equal(5001, result);
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
    }
}
