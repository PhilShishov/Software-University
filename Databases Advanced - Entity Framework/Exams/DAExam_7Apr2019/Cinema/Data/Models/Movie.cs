using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Projections = new HashSet<Projection>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Title { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Director { get; set; }

        public ICollection<Projection> Projections { get; set; }
    }
}
