using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface ISectionRepository
    {
        Task<Section> GetById(string id);
        Task<List<Section>> GetAll();
        Task<Section> Add(Section section);
        Task<Section> Update(Section section);
        Task<string> Delete(string id);
        Task<List<Section>> GetListSectionByRoadmapId (string id);
    }
}
