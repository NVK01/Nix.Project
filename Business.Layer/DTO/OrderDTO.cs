using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class OrderDTO
    {
        public string? Id { get; set; }
        public string? Email { get; set; }

        public string? ApplicationUserId { get; set; }

    }
}
