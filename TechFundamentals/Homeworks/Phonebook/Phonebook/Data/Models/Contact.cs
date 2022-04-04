
namespace Phonebook.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
