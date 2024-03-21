using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface ICheckpointRepository
    {
        Task<Checkpoint> GetById(string id);
        Task<List<Checkpoint>> GetAll();
        Task<Checkpoint> Add(Checkpoint roadmap);
        Task<Checkpoint> Update(Checkpoint roadmap);
        Task<string> Delete(string id);
    }
}
