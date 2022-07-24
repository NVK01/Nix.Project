using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class ApplicationUserDTO :  IdentityUser<Guid>
    {
        public string? About { get; set; }
        public string? IconURL { get; set; }
        public List<PaintingDTO>? Paintings { get; set; }
        public string? Password { get;  set; }
        public bool RememberMe { get; set; }
    }
}
