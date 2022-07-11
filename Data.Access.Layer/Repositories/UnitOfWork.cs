using Data.Access.Layer.EF;
using Data.Access.Layer.Entities;
using Data.Access.Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Repositories
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _applicationDbContext;

        private GenericRepository<ApplicationUser> _applicationUsers;

        private GenericRepository<Painting> _paintings;

        private GenericRepository<Order> _orders;

        private GenericRepository<OrderItem> _ordersItems;

        private GenericRepository<ShoppingCart> _shoppingCarts;
        private GenericRepository<ShoppingCartItem> _shoppingCartItems;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IGenericRepository<ApplicationUser> ApplicationUsers => _applicationUsers ??= new GenericRepository<ApplicationUser>(_applicationDbContext);

        public IGenericRepository<Painting> Paintings => _paintings ??= new GenericRepository<Painting>(_applicationDbContext);

        public IGenericRepository<Order> Orders => _orders??= new GenericRepository<Order>(_applicationDbContext);

        public IGenericRepository<OrderItem> OrdersItems => _ordersItems ??= new GenericRepository<OrderItem>(_applicationDbContext);
        public IGenericRepository<ShoppingCart> ShoppingCarts => _shoppingCarts ??= new GenericRepository<ShoppingCart>(_applicationDbContext);

        public IGenericRepository<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems ??= new GenericRepository<ShoppingCartItem>(_applicationDbContext);

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
