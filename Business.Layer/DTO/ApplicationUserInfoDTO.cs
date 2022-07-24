using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class ApplicationUserInfoDTO : IdentityUser<Guid>
    {

        public string? Password { get; set; }
        public string? About { get; set; }
        public string? IconURL { get; set; }
    }
}
