using Cafeteria.DAL;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        public ProductRepository(CafeteriaDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Product> GetProductWithDetails(int productId)
        {
            return await _dbContext.Products
                .Include(p => p.ProductMenus)
                .Include(o => o.ProductOrders)
                .SingleOrDefaultAsync(p => p.Id == productId);
        }
    }
}
