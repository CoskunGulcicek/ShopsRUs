using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Shared.Dtos
{
    public class BasketDto
    {
        public int UserId { get; set; }
        public List<BasketItemDto> basketItems { get; set; }
        public decimal TotalPrice
        {
            get => basketItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
