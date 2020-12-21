using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Gender { get; set; }
    }
}
