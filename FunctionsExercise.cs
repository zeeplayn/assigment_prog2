namespace Assignment2;

// Price, "C# 12 and .NET 8" — Chapter 4, "Writing, Debugging, and Testing Functions"
// Exercise 4.1 (knowledge questions) is answered in the write-up document.
// Exercise 4.2 explicitly asks for THREE separate projects (a class library, an
// xUnit test project, and a console app), so it can't be folded into this single
// menu-driven project — it lives in its own solution folder next to this one:
//   Ch04Ex02PrimeFactorsLib / Ch04Ex02PrimeFactorsTests / Ch04Ex02PrimeFactorsApp
static class FunctionsExercise
{
    public static void Run()
    {
        Console.WriteLine("Exercise 4.1 — see the write-up for the 10 knowledge-question answers.");
        Console.WriteLine("Exercise 4.2 — prime factors: see the separate 3-project solution");
        Console.WriteLine("(Ch04Ex02PrimeFactorsLib / ...Tests / ...App), since the exercise");
        Console.WriteLine("specifically asks for a class library + unit tests + console app,");
        Console.WriteLine("which can't live inside this single console project.");
    }
}
