using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Discount.Models
{
    public static class DiscountCalculator
    {
        public static decimal GetPersentByPersent(decimal price)
        {
            decimal total = price / 100;
            return Math.Round(total*5);
        }
    }
}
