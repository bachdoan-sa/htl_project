using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface IOrderDetailService
    {
        Task<OrderDetailModel> GetById(string id);
        Task<List<OrderDetailModel>> GetAll();
        Task<OrderDetailModel> Add(OrderDetailModel model);
        Task<OrderDetailModel> Update(OrderDetailModel model);
        Task<string> Delete(string id);
        
    }
}
