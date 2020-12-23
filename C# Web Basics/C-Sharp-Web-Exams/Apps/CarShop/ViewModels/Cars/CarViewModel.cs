using System;
using System.Collections.Generic;
using System.Text;

using CarShop.Data.Models;

namespace CarShop.ViewModels.Cars
{
    public class CarViewModel
    {
        public string Id { get; set; }

        public string PlateNumber { get; set; }

        public string ImageUrl { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssues { get; set; }
    }
}
