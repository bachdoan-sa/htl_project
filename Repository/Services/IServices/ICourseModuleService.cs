using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface ICourseModuleService
    {
        Task<CourseModuleModel> GetById(string id);
        Task<List<CourseModuleModel>> GetAll();
        Task<CourseModuleModel> Add(CourseModuleModel model);
        Task<CourseModuleModel> Update(CourseModuleModel model);
        Task<string> Delete(string id);

        Task<List<CourseModuleModel>> GetByCourseId(string id);
    }
}
