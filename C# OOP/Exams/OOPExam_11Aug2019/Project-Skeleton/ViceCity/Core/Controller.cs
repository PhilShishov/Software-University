namespace ViceCity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;

    public class Controller : IController
    {
        private readonly GunRepository gunRepository;
        private readonly IList<IPlayer> civilPlayers;
        private readonly IPlayer mainPlayer;
        private readonly GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.gunRepository = new GunRepository();
            this.civilPlayers = new List<IPlayer>();
            this.mainPlayer = new MainPlayer();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.gunRepository.Add(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            var gun = this.gunRepository.Models.FirstOrDefault();

            if (this.gunRepository.Models.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);
                this.gunRepository.Remove(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            IPlayer player = this.civilPlayers.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                return $"Civil player with that name doesn't exists!";
            }

            player.GunRepository.Add(gun);
            this.gunRepository.Remove(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);

            this.civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);

            if (this.mainPlayer.LifePoints == 100 && this.civilPlayers.All(p => p.IsAlive == true))
            {
                return "Everything is okay!";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("A fight happened:");
            sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
            sb.AppendLine($"Tommy has killed: {this.civilPlayers.Where(p => p.IsAlive == false).Count()} players!");
            sb.AppendLine($"Left Civil Players: {this.civilPlayers.Where(p => p.IsAlive == true).Count()}!");

            return sb.ToString().TrimEnd();

        }
    }
}
