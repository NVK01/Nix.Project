using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class OrderItemDTO
    {
        
        public Guid OrderItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public Guid PaintingId { get; set; }

        public Guid OrderId { get; set; }
        public string? Order { get; set; }
    }
}
