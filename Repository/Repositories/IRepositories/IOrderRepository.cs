using Repository.Entities;
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
    }
}
