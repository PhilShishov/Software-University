using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;

using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCar(AddCarInputModel input, string userId)
        {
            var car = new Car
            {
                Model = input.Model,
                Year = input.Year,
                PictureUrl = input.Image,
                PlateNumber = input.PlateNumber,
                OwnerId = userId
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public IEnumerable<CarViewModel> GetAllById(string userId)
        {
            return this.db.Cars
                .Where(x => x.OwnerId == userId)
                .Select(x => new CarViewModel
                {
                    Id = x.Id,
                    PlateNumber = x.PlateNumber,
                    ImageUrl = x.PictureUrl,
                    RemainingIssues = x.Issues.Where(i => i.IsFixed == false).Count(),
                    FixedIssues = x.Issues.Where(i => i.IsFixed == true).Count(),

                }).ToList();
        }

        public IEnumerable<CarViewModel> GetAllWithIssues()
        {
            var cars = this.db.Cars
                 .Select(x => new CarViewModel
                 {
                     Id = x.Id,
                     PlateNumber = x.PlateNumber,
                     ImageUrl = x.PictureUrl,
                     RemainingIssues = x.Issues.Where(i => i.IsFixed == false).Count(),
                     FixedIssues = x.Issues.Where(i => i.IsFixed == true).Count(),
                 }).ToList();

            return cars.Where(x => x.RemainingIssues > 0).ToList();
        }
    }
}
