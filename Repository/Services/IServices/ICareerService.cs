using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface ICareerService
    {
        Task<CareerModel> GetById(string id);
        Task<List<CareerModel>> GetAll();
        Task<CareerModel> Add(CareerModel model);
        Task<CareerModel> Update(CareerModel model);
        Task<string> Delete(string id);
    }
}
