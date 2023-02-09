using System.ComponentModel.DataAnnotations;

namespace SkansenCodeFirst.Model.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adres E-Mail")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Potwierdź Hasło")]
        //[Compare(otherProperty: Password)]
        public string ConfirmPassword { get; set; } 
    }
}
