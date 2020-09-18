using MortalEngines.Core;
using MortalEngines.Entities;
using System;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            MachinesManager manager = new MachinesManager();

            try
            {
                Console.WriteLine(manager.HirePilot("John"));
                Console.WriteLine(manager.HirePilot("Nelson"));
                Console.WriteLine(manager.ManufactureTank("T-72", 100, 100));
                //Console.WriteLine(manager.ToggleTankDefenseMode("T-72"));

                Console.WriteLine(manager.ManufactureFighter("Boeing", 180, 90));
                //Console.WriteLine(manager.ToggleFighterAggressiveMode("Boeing"));
                Console.WriteLine(manager.EngageMachine("John", "Boeing"));
                Console.WriteLine(manager.EngageMachine("Nelson", "T-72"));

                Console.WriteLine(manager.AttackMachines("Boeing", "T-72"));
                Console.WriteLine(manager.MachineReport("Boeing"));
                Console.WriteLine(manager.MachineReport("T-72"));



                //Console.WriteLine(manager.PilotReport("John"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}