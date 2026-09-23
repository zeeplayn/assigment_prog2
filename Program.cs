using Assignment2;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Assignment 2 — choose an exercise to run:");
    Console.WriteLine("1) Price Ch.3 Ex.3.2-3.5 — control flow, overflow, operators, FizzBuzz, exceptions");
    Console.WriteLine("2) Price Ch.4 Ex.4.1-4.2 — functions, debugging, testing (pointer to separate solution)");
    Console.WriteLine("3) Yagur 'Honest Functions, Null, and Option' Ex.1-3");
    Console.WriteLine("A) Run all");
    Console.WriteLine("Q) Quit");
    Console.Write("> ");

    string? choice = Console.ReadLine()?.Trim().ToUpperInvariant();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            ControlFlowExercise.Run();
            break;
        case "2":
            FunctionsExercise.Run();
            break;
        case "3":
            HonestFunctionsExercise.Run();
            break;
        case "A":
            ControlFlowExercise.Run();
            Console.WriteLine();
            FunctionsExercise.Run();
            Console.WriteLine();
            HonestFunctionsExercise.Run();
            break;
        case "Q":
            return;
        default:
            Console.WriteLine("Unknown option, try again.");
            break;
    }
}
