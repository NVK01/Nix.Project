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
        public Guid? OrderItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public Guid PaintingId { get; set; }
        public Painting? Painting { get; set; }

        public Guid OrderId { get; set; }
        public string? Order { get; set; }
    }
}
