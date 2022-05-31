using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner()
        {
            this.Mails = new HashSet<Mail>();
            this.PrisonerOfficers = new HashSet<OfficerPrisoner>();
        }

        //TODO: 
        [Key]
        public int Id { get; set; }

        [Required]
        //[StringLength(20, MinimumLength = 3)]
        [MinLength(3), MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^The [A-Z]{1}[a-z]+$")]
        public string Nickname { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public DateTime IncarcerationDate { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }
        public Cell Cell { get; set; }

        public ICollection<Mail> Mails { get; set; }

        public ICollection<OfficerPrisoner> PrisonerOfficers  { get; set; }
    }
}