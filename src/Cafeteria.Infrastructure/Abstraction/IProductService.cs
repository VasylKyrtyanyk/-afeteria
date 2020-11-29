using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.Commands;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Abstraction
{
    public interface IProductService
    {
        Task<ProductDTO> GetById(int productId);
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<bool> DeleteById(int productId);
        Task<ProductDTO> Add(AddProductCommand product);
        Task<ProductDTO> Update(int productId, UpdateProductCommand update);
    }
}
