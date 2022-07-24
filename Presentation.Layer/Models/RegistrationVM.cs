using System.ComponentModel.DataAnnotations;

namespace Presentation.Layer.Models
{
    public class RegistrationVM
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string? ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
    }
}
