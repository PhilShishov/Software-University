﻿
namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Country
    {
        public Country()
        {
            this.Towns = new List<Town>();
        }
        public int CountryId { get; set; }

        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
