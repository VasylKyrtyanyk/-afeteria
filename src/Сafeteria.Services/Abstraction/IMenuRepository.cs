using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;

namespace Сafeteria.Services.Abstraction
{
    public interface IMenuRepository: IGenericRepository<Menu, int>
    {
        Task<IEnumerable<Menu>> GetAllMenusWithProductDetails();
        Task<Menu> GetMenuWithProductDetails(int menuId);
    }
}
