
namespace P02_AMinerTask
{
    using System;
    using System.Collections.Generic;

    class AMinerTask
    {
        static void Main()
        {
            var dict = new Dictionary<string, double>();

            while (true)
            {
                string resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }
                double quantity = double.Parse(Console.ReadLine());

                if (!dict.ContainsKey(resource))
                {
                    dict.Add(resource, 0);                    
                }                

                dict[resource] += quantity;
            }


            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

        }
    }
}
