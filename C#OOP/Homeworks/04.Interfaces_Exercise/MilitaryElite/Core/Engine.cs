namespace MilitaryElite.Core
{
    using MilitaryElite.Contracts;
    using MilitaryElite.Exceptions;
    using MilitaryElite.Factories;
    using MilitaryElite.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly List<ISoldier> army;
        private readonly CommandoFactory commandoFactory;
        private readonly EngineerFactory engineerFactory;
        private readonly LieutenantGeneralFactory lieutenantGeneralFactory;
        private readonly MissionFactory missionFactory;
        private readonly PrivateFactory privateFactory;
        private readonly RepairFactory repairFactory;
        private readonly SpyFactory spyFactory;

        public Engine()
        {
            this.army = new List<ISoldier>();
            this.commandoFactory = new CommandoFactory();
            this.engineerFactory = new EngineerFactory();
            this.lieutenantGeneralFactory = new LieutenantGeneralFactory();
            this.missionFactory = new MissionFactory();
            this.privateFactory = new PrivateFactory();
            this.repairFactory = new RepairFactory();
            this.spyFactory = new SpyFactory();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                var commandArgs = input.Split();
                string type = commandArgs[0];

                switch (type)
                {
                    case "Private":
                        Private privateSoldier = this.privateFactory.MakePrivateSoldier(commandArgs);
                        this.army.Add(privateSoldier);
                        break;
                    case "LieutenantGeneral":
                        LieutenantGeneral lieutenantGeneral = this.lieutenantGeneralFactory.MakeLieutenantGeneral(commandArgs);

                        string[] privatesToAddArgs = commandArgs.Skip(5).ToArray();

                        foreach (var pid in privatesToAddArgs)
                        {
                            ISoldier currentPrivate = this.army.First(p => p.Id == pid);

                            lieutenantGeneral.AddPrivate(currentPrivate);
                        }

                        this.army.Add(lieutenantGeneral);
                        break;

                    case "Engineer":
                        try
                        {
                            Engineer engineer = this.engineerFactory.MakeEngineer(commandArgs);

                            string[] repairArgs = commandArgs.Skip(6).ToArray();
                            AddRepairs(engineer, repairArgs);

                            this.army.Add(engineer);
                        }
                        catch (InvalidCorpsException)
                        {
                        }
                        break;

                    case "Commando":
                        try
                        {
                            Commando commando = this.commandoFactory.MakeCommando(commandArgs);

                            string[] missionArgs = commandArgs.Skip(6).ToArray();
                            AddMission(commando, missionArgs);

                            this.army.Add(commando);
                        }
                        catch (InvalidCorpsException)
                        {
                        }

                        break;

                    case "Spy":
                        Spy spy = this.spyFactory.MakeSpy(commandArgs);
                        this.army.Add(spy);
                        break;
                }

                input = Console.ReadLine();
            }

            //foreach (var soldier in this.army)
            //{
            //    Console.WriteLine(soldier.ToString());
            //}

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in this.army)
            {
                Type type = soldier.GetType();

                Object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual.ToString());
            }
        }

        private void AddMission(Commando commando, string[] missionArgs)
        {
            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    string name = missionArgs[i];
                    string state = missionArgs[i + 1];

                    IMission mission = this.missionFactory.MakeMission(name, state);
                    commando.AddMission(mission);
                }
                catch (InvalidStateException)
                {
                    continue;                    
                }
            }
        }

        private void AddRepairs(Engineer engineer, string[] repairArgs)
        {
            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string name = repairArgs[i];
                int hours = int.Parse(repairArgs[i + 1]);
                IRepair repair = this.repairFactory.MakeRepair(name, hours);
                engineer.AddRepair(repair);
            }
        }
    }
}
