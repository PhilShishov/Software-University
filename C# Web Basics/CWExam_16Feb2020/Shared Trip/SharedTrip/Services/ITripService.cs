namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;

    public interface ITripService
    {
        IEnumerable<Trip> GetAll();

        void Add(TripAddInputModel tripAddInputModel);

        TripViewModel GetById(string id);

        bool AddUserToTripById(string tripId, string userId);
    }
}