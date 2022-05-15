namespace ViceCity.Models.Neghbourhoods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                var gun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                var currentPlayer = civilPlayers.FirstOrDefault(p => p.IsAlive == true);

                if (currentPlayer == null)
                {
                    break;
                }

                currentPlayer.TakeLifePoints(gun.Fire());
            }

            while (true)
            {
                var currentPlayer = civilPlayers.FirstOrDefault(p => p.IsAlive == true);

                if (currentPlayer == null)
                {
                    break;
                }
                var gun = currentPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                mainPlayer.TakeLifePoints(gun.Fire());

                if (mainPlayer.IsAlive == false)
                {
                    break;
                }
            }
        }
    }
}
