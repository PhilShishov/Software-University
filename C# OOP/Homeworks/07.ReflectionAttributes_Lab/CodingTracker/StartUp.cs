using System;

[Author("Philip")]
public class StartUp
{
    [Author("Ivan")]
    public static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}

