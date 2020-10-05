using Cafeteria.DAL;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(CafeteriaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
