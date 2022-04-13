using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Discount.Models;
using ShopsRUs.Discount.Services;
using ShopsRUs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost]
        public async Task<IActionResult> GetDiscount(BasketDto basketDto)
        {
            var memberYear = (DateTime.Now.Year - basketDto.AppUser.MemberRegistrationTime.Year);
            bool isMember = basketDto.AppUser.IsMember;
            bool isEmployee = basketDto.AppUser.IsEmployee;
            int discountPersent = 0;
            if (isMember==true)
            {
                discountPersent +=10;
                basketDto.DiscountedTotalPrice = basketDto.TotalPrice - ((basketDto.TotalPrice * discountPersent)/100);
                basketDto.DiscountedTotalPrice = basketDto.DiscountedTotalPrice - DiscountCalculator.GetPersentByPersent(basketDto.DiscountedTotalPrice);
            }
            else if (isEmployee==true)
            {
                discountPersent += 30;
                basketDto.DiscountedTotalPrice = basketDto.TotalPrice - ((basketDto.TotalPrice * discountPersent) / 100);
                basketDto.DiscountedTotalPrice = basketDto.DiscountedTotalPrice - DiscountCalculator.GetPersentByPersent(basketDto.DiscountedTotalPrice);
            }
            else if((isMember == false && isEmployee == false) && memberYear>=2)
            {
                discountPersent += 5;
                basketDto.DiscountedTotalPrice = basketDto.TotalPrice - ((basketDto.TotalPrice * discountPersent) / 100);
                basketDto.DiscountedTotalPrice = basketDto.DiscountedTotalPrice - DiscountCalculator.GetPersentByPersent(basketDto.DiscountedTotalPrice);
            }
            else
            {
                basketDto.DiscountedTotalPrice = basketDto.TotalPrice;
                basketDto.DiscountedTotalPrice = basketDto.DiscountedTotalPrice - DiscountCalculator.GetPersentByPersent(basketDto.DiscountedTotalPrice);

            }
            return Ok(basketDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Models.Discount discount)
        {
            return Ok(await _discountService.GetAll());
        }

        /*[HttpPost]
        public async Task<IActionResult> Add(Models.Discount discount)
        {
            await _discountService.Save(discount);
            return Ok(discount);
        }*/
        
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountService.GetById(id);
            return Ok(discount);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            await _discountService.Update(discount);
            return Ok(discount);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountService.Delete(id);
            return Ok();
        }

    }
}
