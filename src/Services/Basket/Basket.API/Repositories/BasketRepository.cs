using Basket.API.Controllers.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Basket.API.Controllers.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task DeleteBasket(string username)
        {
            await _redisCache.RemoveAsync(username);
        }

        public async Task<ShoppingCart> GetBasket(string userame)
        {
            var shoppingCart = await _redisCache.GetStringAsync(userame);

            if (!string.IsNullOrEmpty(shoppingCart))
                 return JsonConvert.DeserializeObject<ShoppingCart>(shoppingCart);

            return null;
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart cart)
        {
            await _redisCache.SetStringAsync(cart.Username, JsonConvert.SerializeObject(cart));

            return await GetBasket(cart.Username);
        }
    }
}
