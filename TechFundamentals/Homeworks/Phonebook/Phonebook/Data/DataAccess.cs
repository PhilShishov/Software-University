
namespace Phonebook.Data
{
    using Phonebook.Data.Models;

    using System.Collections.Generic;

    public class DataAccess
    {
        public static List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
