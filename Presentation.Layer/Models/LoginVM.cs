﻿using System.ComponentModel.DataAnnotations;

namespace Presentation.Layer.Models
{
    public class LoginVM
    {

        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        //public string? ReturnUrl { get; set; }
    }
}
