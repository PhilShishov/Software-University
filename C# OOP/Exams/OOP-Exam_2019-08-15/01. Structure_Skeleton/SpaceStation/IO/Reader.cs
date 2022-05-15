namespace SpaceStation.IO
{
    using System;

    using SpaceStation.IO.Contracts;
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
