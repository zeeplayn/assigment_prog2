namespace Assignment2;

// Yagur, "Functional Programming with C#" — Chapter "Honest Functions, Null, and Option"
// (the book's Chapter 4; called "Chapter 3" in the course numbering that skips the
// intro chapter). Its own 3 numbered exercises actually sit on printed pages 79-80,
// just past the assigned 54-71 range (see the write-up for details) — solved here
// with an original example (a small library-catalogue system) instead of the book's
// tower-defense one.

static class HonestFunctionsExercise
{
    public static void Run()
    {
        Ex1_HonestReturnType();
        Console.WriteLine();
        Ex2_GuardAgainstNullInputs();
        Console.WriteLine();
        Ex3_DescribeItem();
    }

    // -----------------------------------------------------------------
    // Exercise 1 — Refactor a function so its return type "honestly"
    // signals that the item might not be found, instead of silently
    // being able to return null.
    // -----------------------------------------------------------------
    // Dishonest version:
    //   public LibraryBook FindBookByIsbn(string isbn)
    //   {
    //       return _catalogue.FirstOrDefault(b => b.Isbn == isbn); // could be null!
    //   }
    //
    // Honest version — nullable reference type makes the "no result" case
    // part of the signature, so the compiler forces callers to check it:
    private static readonly List<LibraryBook> _catalogue = new()
    {
        new LibraryBook("978-0-13-468599-1", "The C# Programming Language"),
        new LibraryBook("978-1-4919-0955-8", "Functional Programming in C#"),
    };

    private static LibraryBook? FindBookByIsbn(string isbn) =>
        _catalogue.FirstOrDefault(b => b.Isbn == isbn);

    private static void Ex1_HonestReturnType()
    {
        Console.WriteLine("Exercise 1 — honest return type");
        LibraryBook? found = FindBookByIsbn("978-1-4919-0955-8");
        LibraryBook? missing = FindBookByIsbn("000-0-00-000000-0");

        Console.WriteLine(found is not null ? $"Found: {found.Title}" : "Not found");
        Console.WriteLine(missing is not null ? $"Found: {missing.Title}" : "Not found");
    }

    // -----------------------------------------------------------------
    // Exercise 2 — Guard a function against null inputs instead of
    // letting a NullReferenceException happen deep inside it.
    // -----------------------------------------------------------------
    private static void CheckOutBook(LibraryBook? book, Member? member)
    {
        ArgumentNullException.ThrowIfNull(book, nameof(book));
        ArgumentNullException.ThrowIfNull(member, nameof(member));

        Console.WriteLine($"{member.Name} checked out '{book.Title}'.");
    }

    private static void Ex2_GuardAgainstNullInputs()
    {
        Console.WriteLine("Exercise 2 — guarding against null inputs");
        try
        {
            CheckOutBook(_catalogue[0], null);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Caught expected exception: {ex.ParamName} was null.");
        }
    }

    // -----------------------------------------------------------------
    // Exercise 3 — Use pattern matching to describe items of different
    // types, including handling a possible null gracefully.
    // -----------------------------------------------------------------
    private static string DescribeItem(LibraryItem? item) => item switch
    {
        LibraryBook b => $"Book: '{b.Title}' (ISBN {b.Isbn})",
        AudioBook a => $"Audiobook: '{a.Title}', narrated by {a.Narrator}",
        null => "No item selected.",
        _ => "An unknown catalogue item."
    };

    private static void Ex3_DescribeItem()
    {
        Console.WriteLine("Exercise 3 — pattern matching over item types");
        Console.WriteLine(DescribeItem(_catalogue[0]));
        Console.WriteLine(DescribeItem(new AudioBook("Clean Code", "Robert C. Martin (narrator)")));
        Console.WriteLine(DescribeItem(null));
    }
}

// --- Supporting types ---
abstract class LibraryItem
{
    public string Title { get; }
    protected LibraryItem(string title) => Title = title;
}

class LibraryBook : LibraryItem
{
    public string Isbn { get; }
    public LibraryBook(string isbn, string title) : base(title) => Isbn = isbn;
}

class AudioBook : LibraryItem
{
    public string Narrator { get; }
    public AudioBook(string title, string narrator) : base(title) => Narrator = narrator;
}

record Member(string Name);
