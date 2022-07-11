using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class ApplicationUserDTO
    {

        public string? ApplicationUserId { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "You must write your name", MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "You must write your SecondName", MinimumLength = 3)]
        public string? SecondName { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "The password must have less than 60 and more than 8 symbols", MinimumLength = 8)]
        public string? Password { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Incorrect email! Example: my123email@gmail.com")]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Incorrect format of number! Example:XXX-XXX-XXXX")]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "You must write your SecondName", MinimumLength = 0)]
        public string? About { get; set; }
        public string? ImgURL { get; set; }
        public List<PaintingDTO>? Paintings { get; set; }
    }
}
