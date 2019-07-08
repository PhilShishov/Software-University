using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {
            //TO DO
            return null;
        }

        [HttpGet]
        public IActionResult Create()
        {
            //TO DO
            return null;
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {
            //TO DO
            return null;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //TO DO
            return null;
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            //TO DO
            return null;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //TO DO
            return null;
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            //TO DO
            return null;
        }
    }
}