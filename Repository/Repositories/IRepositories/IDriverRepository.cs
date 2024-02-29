using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface IDriverRepository
    {
        Task<Driver> GetById(string id);
        Task<List<Driver>> GetAll();
        Task<Driver> Add(Driver driver);
        Task<Driver> Update(Driver driver);
        Task<string> Delete(string id);
    }
}
