using ShopsRUs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopsRUs.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<bool> Delete(int UserId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(UserId.ToString());
            return status;
        }

        public async Task<BasketDto> GetBasket(int UserId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(UserId.ToString());
            if (!String.IsNullOrEmpty(existBasket))
            {
                return JsonSerializer.Deserialize<BasketDto>(existBasket);
            }
            return null;
        }

        public async Task<bool> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId.ToString(), JsonSerializer.Serialize(basketDto));
            return status;
        }
    }
}
