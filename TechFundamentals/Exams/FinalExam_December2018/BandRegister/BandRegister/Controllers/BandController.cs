using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {

            using (var db = new BandsDbContext())
            {
                var allBands = db.Bands.ToList();
                return View(allBands);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {

            using (var db = new BandsDbContext())
            {
                db.Bands.Add(band);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new BandsDbContext())
            {
                var bandForEdit = db.Bands.FirstOrDefault(x => x.Id == id);
                if (bandForEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(bandForEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            using (var db = new BandsDbContext())
            {

                var oldBand = db.Bands.FirstOrDefault(x => x.Id == band.Id);
                if (oldBand == null)
                {
                    return RedirectToAction("Index");
                }

                oldBand.Name = band.Name;
                oldBand.Members = band.Members;
                oldBand.Honorarium = band.Honorarium;
                oldBand.Genre = band.Genre;

                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandsDbContext())
            {
                var bandForDelete = db.Bands.FirstOrDefault(x => x.Id == id);
                if (bandForDelete == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(bandForDelete);
            }

        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new BandsDbContext())
            {
                db.Bands.Remove(band);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
        }
    }
}