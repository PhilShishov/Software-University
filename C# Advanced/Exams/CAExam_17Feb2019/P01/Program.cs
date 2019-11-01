using System;
using System.Collections.Generic;
using System.Linq;

namespace P01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var leftSocksInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rightSocksInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> leftSocks = new List<int>(leftSocksInput);
            Queue<int> rightSocks = new Queue<int>(rightSocksInput);
            List<int> pairs = new List<int>();

            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                int currentLeftSock = leftSocks[leftSocks.Count - 1];
                int currentRightSock = rightSocks.Peek();

                if (currentLeftSock > currentRightSock)
                {
                    pairs.Add(currentLeftSock + currentRightSock);
                    leftSocks.RemoveAt(leftSocks.Count - 1);
                    rightSocks.Dequeue();
                }
                else if (currentLeftSock < currentRightSock)
                {
                    leftSocks.RemoveAt(leftSocks.Count - 1);
                }

                else if (currentLeftSock == currentRightSock)
                {
                    rightSocks.Dequeue();
                    leftSocks[leftSocks.Count - 1]++;
                    currentLeftSock++;
                }
            }

            Console.WriteLine(pairs.OrderByDescending(p => p).FirstOrDefault());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
