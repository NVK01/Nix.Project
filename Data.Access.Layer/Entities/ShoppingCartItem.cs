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
        
        public Guid ShoppingCartItemId { get; set; } 
        public Guid PaintingId { get; set; }
        [ForeignKey("PaintingId")]
        public Painting? Painting { get; set; }
        public int Amount { get; set; }

        public Guid ShoppingCartId { get; set; }

    }
}
