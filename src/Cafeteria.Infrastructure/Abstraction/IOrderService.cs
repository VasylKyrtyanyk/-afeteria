using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.Commands;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Abstraction
{
    public interface IOrderService
    {
        Task<OrderDTO> Add(CreateOrderCommand createOrderCommand);
        Task<bool> Update(int orderId, UpdateOrderCommand updateOrderCommand);
        Task<OrderDTO> GetById(int orderId);
        Task<IEnumerable<OrderDTO>> GetAll();
        Task<bool> DeleteById(int orderId);
        Task<IEnumerable<OrderDTO>> GetUserOrders(int userId);
    }
}
