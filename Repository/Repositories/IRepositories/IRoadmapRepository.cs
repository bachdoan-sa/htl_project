using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface IRoadmapRepository
    {
        Task<Roadmap> GetByIdAsync(string id);
        Task<List<Roadmap>> GetAllAsync();
        Task AddAsync(Roadmap roadmap);
        Task UpdateAsync(Roadmap roadmap);
        Task DeleteAsync(string id);
    }
}
