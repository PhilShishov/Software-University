namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;
    using System.Linq;

    public class TripService : ITripService
    {
        private readonly ApplicationDbContext dbContext;

        public TripService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Trip> GetAll()
            => this.dbContext
            .Trips
            .Select(t => new Trip
            {
                Id = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime,
                Seats = t.Seats
            })
            .ToArray();

        public void Add(TripAddInputModel tripAddInputModel)
        {
            var trip = new Trip()
            {
                StartPoint = tripAddInputModel.StartPoint,
                EndPoint = tripAddInputModel.EndPoint,
                DepartureTime = tripAddInputModel.DepartureTime,
                ImagePath = tripAddInputModel.ImagePath,
                Seats = tripAddInputModel.Seats,
                Description = tripAddInputModel.Description,
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();
        }

        public TripViewModel GetById(string id)
        {
            var trip = this.dbContext
                .Trips
                .Where(x => x.Id == id).Select(t => new TripViewModel
                {
                    Id = t.Id,
                    DepartureTime = t.DepartureTime.ToString("yyyy-MM-ddThh:mm:ss"),
                    Description = t.Description,
                    EndPoint = t.EndPoint,
                    ImagePath = t.ImagePath,
                    Seats = t.Seats,
                    StartPoint = t.StartPoint
                })
            .FirstOrDefault();
            ;

            return trip;
        }

        public bool AddUserToTripById(string tripId, string userId)
        {
            var targetTrip = this.dbContext.Trips.FirstOrDefault(x => x.Id == tripId);
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            // Make mapping table validation
            if (!this.dbContext.UserTrips.Any(ut => ut.TripId == userTrip.TripId && ut.UserId == userTrip.UserId) && targetTrip.Seats > 0)
            {
                targetTrip.Seats -= 1;
                targetTrip.UserTrips.Add(userTrip);
                dbContext.SaveChanges();
                return true;
            }

            return false;
        }

    }
}