using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Positions
{
    public class CreatePositionInputModel
    {
        [Required]
        [MinLength(3)]
        public string PositionName { get; set; }
    }
}
