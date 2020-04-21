namespace SharedTrip.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserTrip
    {

        //•	Has UserId – a string
        //•	Has User – a User object
        //•	Has TripId– a string
        //•	Has Trip – a Trip object

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey(nameof(Trip))]
        public string TripId { get; set; }
        public Trip Trip { get; set; }
    }
}