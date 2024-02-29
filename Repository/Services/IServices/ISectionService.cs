using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface ISectionService
    {
        Task<SectionModel> GetById(string id);
        Task<List<SectionModel>> GetAll();
        Task<SectionModel> Add(SectionModel model);
        Task<SectionModel> Update(SectionModel model);
        Task<string> Delete(string id);
    }
}
