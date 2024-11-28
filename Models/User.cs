using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Admin or User")]
        public string Role { get; set; } //Admin or User
    }
}
