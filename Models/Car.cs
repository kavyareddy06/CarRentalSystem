using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class Car
    {
        [Required(ErrorMessage = "Please enter ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Make")]
        public string Make {  get; set; }
        [Required(ErrorMessage = "Please enter Model")]
        public string Model {  get; set; }
        [Required(ErrorMessage = "Please enter Year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter PricePerDay")]
        public decimal PricePerDay {  get; set; }
        [Required(ErrorMessage = "Please enter If Available or not")]
        public bool IsAvailable {  get; set; }
    }
}
