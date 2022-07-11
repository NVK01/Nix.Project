using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Entities
{
    public class ShoppingCartItem
    {
        [Key]
        
        public string? ShoppingCartItemId { get; set; } 
        public string? PaintingId { get; set; }
        [ForeignKey("PaintingId")]
        public Painting? Painting { get; set; }
        public int Amount { get; set; }

        public string? ShoppingCartId { get; set; }

    }
}
