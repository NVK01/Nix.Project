using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class OrderItemDTO
    {
        
        public string? OrderItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public string? PaintingId { get; set; }

        public string? OrderId { get; set; }
        public string? Order { get; set; }
    }
}
