using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> GetById(string id);
        Task<List<OrderDetail>> GetAll();
        Task<OrderDetail> Add(OrderDetail orderDetail);
        Task<OrderDetail> Update(OrderDetail orderDetail);
        Task<string> Delete(string id);
        Task<List<OrderDetail>> GetOrderDetailsByIds(string[] itemIds);
        Task<List<OrderDetail>> GetOrderDetailsByUserId(string userId);
        Task<List<OrderDetail>> GetOrderDetailsByOrderId(string Id);
    }
}
