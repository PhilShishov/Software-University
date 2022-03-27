
namespace P08_AnonymousThreat
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var data = Console.ReadLine().Split().ToList();

            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                if (command == "3:1")
                {
                    break;
                }

                if (command == "merge")
                {
                    var startIndex = int.Parse(input[1]);
                    var endIndex = int.Parse(input[2]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (startIndex >= data.Count || endIndex < 0)
                    {
                        continue;
                    }
                    if (endIndex >= data.Count)
                    {
                        endIndex = data.Count - 1;
                    }

                    string concat = string.Empty;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concat += data[i];
                    }
                    for (int j = endIndex; j >= startIndex; j--)
                    {
                        data.RemoveAt(j);
                    }

                    data.Insert(startIndex, concat);
                }
                else if (command == "divide")
                {
                    int index = int.Parse(input[1]);
                    int partitions = int.Parse(input[2]);
                    string token = data[index];
                    int lengthOfPartitions = token.Length / partitions;
                    int lengthOfLast = lengthOfPartitions;
                    if (token.Length % partitions != 0)
                    {
                        lengthOfLast += token.Length % partitions;
                    }
                    int startIndex = 0;
                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string dividedWord = token.Substring(startIndex, lengthOfPartitions);
                        data.Insert(index, dividedWord);
                        index++;
                        startIndex += lengthOfPartitions;
                    }
                    string lastDividedWord = token.Substring(startIndex, lengthOfLast);
                    data.Insert(index, lastDividedWord);

                    data.Remove(token);
                }
            }

            Console.WriteLine(string.Join(" ", data));
        }
    }
}
