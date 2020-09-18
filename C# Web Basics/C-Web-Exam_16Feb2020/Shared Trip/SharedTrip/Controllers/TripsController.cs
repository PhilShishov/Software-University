namespace SharedTrip.Controllers
{
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Trips;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class TripsController : Controller
    {
        private const int MinSeatsCapacity = 2;
        private const int MaxSeatsCapacity = 6;
        private const int MaxDescriptionLength = 80;

        private readonly ITripService tripsService;

        public TripsController(ITripService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View(this.tripsService.GetAll(), "All");
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripAddInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(inputModel.StartPoint) || string.IsNullOrWhiteSpace(inputModel.EndPoint) || inputModel.DepartureTime == null)
            {
                return this.View();
            }

            if (inputModel.Seats < MinSeatsCapacity || inputModel.Seats > MaxSeatsCapacity)
            {
                return this.View();
            }

            if (inputModel.Description.Length > MaxDescriptionLength)
            {
                return this.View();
            }

            this.tripsService.Add(inputModel);
            return this.Redirect("/Trips/All");
        }
        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetById(tripId);
            return this.View(trip, "Details");
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.Request.SessionData["UserId"];
            var isAdded = this.tripsService.AddUserToTripById(tripId, userId);

            if (isAdded)
            {
                return this.Redirect("/Trips/All");
            }

            return this.Redirect($"/Trips/Details?tripId={tripId}");
        }
    }
}