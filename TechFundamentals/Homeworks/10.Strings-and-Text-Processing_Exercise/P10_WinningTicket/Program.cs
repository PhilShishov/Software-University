
namespace P10_WinningTicket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] tickets = Console.ReadLine().Split(',').Select(x => x.Trim()).ToArray();
            char[] winningSymbols = new char[] { '@', '#', '$', '^' };
            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                int repeatsLeft = 1;
                int repeatsRight = 1;
                List<KeyValuePair<char, int>> leftWins = new List<KeyValuePair<char, int>>();
                List<KeyValuePair<char, int>> leftJackpot = new List<KeyValuePair<char, int>>();
                for (int i = 0; i < ticket.Length / 2 - 1; i++)
                {
                    if (winningSymbols.Contains(ticket[i]) && ticket[i] == ticket[i + 1])
                    {
                        repeatsLeft++;
                        if (repeatsLeft >= 6 && repeatsLeft <= 9)
                        {
                            leftWins.Add(new KeyValuePair<char, int>(ticket[i], repeatsLeft));
                        }
                        else if (repeatsLeft == 10)
                        {
                            leftJackpot.Add(new KeyValuePair<char, int>(ticket[i], repeatsLeft));
                        }

                    }
                    else
                    {
                        repeatsLeft = 1;
                    }
                }
                int matchLength = 0;
                char matchSymbol = char.MinValue;
                bool match = false;
                bool jackpot = false;
                for (int i = ticket.Length - 1; i > ticket.Length / 2; i--)
                {
                    if (winningSymbols.Contains(ticket[i]) && ticket[i] == ticket[i - 1])
                    {
                        repeatsRight++;
                        if (repeatsRight >= 6 && repeatsRight <= 9)
                        {
                            if (leftWins.Contains(new KeyValuePair<char, int>(ticket[i], repeatsRight)) && repeatsRight > matchLength)
                            {
                                match = true;
                                matchSymbol = ticket[i];
                                matchLength = repeatsRight;
                            }
                        }
                        else if (repeatsLeft == 10 && leftJackpot.Contains(new KeyValuePair<char, int>(ticket[i], repeatsRight)))
                        {
                            Console.WriteLine("ticket \"{0}\" - 10{1} Jackpot!", ticket, ticket[0]);
                            match = false;
                            jackpot = true;
                            break;
                        }
                    }
                    else
                    {
                        repeatsRight = 1;
                    }
                }
                if (match)
                {
                    Console.WriteLine("ticket \"{0}\" - {1}{2}", ticket, matchLength, matchSymbol);
                }
                else
                {
                    if (!jackpot)
                    {
                        Console.WriteLine("ticket \"{0}\" - no match", ticket);
                    }
                }
            }
        }
    }
}
