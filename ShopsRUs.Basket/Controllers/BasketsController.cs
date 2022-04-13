using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopsRUs.Basket.Services;
using ShopsRUs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

            //indirim için discount microservisi ile iletişime geçip indirimi yapıp toplam tutarı getirecek backgorund service veya worker
            using var httpClient = new HttpClient();
            var JsonData = JsonConvert.SerializeObject(basketDto);
            var stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await httpClient.PostAsync($"https://localhost:5014/api/discounts", stringContent);
            BasketDto discount = new BasketDto();
            if (responseMessage.IsSuccessStatusCode)
            {
                discount = JsonConvert.DeserializeObject<BasketDto>(await responseMessage.Content.ReadAsStringAsync());
            }
            //indirim için discount microservisi ile iletişime geçip indirimi yapıp toplam tutarı getirecek backgorund service veya worker
            
            var response = await _basketService.SaveOrUpdate(basketDto);

            return Created("", discount);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(int userId)
        {
            await _basketService.Delete(userId);
            return NoContent();
        }
    }
}
