using Data.Access.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ApplicationUser> ApplicationUsers { get; }
        IGenericRepository<Painting> Paintings { get; }
        IGenericRepository<OrderItem> OrdersItems { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<ShoppingCart> ShoppingCarts { get; }
        IGenericRepository<ShoppingCartItem> ShoppingCartItems { get; }
    }
}
