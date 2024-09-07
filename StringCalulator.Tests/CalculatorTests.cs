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
            // Arrange
            var input = "";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_SingleNumber_ReturnsThatNumber()
        {
            // Arrange
            var input = "20";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(20, result);
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsTheirSum()
        {
            // Arrange
            var input = "1,5000";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(5001, result);
        }

        [Fact]
        public void Add_NegativeNumber_ReturnsSum()
        {
            // Arrange
            var input = "4,-3";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_MultipleNumbers_ReturnsTheirSum()
        {
            // Arrange
            var input = "1,2,3,4,5,6,7,8,9,10,11,12";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(78, result);
        }

        [Fact]
        public void Add_InvalidNumber_TreatsAsZero()
        {
            // Arrange
            var input = "5,tytyt";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_OneValidAndOneEmptyNumber_ReturnsValidNumber()
        {
            // Arrange
            var input = "4,";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Add_AllInvalidNumbers_ReturnsZero()
        {
            // Arrange
            var input = "abc,xyz";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_NewlineAsDelimiter_ReturnsSum()
        {
            // Arrange
            var input = "1\n2,3";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_MultipleNewlineAndCommaDelimiters_ReturnsSum()
        {
            // Arrange
            var input = "1\n2\n3\n4,\n5";

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.Equal(15, result);
        }
    }
}
