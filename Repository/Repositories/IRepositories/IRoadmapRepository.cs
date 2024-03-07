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
        Task<Roadmap> GetById(string id);
        Task<List<Roadmap>> GetAll();
        Task<Roadmap> Add(Roadmap roadmap);
        Task<Roadmap> Update(Roadmap roadmap);
        Task Delete(string id);
        Task<int> CountCourseInRoadMap(string id);
    }
}
