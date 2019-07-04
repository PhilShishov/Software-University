
namespace Phonebook.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Phonebook.Data;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(DataAccess.Contacts);
        }
    }
}
