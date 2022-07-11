using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Entities
{
    public class ShoppingCart 
    {
        [Key]
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }

    }
}
