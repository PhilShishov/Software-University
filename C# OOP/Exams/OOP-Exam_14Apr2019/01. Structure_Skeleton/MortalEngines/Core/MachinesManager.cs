namespace MortalEngines.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;

    public class MachinesManager : IMachinesManager
    {
        private readonly IList<IPilot> pilots;
        private readonly IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            IPilot pilot = new Pilot(name);

            this.pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);

            return $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);

            this.machines.Add(fighter);

            return $"Fighter {fighter.Name} manufactured - attack: " +
                $"{fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            var machine = this.machines.FirstOrDefault(p => p.Name == selectedMachineName);

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {machine.Name} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {pilot.Name} engaged machine {machine.Name}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = this.machines.FirstOrDefault(p => p.Name == attackingMachineName);

            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            var defendingMachine = this.machines.FirstOrDefault(p => p.Name == defendingMachineName);

            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            attackingMachine.Attack(defendingMachine);

            if (attackingMachine.HealthPoints == 0)
            {
                return $"Dead machine {attackingMachine.Name} cannot attack or be attacked";
            }

            return $"Machine {defendingMachine.Name} was attacked " +
                $"by machine {attackingMachine.Name} - " +
                $"current health: {defendingMachine.HealthPoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(p => p.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var machine = this.machines.FirstOrDefault(p => p.Name == fighterName);

            if (machine == null)
            {
                return $"Machine {fighterName} could not be found";
            }

            var fighter = (Fighter)machine;

            fighter.ToggleAggressiveMode();

            return $"Fighter {fighter.Name} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var machine = this.machines.FirstOrDefault(p => p.Name == tankName);

            if (machine == null)
            {
                return $"Machine {tankName} could not be found";
            }

            var tank = (Tank)machine;

            tank.ToggleDefenseMode();

            return $"Tank {tank.Name} toggled defense mode";
        }
    }
}