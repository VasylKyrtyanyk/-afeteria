using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Abstraction
{
    public interface IOrderService
    {
        Task<OrderDTO> GetById(int orderId);
        Task<IEnumerable<OrderDTO>> GetAll();
        Task<bool> DeleteById(int orderId);
        Task<IEnumerable<OrderDTO>> GetUserOrders(int userId);
    }
}
