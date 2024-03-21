using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface IOrderRepository
    {
        Task<Order> GetById(string id);
        Task<List<Order>> GetAll();
        Task<Order> Add(Order order);
        Task<Order> Update(Order order);
        Task<string> Delete(string id);
        Task<decimal> GetTotalRevenueForCurrentMonth();
        Task<int> GetTotalOrdersForCurrentMonth();
        Task<int> GetTotalOrderCount();
        Task<List<OrderModel>> GetRecentOrdersWithUsers(int count);
        Task<List<Order>> GetAllByAccountId(string id);
    }
}
