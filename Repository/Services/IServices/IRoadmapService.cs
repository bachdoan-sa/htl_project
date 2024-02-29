using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface IRoadmapService
    {
        Task<Roadmap> GetRoadmapByIdAsync(string id);
        Task<List<Roadmap>> GetAllRoadmapsAsync();
        Task AddRoadmapAsync(Roadmap roadmap);
        Task UpdateRoadmapAsync(Roadmap roadmap);
        Task DeleteRoadmapAsync(string id);
    }
}
