using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;

namespace Сafeteria.Services.Abstraction
{
    public interface IOrderRepository: IGenericRepository<Order, int>
    {
        Task<List<Order>> GetUserOrders(int userId);
    }
}
