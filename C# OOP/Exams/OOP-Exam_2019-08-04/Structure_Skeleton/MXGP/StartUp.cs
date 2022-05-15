
namespace MXGP
{
    using System;

    using MXGP.Core;

    public class StartUp
    {
        public static void Main()
        {
            ChampionshipController controller = new ChampionshipController();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] commandItems = line.Split();
                string result = string.Empty;

                try
                {
                    switch (commandItems[0])
                    {
                        case "CreateRider":
                            result += controller.CreateRider(commandItems[1]);
                            break;

                        case "CreateMotorcycle":
                            result += controller.CreateMotorcycle(commandItems[1],
                                commandItems[2],
                                int.Parse(commandItems[3]));
                            break;

                        case "AddMotorcycleToRider":
                            result += controller.AddMotorcycleToRider(commandItems[1], commandItems[2]);
                            break;

                        case "AddRiderToRace":
                            result += controller.AddRiderToRace(commandItems[1], commandItems[2]);
                            break;

                        case "CreateRace":
                            result += controller.CreateRace(commandItems[1], int.Parse(commandItems[2]));
                            break;

                        case "StartRace":
                            result += controller.StartRace(commandItems[1]);
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();

            }
        }
    }
}
