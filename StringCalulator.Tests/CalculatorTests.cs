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
        public void Add_MoreThanTwoNumbers_ThrowsException()
        {
            // Arrange
            var input = "1,2,3";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.Add(input));
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
    }
}
