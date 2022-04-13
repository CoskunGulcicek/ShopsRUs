using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Basket.Services;
using ShopsRUs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket(int userId)
        {
            var basket = await _basketService.GetBasket(userId);
            return Created("", basket);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            var response = await _basketService.SaveOrUpdate(basketDto);
            return Created("", response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(int userId)
        {
            await _basketService.Delete(userId);
            return NoContent();
        }
    }
}
