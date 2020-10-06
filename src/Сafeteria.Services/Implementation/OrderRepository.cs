using Cafeteria.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(CafeteriaDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Order>> GetUserOrders(int userId)
        {
            return await _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.User.Profile)// Optional
                .Where(o => o.UserId == userId).ToListAsync();
        }
    }
}
