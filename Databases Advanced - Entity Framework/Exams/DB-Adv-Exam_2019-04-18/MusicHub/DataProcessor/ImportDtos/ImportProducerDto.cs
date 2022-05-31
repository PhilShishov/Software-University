using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducerDto
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [RegularExpression("^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^(\+359) [0-9]{3} [0-9]{3} [0-9]{3}$")]
        public string PhoneNumber { get; set; }

        public AlbumDto[] Albums { get; set; }
    }

    public class AlbumDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}
