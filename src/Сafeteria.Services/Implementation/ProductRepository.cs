using Cafeteria.DAL;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        public ProductRepository(CafeteriaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
