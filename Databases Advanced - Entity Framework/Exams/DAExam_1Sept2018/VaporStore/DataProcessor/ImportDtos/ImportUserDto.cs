using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class ImportUserDto
    {
        [Required]
        [RegularExpression("^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public CardsDto[] Cards { get; set; }
    }

    public class CardsDto
    {
        [Required]
        [RegularExpression("^[0-9]{4}\\s+[0-9]{4}\\s+[0-9]{4}\\s+[0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}$")]
        public string CVC { get; set; }

        public string Type { get; set; }
    }
        //    "FullName": "Lorrie Silbert",
        //"Username": "lsilbert",
        //"Email": "lsilbert@yahoo.com",
        //"Age": 33,
        //"Cards": [
        //  {
        //    "Number": "1833 5024 0553 6211",
        //    "CVC": "903",
        //    "Type": "Debit"
        //  },
        //  {
        //    "Number": "5625 0434 5999 6254",
        //    "CVC": "570",
        //    "Type": "Credit"
        //  },
        //  {
        //    "Number": "4902 6975 5076 5316",
        //    "CVC": "091",
        //    "Type": "Debit"
        //  }
}
