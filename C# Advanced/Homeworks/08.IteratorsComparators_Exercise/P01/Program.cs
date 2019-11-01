using System;
using System.Linq;

namespace P01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;
            var command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    if (command.Contains("Create"))
                    {
                        var items = command.Split().Skip(1).ToList();
                        listyIterator = new ListyIterator<string>(items);
                    }

                    else if (command == "Print")
                    {
                        listyIterator.Print();
                    }

                    else if (command == "PrintAll")
                    {
                        foreach (var item in listyIterator)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }

                    else if (command == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }

                    else if (command == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
