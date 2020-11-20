using Cafeteria.DAL;
using System;
using System.Threading.Tasks;
using Сafeteria.Services.Abstraction;
using Сafeteria.Services.Implementation;

namespace Сafeteria.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CafeteriaDbContext _dbContext;
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private IMenuRepository _menuRepository;
        private IUserProfileRepository _userProfileRepository;

        public UnitOfWork(CafeteriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);
                return _userRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_dbContext);
                return _orderRepository;
            }
        }
        public IMenuRepository MenuRepository
        {
            get
            {
                if (_menuRepository == null)
                    _menuRepository = new MenuRepository(_dbContext);
                return _menuRepository;
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_dbContext);
                return _productRepository;
            }
        }
        public IUserProfileRepository UserProfileRepository
        {
            get
            {
                if (_userProfileRepository == null)
                    _userProfileRepository = new UserProfileRepository(_dbContext);
                return _userProfileRepository;
            }
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
