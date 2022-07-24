using Microsoft.AspNetCore.Identity;
using Nix.Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Layer.Models
{
    public class ApplicationUserVM : IdentityUser<Guid>
    {
        public string? About { get; set; }
        public string? IconURL { get; set; }
        public List<PaintingVM>? Paintings { get; set; }

    }
}
