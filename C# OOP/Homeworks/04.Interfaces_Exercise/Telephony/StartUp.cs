using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var phonesInput = Console.ReadLine().Split();
            var urlInput = Console.ReadLine().Split();

            foreach (var input in phonesInput)
            {
                try
                {
                    ICallable callable = new Smartphone { PhoneNumber = input };
                    Console.WriteLine(callable.Call());
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var input in urlInput)
            {
                try
                {
                    IBrowsable browsable = new Smartphone { URL = input };
                    Console.WriteLine(browsable.Browse());
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
