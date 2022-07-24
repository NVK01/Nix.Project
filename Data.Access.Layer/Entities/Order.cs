using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } 
        public string? Email { get; set; }

        public Guid? ApplicationUserId { get; set; }

        public List<OrderItem>? OrderItems { get; set; }
    }
}
