using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface IOrderService
    {
        Task<OrderModel> GetById(string id);
        Task<List<OrderModel>> GetAll();
        Task<OrderModel> Add(OrderModel model);
        Task<OrderModel> Update(OrderModel model);
        Task<string> Delete(string id);
        Task<decimal> GetTotalRevenueForCurrentMonth();
    }
}
