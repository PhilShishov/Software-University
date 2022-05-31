using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.Data.Models
{
    public class GameTag
    {
            //add composite primary key

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
