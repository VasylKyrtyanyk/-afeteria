using System.Threading.Tasks;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IOrderRepository OrderRepository { get; }
        IMenuRepository MenuRepository { get; }
        IProductRepository ProductRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        Task Save();
    }
}
