using Ch04Ex02PrimeFactorsLib;

Console.Write("Enter a number (2-1000) to find its prime factors: ");
string? input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    try
    {
        string factors = PrimeFactors.Calculate(number);
        Console.WriteLine($"Prime factors of {number} are {factors}");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
else
{
    Console.WriteLine("That wasn't a valid whole number.");
}
