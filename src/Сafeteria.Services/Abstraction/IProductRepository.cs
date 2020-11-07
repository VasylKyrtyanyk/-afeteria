using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;

namespace Сafeteria.Services.Abstraction
{
    public interface IProductRepository: IGenericRepository<Product, int>
    {
        Task<Product> GetProductWithDetails(int userId);
    }
}
