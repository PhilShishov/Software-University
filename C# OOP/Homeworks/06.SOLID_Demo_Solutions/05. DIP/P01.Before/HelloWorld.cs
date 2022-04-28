using System;

namespace P01.Before
{
    public class HelloWorld
    {
        public string Greeting(string name)
        {
            if (DateTime.Now.Hour < 12)
            {
                return "Good morning, " + name;
            }

            if (DateTime.Now.Hour < 18)
            {
                return "Good afternoon, " + name;
            }

            return "Good evening, " + name;
        }
    }
}
