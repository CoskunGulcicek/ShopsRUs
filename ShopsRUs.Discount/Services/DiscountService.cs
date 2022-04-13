using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;
        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostreSql"));
        }

        public async Task Delete(int id)
        {
            await _dbConnection.ExecuteAsync($"Delete from discount where id = {id}");
        }

        public async Task<List<Models.Discount>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("Select * from discount");
            return discounts.ToList();
        }

        public async Task<Models.Discount> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>($"select * from discount where id={id}")).SingleOrDefault();
            return (Models.Discount)discount;
        }

        public async Task Save(Models.Discount discount)
        {
            await _dbConnection.ExecuteAsync($"INSERT INTO discount(userId,basketId,quantity,price,totalPrice,discountedTotal,amount)" +
            $"VALUES({discount.UserId},{discount.BasketId},{discount.Quantity},{discount.Price},{discount.TotalPrice},{discount.DiscountedTotal},{discount.Amount})");

        }

        public async Task Update(Models.Discount discount)
        {
            await _dbConnection.ExecuteAsync($"UPDATE discount SET " +
            $"basketId={discount.BasketId}," +
            $"quantity={discount.Quantity}," +
            $"price={discount.Price}," +
            $"totalPrice={discount.TotalPrice}," +
            $"discountedTotal={discount.DiscountedTotal}," +
            $"amount={discount.Amount}" +
            $" WHERE userid={discount.UserId}");
        }
    }
}
