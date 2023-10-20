using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage = "Please enter your name"), MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        //----------------------------------------------------------------- 
        [Required(ErrorMessage = "Please enter contact number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Contact { get; set; }


        //-----------------------------------------------------------------
        [Required(ErrorMessage = "Please enter your email id")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        //-----------------------------------------------------------------
        //[Required(ErrorMessage = "Please enter password"), MinLength(6)]
        //[StringLength(150, MinimumLength = 3, ErrorMessage = "min 3, max 50 letters")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //-----------------------------------------------------------------
        public string Role { get; set; } = string.Empty;

        public List<Order> Orders { get; set; }
        public User() { }

    }
}