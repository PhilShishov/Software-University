
namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bet
    {
        //BetId, Amount, Prediction, DateTime, UserId, GameId

        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public PredictionType Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
