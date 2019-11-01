using System;

namespace MissionPrivateImpossible
{
    public class Program
    {
        public static void Main()
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.RevealPrivateMethods("Hacker"));
        }
    }
}
