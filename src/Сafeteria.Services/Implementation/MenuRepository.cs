using Cafeteria.DAL;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    public class MenuRepository : GenericRepository<Menu, int>, IMenuRepository
    {
        public MenuRepository(CafeteriaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
