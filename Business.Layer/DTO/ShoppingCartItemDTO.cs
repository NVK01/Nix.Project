using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class ShoppingCartItemDTO
    {
        public string? ShoppingCartItemId { get; set; }
        public string? PaintingId { get; set; }
       
        public int Amount { get; set; }

        public string? ShoppingCartId { get; set; }
    }
}
