
namespace Phonebook.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Phonebook.Data;
    using Phonebook.Data.Models;

    public class ContactController : Controller
    {
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            DataAccess.Contacts.Add(contact);

            return RedirectToAction("Index", "Home");
        }
    }
}