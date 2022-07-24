using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class ShoppingCartDTO
    {
        public Guid ShoppingCartId { get; set; }
        public List<ShoppingCartItemDTO>? ShoppingCartItems { get; set; }
    }
}
