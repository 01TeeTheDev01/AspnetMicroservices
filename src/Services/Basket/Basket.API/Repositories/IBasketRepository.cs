using Basket.API.Controllers.Entities;
using System.Threading.Tasks;

namespace Basket.API.Controllers.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userame);

        Task<ShoppingCart> UpdateBasket(ShoppingCart cart);

        Task DeleteBasket(string username);
    }
}
