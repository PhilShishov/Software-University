﻿
namespace BandRegister.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Band
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Members { get; set; }
        [Required]
        public double Honorarium { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
