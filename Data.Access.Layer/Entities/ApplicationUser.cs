using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public string? About { get; set; }
        public string? IconURL { get; set; }
        public List<Painting>? Paintings { get; set; }
    }
}
