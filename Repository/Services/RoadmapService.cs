using Repository.Entities;
using Repository.Repositories.IRepositories;
using Repository.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRoadmapRepository _roadmapRepository;

        public RoadmapService(IRoadmapRepository roadmapRepository)
        {
            _roadmapRepository = roadmapRepository;
        }

        public async Task<Roadmap> GetRoadmapByIdAsync(string id)
        {
            return await _roadmapRepository.GetByIdAsync(id);
        }

        public async Task<List<Roadmap>> GetAllRoadmapsAsync()
        {
            return await _roadmapRepository.GetAllAsync();
        }

        public async Task AddRoadmapAsync(Roadmap roadmap)
        {
            await _roadmapRepository.AddAsync(roadmap);
        }

        public async Task UpdateRoadmapAsync(Roadmap roadmap)
        {
            await _roadmapRepository.UpdateAsync(roadmap);
        }

        public async Task DeleteRoadmapAsync(string id)
        {
            await _roadmapRepository.DeleteAsync(id);
        }
    }
}
