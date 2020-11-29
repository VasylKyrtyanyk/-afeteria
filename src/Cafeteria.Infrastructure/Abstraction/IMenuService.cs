using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.Commands;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Abstraction
{
    public interface IMenuService
    {
        Task<MenuDTO> Add(AddMenuCommand addMenuCommand);
        Task<MenuDTO> Update(int menuId, UpdateMenuCommand updateMenuCommand);
        Task<MenuDTO> GetByID(int menuId);
        Task<IEnumerable<MenuDTO>> GetAll();
        Task<bool> DeleteById(int menuId);
    }
}
