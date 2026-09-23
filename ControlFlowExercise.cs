namespace Assignment2;

// Price, "C# 12 and .NET 8" — Chapter 3, "Controlling Flow, Converting Types, and Handling Exceptions"
// Exercises 3.2 - 3.5 (3.1 = knowledge questions, answered in the write-up, not code;
// 3.6/3.7 = links to explore, no code involved).
static class ControlFlowExercise
{
    public static void Run()
    {
        Ex02_LoopsAndOverflow();
        Console.WriteLine();
        Ex03_Operators();
        Console.WriteLine();
        Ex04_FizzBuzz();
        Console.WriteLine();
        Ex05_ExceptionHandling();
    }

    // -----------------------------------------------------------------
    // Exercise 3.2 — Explore loops and overflow
    // -----------------------------------------------------------------
    // The book's original snippet uses `byte i` counting up to `int max = 500`.
    // Since byte's range is 0-255, `i++` silently wraps back to 0 once it
    // passes 255 (in an *unchecked* context, which is the C# default), so
    // `i < max` (500) is NEVER false — this is an infinite loop.
    // Wrapping the increment in a `checked` block turns that silent wrap
    // into a thrown OverflowException instead, which at least stops the
    // program and tells you something is wrong.
    private static void Ex02_LoopsAndOverflow()
    {
        Console.WriteLine("Exercise 3.2 — loops and overflow");
        Console.WriteLine("Without 'checked', a byte counter silently wraps 255 -> 0 and the");
        Console.WriteLine("loop `for (byte i = 0; i < 500; i++)` never ends. Demonstrating the");
        Console.WriteLine("*safe* version instead, which throws instead of looping forever:");

        try
        {
            byte i = 0;
            int max = 500;
            checked
            {
                for (; i < max; i++)
                {
                    // (kept quiet on purpose — printing 0..255 repeatedly isn't useful here)
                }
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"Caught expected OverflowException: {ex.Message}");
        }
    }

    // -----------------------------------------------------------------
    // Exercise 3.3 — Test your knowledge of operators
    // -----------------------------------------------------------------
    private static void Ex03_Operators()
    {
        Console.WriteLine("Exercise 3.3 — operators");

        int x = 3;
        int y = 2 + ++x; // x is incremented BEFORE being used, so x=4, y=2+4=6
        Console.WriteLine($"x = 3; y = 2 + ++x;  ->  x={x}, y={y}");

        x = 3 << 2; // 3 = 0b011, shifted left 2 = 0b1100 = 12
        y = 10 >> 1; // 10 = 0b1010, shifted right 1 = 0b0101 = 5
        Console.WriteLine($"x = 3 << 2; y = 10 >> 1;  ->  x={x}, y={y}");

        x = 10 & 8; // 0b1010 & 0b1000 = 0b1000 = 8
        y = 10 | 7; // 0b1010 | 0b0111 = 0b1111 = 15
        Console.WriteLine($"x = 10 & 8; y = 10 | 7;  ->  x={x}, y={y}");
    }

    // -----------------------------------------------------------------
    // Exercise 3.4 — Practice loops and operators (FizzBuzz)
    // -----------------------------------------------------------------
    private static void Ex04_FizzBuzz()
    {
        Console.WriteLine("Exercise 3.4 — FizzBuzz (1-100)");
        for (int n = 1; n <= 100; n++)
        {
            string output = (n % 3 == 0, n % 5 == 0) switch
            {
                (true, true) => "fizzbuzz",
                (true, false) => "fizz",
                (false, true) => "buzz",
                _ => n.ToString()
            };
            Console.Write(output + " ");
        }
        Console.WriteLine();
    }

    // -----------------------------------------------------------------
    // Exercise 3.5 — Practice exception handling
    // -----------------------------------------------------------------
    private static void Ex05_ExceptionHandling()
    {
        Console.WriteLine("Exercise 3.5 — exception handling (division)");
        Console.Write("Enter a number between 0 and 255: ");
        string? firstInput = Console.ReadLine();
        Console.Write("Enter another number between 0 and 255: ");
        string? secondInput = Console.ReadLine();

        try
        {
            byte first = byte.Parse(firstInput ?? string.Empty);
            byte second = byte.Parse(secondInput ?? string.Empty);
            int result = first / second;
            Console.WriteLine($"{first} divided by {second} is {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("FormatException: Input string was not in a correct format.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("OverflowException: Value was outside the range for a byte (0-255).");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("DivideByZeroException: You cannot divide by zero.");
        }
    }
}
