using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<Models.Discount>> GetAll();
        Task<Models.Discount> GetById(int id);
        Task<Models.Discount> Save(Models.Discount discount);
        Task<Models.Discount> Update(Models.Discount discount);
        Task Delete(int id);
    }
}
