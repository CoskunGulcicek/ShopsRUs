using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Discount.Models
{
    [Dapper.Contrib.Extensions.Table("discount")]
    public class Discount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BasketId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
        public float DiscountedTotal { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
