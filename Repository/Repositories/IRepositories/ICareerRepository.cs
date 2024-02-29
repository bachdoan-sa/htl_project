using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface ICareerRepository
    {
        Task<Career> GetById(string id);
        Task<List<Career>> GetAll();
        Task<Career> Add(Career Career);
        Task<Career> Update(Career Career);
        Task<string> Delete(string id);
    }
}
