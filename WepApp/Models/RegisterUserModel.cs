using System.ComponentModel.DataAnnotations;

namespace WepApp.Models
{
    public class RegisterUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required, EmailAddress]
        [Display(Name = "Eposta")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirm")]
        [Compare("Password", ErrorMessage = "2 kez doğru girin")]
        public string PasswordConfirm { get; set; }
    }
}
