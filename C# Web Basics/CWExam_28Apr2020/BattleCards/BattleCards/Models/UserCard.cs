namespace BattleCards.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserCard
    {
        //        •	Has UserId – a string
        //•	Has User – a User object
        //•	Has CardId – an int
        //•	Has Card – a Card object

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}