
namespace P03_QuestsJournal
{
    using System;
    using System.Linq;

    class QuestsJournal
    {
        static void Main()
        {
            var resultQuests = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "Retire!")
            {
                var quests = input.Split(" - ");

                string command = quests[0];
                string quest = quests[1];

                if (command == "Start")
                {
                    if (!resultQuests.Contains(quest))
                    {
                        resultQuests.Add(quest);
                    }
                }
                else if (command == "Complete")
                {
                    resultQuests.Remove(quest);
                }
                else if (command == "Side Quest")
                {
                    var sideQuest = quest.Split(":");
                    if (resultQuests.Contains(sideQuest[0]) && !resultQuests.Contains(sideQuest[1]))
                    {
                        int index = resultQuests.IndexOf(sideQuest[0]) + 1;
                        //int index = resultQuests.FindIndex(x => x == sideQuest[0]);
                        resultQuests.Insert(index, sideQuest[1]);
                    }
                }
                else if (command == "Renew")
                {
                    if (resultQuests.Contains(quest))
                    {
                        resultQuests.Remove(quest);
                        resultQuests.Add(quest);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", resultQuests));
        }
    }
}
