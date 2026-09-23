namespace Ch04Ex02PrimeFactorsLib;

public static class PrimeFactors
{
    /// <summary>
    /// Returns the prime factors of <paramref name="number"/> as a string,
    /// e.g. PrimeFactors.Calculate(30) returns "5 x 3 x 2".
    /// Assumes number is a positive integer no larger than 1,000.
    /// </summary>
    public static string Calculate(int number)
    {
        if (number < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be 2 or greater.");
        }

        List<int> factors = new();
        int remaining = number;

        for (int divisor = 2; divisor <= remaining; divisor++)
        {
            while (remaining % divisor == 0)
            {
                factors.Add(divisor);
                remaining /= divisor;
            }
        }

        // Largest factor first, matching the book's example output style.
        factors.Reverse();
        return string.Join(" x ", factors);
    }
}
