using System;
using Xunit;

namespace test_repo1.Tests;

public class CalculatorTest
{
    private readonly Calculator _calculator;

    public CalculatorTest()
    {
        _calculator = new Calculator();
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 2, 3)]
    [InlineData(-1, 1, 0)]
    [InlineData(int.MaxValue, 0, int.MaxValue)]
    [InlineData(int.MinValue, 0, int.MinValue)]
    [InlineData(100, -50, 50)]
    public void AddInts_WithVariousInputs_ReturnsExpectedSum(int a, int b, int expected)
    {
        // Act
        var result = _calculator.AddInts(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void AddInts_WithMaxValueAndPositive_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MaxValue;
        int b = 1;

        // Act & Assert
        Assert.Throws<OverflowException>(() => _calculator.AddInts(a, b));
    }

    [Fact]
    public void AddInts_WithMinValueAndNegative_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MinValue;
        int b = -1;

        // Act & Assert
        Assert.Throws<OverflowException>(() => _calculator.AddInts(a, b));
    }

    [Fact]
    public void AddInts_WithMaxAndMinValues_ReturnsZero()
    {
        // Arrange
        int a = int.MaxValue;
        int b = int.MinValue + 1;
        int expected = 0;

        // Act
        var result = _calculator.AddInts(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestFail()
    {
        Assert.True(false);
    }
}