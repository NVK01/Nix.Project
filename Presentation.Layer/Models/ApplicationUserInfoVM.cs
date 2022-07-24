using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Layer.Models
{
    public class ApplicationUserInfoVM : IdentityUser<Guid>
    {

        public string? Password { get; set; }
        public string? About { get; set; }
        public string? IconURL { get; set; }
        [NotMapped]
        public IFormFile? IconFile { get; set; }
    }
}
