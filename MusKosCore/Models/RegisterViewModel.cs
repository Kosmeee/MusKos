using System.ComponentModel.DataAnnotations;

namespace MusKosCore.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "Minimal length for password is 6")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Wrong password confirmation")]
        [DataType(DataType.Password)]
        [Display(Name = "Password confirmation")]
        public string PasswordConfirm { get; set; }
    }
}
