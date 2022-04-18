using System;

namespace AdapterPattern;

/// <summary>
/// MainApp startup class for Structural
/// Adapter Design Pattern.
/// </summary>
class MainApp
{
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
        // Create adapter and place a request
        Target target = new Adapter();
        target.Request();
        Console.WriteLine("Press any key...");
        Console.ReadKey();
        FitSquarePegIntoARoundHole();
        Console.WriteLine("Press any key...");
        Console.ReadKey();

    }

    static void FitSquarePegIntoARoundHole()
    {
        var hole = new RoundHole { Radius = 5 };
        var roundPeg = new RoundPeg { Radius = 5 };
        if (hole.Fits(roundPeg))
        {
            Console.WriteLine("The hole fits the round peg.");
        }

        var smallSquarePeg = new SquarePeg { Width = 5 };
        var largeSquarePeg = new SquarePeg { Width = 10 };
        // hole.Fits(smallSquarePeg); // Does not compile

        var smallSquarePegAdapter = new SquarePegAdapter(smallSquarePeg);
        var largeSquarePegAdapter = new SquarePegAdapter(largeSquarePeg);
        if (hole.Fits(smallSquarePegAdapter))
        {
            Console.WriteLine("The hole fits the small square peg.");
        }
        else
        {
            Console.WriteLine("The hole does not fit the small square peg.");
        }
        if (hole.Fits(largeSquarePegAdapter))
        {
            Console.WriteLine("The hole fits the large square peg.");
        }
        else
        {
            Console.WriteLine("The hole does not fit the large square peg.");
        }

    }
}

/// <summary>
/// The 'Target' class
/// </summary>
class Target
{
    public virtual void Request()
    {
        Console.WriteLine("Called Target Request()");
    }
}

/// <summary>
/// The 'Adapter' class
/// </summary>
class Adapter : Target
{
    private Adaptee _adaptee = new Adaptee();
    public override void Request()
    {
        // Possibly do some other work
        //  and then call SpecificRequest
        Console.WriteLine("Do something else");
        _adaptee.SpecificRequest();
    }
}

/// <summary>
/// The 'Adaptee' class
/// </summary>
class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Called SpecificRequest()");
    }
}

