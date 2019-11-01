namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ManagerController managerController = new ManagerController();

            try
            {
                Console.WriteLine(managerController.AddPlayer("Beginner", "handyUser33"));
                Console.WriteLine(managerController.AddPlayer("Beginner", "ivan12"));

                Console.WriteLine(managerController.AddCard("Trap", "Cyber"));
                //Console.WriteLine(managerController.AddCard("Trap", "Cyber"));
                Console.WriteLine(managerController.AddCard("Trap", "susfge"));
                Console.WriteLine(managerController.AddCard("Magic", "Sorcerer"));
                Console.WriteLine(managerController.AddCard("Trap", "1"));
                //Console.WriteLine(managerController.AddCard("Trap", "Cyber"));
                Console.WriteLine(managerController.AddCard("Trap", "2"));
                Console.WriteLine(managerController.AddCard("Magic", "3"));

                Console.WriteLine(managerController.AddPlayerCard("handyUser33", "Cyber"));
                Console.WriteLine(managerController.AddPlayerCard("handyUser33", "susfge"));
                Console.WriteLine(managerController.AddPlayerCard("handyUser33", "Sorcerer"));

                Console.WriteLine(managerController.AddPlayerCard("ivan12", "1"));
                Console.WriteLine(managerController.AddPlayerCard("ivan12", "2"));
                Console.WriteLine(managerController.AddPlayerCard("ivan12", "3"));

                Console.WriteLine(managerController.Fight("handyUser33", "ivan12"));
                Console.WriteLine(managerController.Report());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}