using System;

public class Program
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();
        Console.WriteLine(spy.CollectGettersAndSetters("Hacker"));
    }
}
