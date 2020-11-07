using Cafeteria.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    public class MenuRepository : GenericRepository<Menu, int>, IMenuRepository
    {
        public MenuRepository(CafeteriaDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Menu>> GetAllMenusWithProductDetails()
        {
            return await _dbContext.Menus
                .Include(p => p.ProductMenus)
                .ThenInclude(pm => pm.Product)
                .ToListAsync();
        }

        public async Task<Menu> GetMenuWithProductDetails(int menuId)
        {
            return await _dbContext.Menus
                .Include(p => p.ProductMenus)
                .ThenInclude(pm => pm.Product)
                .Where(m => m.Id == menuId).SingleOrDefaultAsync();
        }
    }
}
