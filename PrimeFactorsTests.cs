using Ch04Ex02PrimeFactorsLib;
using Xunit;

namespace Ch04Ex02PrimeFactorsTests;

public class PrimeFactorsTests
{
    [Theory]
    [InlineData(4, "2 x 2")]
    [InlineData(7, "7")]
    [InlineData(30, "5 x 3 x 2")]
    [InlineData(40, "5 x 2 x 2 x 2")]
    [InlineData(50, "5 x 5 x 2")]
    public void Calculate_ReturnsExpectedFactors(int number, string expected)
    {
        string actual = PrimeFactors.Calculate(number);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Calculate_NumberBelowTwo_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => PrimeFactors.Calculate(1));
    }

    [Fact]
    public void Calculate_UpperBound_DoesNotThrow()
    {
        // "the largest number entered will be 1,000" per the exercise
        string result = PrimeFactors.Calculate(1000);
        Assert.False(string.IsNullOrWhiteSpace(result));
    }
}
