using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface IDriverService
    {
        Task<DriverModel> GetById(string id);
        Task<List<DriverModel>> GetAll();
        Task<List<DriverModel>> GetListByUserId(string userId);
        Task<DriverModel> Add(DriverModel model);
        Task<DriverModel> Update(DriverModel model);
        Task<string> Delete(string id);
    }
}
