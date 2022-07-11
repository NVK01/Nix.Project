using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Entities
{
    public class OrderItem
    {
        [Key]
        public string? OrderItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public string? PaintingId { get; set; }
        public Painting? Painting { get; set; }

        public string? OrderId { get; set; }
        public string? Order { get; set; }
    }
}
