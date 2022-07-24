using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class ShoppingCartItemDTO
    {
        public Guid ShoppingCartItemId { get; set; }
        public Guid PaintingId { get; set; }
       
        public int Amount { get; set; }

        public Guid ShoppingCartId { get; set; }
    }
}
